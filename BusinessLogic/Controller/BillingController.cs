using HospitalPRAC.BusinessLogic.Repository;
using HospitalPRAC.Model;
using Microsoft.Data.SqlClient;
using System.Globalization;

namespace HospitalPRAC.BusinessLogic.Controller
{
    /// <summary>
    /// Business logic for the billing page: builds the bill (every room the patient stayed in,
    /// consultation, services), subtracts the payments, and checks a payment before it is saved.
    /// </summary>
    public class BillingController
    {
        // Names saved in the payments table / shown in the grid
        public const string TypeDownpayment = "Downpayment";
        public const string TypePayment = "Payment";
        public const string ItemBalance = "Balance";

        private const string NotAvailable = "N/A";

        private readonly IBillingRepository _repository;
        private readonly CashierController _cashier;

        public BillingController() : this(new BillingRepository(), new CashierController()) { }

        public BillingController(IBillingRepository repository, CashierController cashier)
        {
            _repository = repository;
            _cashier = cashier;
        }

        // ---------- PATIENT INFORMATION (+ accompanying person) ----------

        /// <summary>Same formatted details the Cashier dashboard shows; null if the patient is not found.</summary>
        public PatientDetails? GetPatientDetails(int patientId)
        {
            PatientRecord? patient = _repository.GetPatient(patientId);
            return patient == null ? null : _cashier.GetDetails(patient);
        }

        // ---------- THE BILL ----------

        public BillSummary GetBill(int patientId)
        {
            var bill = new BillSummary();

            BillAdmission? admission = _repository.GetLatestAdmission(patientId);
            if (admission == null)
                return bill;   // no admission: nothing to bill

            DateTime admitDate = admission.AdmissionDate ?? DateTime.Today;

            bill.AdmissionId = admission.AdmissionId;
            bill.AdmissionDate = admitDate.ToString("MMM dd, yyyy");
            bill.Doctor = OrNotAvailable(admission.DoctorName);
            bill.AdmissionType = OrNotAvailable(admission.AdmissionTypeName);
            bill.RoomNo = OrNotAvailable(admission.RoomNumber);
            bill.BedNo = OrNotAvailable(admission.BedNumber);

            var charges = new List<BillLine>();

            // 1) Rooms the patient was moved OUT of: each one is charged at the rate it had then,
            //    from the day the patient arrived in it until the day of the transfer.
            DateTime stayStart = admitDate;
            foreach (RoomTransferStay stay in _repository.GetRoomTransfers(admission.AdmissionId, patientId, admitDate))
            {
                int days = DaysBetween(stayStart, stay.TransferDateTime);

                if (stay.DailyRate > 0)
                {
                    charges.Add(new BillLine("Previous Room",
                        RoomText(stay.RoomNumber, stay.BedNumber) + " - " + days + " day(s) x " + Money(stay.DailyRate),
                        days * stay.DailyRate));
                }

                stayStart = stay.TransferDateTime;
            }

            // 2) Current room / bed: from the last transfer (or the admission) until today.
            int currentDays = DaysBetween(stayStart, DateTime.Today);
            if (admission.DailyRate > 0)
            {
                charges.Add(new BillLine("Room & Bed",
                    RoomText(admission.RoomNumber, admission.BedNumber) + " - " + currentDays + " day(s) x " + Money(admission.DailyRate),
                    currentDays * admission.DailyRate));
            }

            // 3) Consultation fee of the doctor
            if (admission.ConsultationFee > 0)
            {
                string doctor = (admission.DoctorName ?? "").Trim();
                charges.Add(new BillLine("Consultation",
                    doctor != "" ? doctor : "Attending doctor",
                    admission.ConsultationFee));
            }

            // 4) Services added at admission
            foreach (ServiceItem service in _repository.GetServices(admission.AdmissionId))
            {
                string name = string.IsNullOrWhiteSpace(service.ServiceName)
                    ? "(unknown service)" : service.ServiceName;
                charges.Add(new BillLine("Service", name, service.Price));
            }

            // 5) Payments already made (shown as negative, they are subtracted)
            var paymentLines = new List<BillLine>();
            decimal paid = 0m;
            try
            {
                foreach (PaymentRecord p in _repository.GetPayments(admission.AdmissionId))
                {
                    string label = IsDownpayment(p.PaymentType) ? TypeDownpayment : TypePayment;
                    string when = p.PaymentDateTime.HasValue
                        ? p.PaymentDateTime.Value.ToString("MMM dd, yyyy h:mm tt") : "";

                    paid += p.Amount;
                    paymentLines.Add(new BillLine(label, when, -p.Amount));
                }
            }
            catch (SqlException ex)
            {
                bill.PaymentsWarning = "Hindi mabasa ang payments table.\n" +
                    "I-run muna ang create_payments_table.sql sa SSMS.\n\n" + ex.Message;
            }

            decimal total = charges.Sum(c => c.Amount);
            decimal remaining = Math.Max(0m, total - paid);

            bill.TotalBill = total;
            bill.Paid = paid;
            bill.Remaining = remaining;

            bill.Charges = charges;
            bill.PaymentLines = paymentLines;

            bill.Lines.AddRange(charges);
            bill.Lines.AddRange(paymentLines);
            bill.Lines.Add(new BillLine(ItemBalance, "Remaining balance", remaining));

            return bill;
        }

        // ---------- PAYMENTS ----------

        /// <summary>Checks the typed amount against the current bill. Nothing is saved here.</summary>
        public PaymentCheck PreparePayment(int patientId, string amountText)
        {
            BillSummary bill = GetBill(patientId);

            if (!bill.HasAdmission)
                return Fail("Walang admission ang patient na ito, kaya walang mababayaran.");

            string text = (amountText ?? string.Empty).Replace("₱", "").Trim();

            if (!decimal.TryParse(text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal amount))
                return Fail("Maglagay ng tamang amount (numero lang).");

            amount = Math.Round(amount, 2);
            if (amount <= 0m)
                return Fail("Ang amount ay dapat higit sa 0.");

            decimal remaining = bill.TotalBill - bill.Paid;

            if (remaining <= 0m)
            {
                var done = Fail("Bayad na ang bill na ito.");
                done.AlreadyPaid = true;
                return done;
            }

            if (amount > remaining)
                return Fail("Hindi pwedeng lumampas sa remaining balance (" + Money(remaining) + ").");

            return new PaymentCheck
            {
                Success = true,
                AdmissionId = bill.AdmissionId,
                Amount = amount,
                Remaining = remaining
            };
        }

        public OperationResult SavePayment(int admissionId, string paymentType, decimal amount)
        {
            try
            {
                _repository.AddPayment(admissionId, paymentType, amount);
                return OperationResult.Ok(paymentType + " na " + Money(amount) + " ay na-save.");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Pays the whole remaining balance of the given bill. The repository re-checks the balance
        /// inside a transaction, so the patient can never be charged more than the bill.
        /// </summary>
        public PayResult PayRemaining(BillSummary bill, DateTime when)
        {
            decimal remaining = Math.Round(bill.TotalBill - bill.Paid, 2);

            if (!bill.HasAdmission)
                return new PayResult { Message = "Walang admission ang patient na ito, kaya walang mababayaran." };

            if (remaining <= 0m)
                return new PayResult { Message = "Bayad na ang bill na ito." };

            try
            {
                bool saved = _repository.AddPaymentChecked(
                    bill.AdmissionId, TypePayment, remaining, bill.TotalBill, when);

                if (!saved)
                {
                    return new PayResult
                    {
                        BalanceChanged = true,
                        Message = "Nagbago ang balance ng bill (may ibang nag-save ng bayad)."
                    };
                }

                return new PayResult { Success = true, Amount = remaining, PaidAt = when };
            }
            catch (Exception ex)
            {
                return new PayResult { Message = ex.Message };
            }
        }

        // ---------- helpers ----------

        public static string Money(decimal value)
        {
            return "₱" + value.ToString("N2");
        }

        // At least 1 day per room, counted by calendar date.
        private static int DaysBetween(DateTime start, DateTime end)
        {
            return Math.Max(1, (end.Date - start.Date).Days);
        }

        private static string RoomText(string? room, string? bed)
        {
            string text = "Room " + (room ?? "").Trim();
            if (!string.IsNullOrWhiteSpace(bed))
                text += ", Bed " + bed.Trim();
            return text;
        }

        private static bool IsDownpayment(string type)
        {
            return string.Equals(type, "Deposit", StringComparison.OrdinalIgnoreCase)
                || string.Equals(type, TypeDownpayment, StringComparison.OrdinalIgnoreCase);
        }

        private static string OrNotAvailable(string? value)
        {
            return string.IsNullOrWhiteSpace(value) ? NotAvailable : value.Trim();
        }

        private static PaymentCheck Fail(string message)
        {
            return new PaymentCheck { Success = false, Message = message };
        }
    }
}
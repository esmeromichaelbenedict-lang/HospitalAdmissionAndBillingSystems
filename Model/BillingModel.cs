namespace HospitalPRAC.Model
{
    /// <summary>The latest admission of a patient, with the doctor, room, bed and current daily rate.</summary>
    public class BillAdmission
    {
        public int AdmissionId { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public string? DoctorName { get; set; }
        public decimal ConsultationFee { get; set; }
        public string? AdmissionTypeName { get; set; }
        public string? RoomNumber { get; set; }
        public string? BedNumber { get; set; }
        public decimal DailyRate { get; set; }
    }

    /// <summary>
    /// A room the patient was moved OUT of. DailyRate is the rate saved at the time of the
    /// transfer (or, for old transfers that have none, the old bed's/room's current rate).
    /// </summary>
    public class RoomTransferStay
    {
        public string RoomNumber { get; set; } = string.Empty;
        public string? BedNumber { get; set; }
        public decimal DailyRate { get; set; }
        public DateTime TransferDateTime { get; set; }
    }

    /// <summary>One payment already saved for an admission.</summary>
    public class PaymentRecord
    {
        public string PaymentType { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime? PaymentDateTime { get; set; }
    }

    /// <summary>One row of the bill grid (a charge, a payment, or the balance).</summary>
    public class BillLine
    {
        public string Item { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public decimal Amount { get; set; }

        public BillLine() { }

        public BillLine(string item, string details, decimal amount)
        {
            Item = item;
            Details = details;
            Amount = amount;
        }
    }

    /// <summary>The whole bill of a patient's latest admission, ready to display.</summary>
    public class BillSummary
    {
        public int AdmissionId { get; set; } = -1;
        public bool HasAdmission => AdmissionId >= 0;

        public string AdmissionDate { get; set; } = "N/A";
        public string Doctor { get; set; } = "N/A";
        public string AdmissionType { get; set; } = "N/A";
        public string RoomNo { get; set; } = "N/A";
        public string BedNo { get; set; } = "N/A";

        /// <summary>Charges, then payments (negative), then the Balance row.</summary>
        public List<BillLine> Lines { get; set; } = new();

        /// <summary>Only the charges: past rooms, current room, consultation, services.</summary>
        public List<BillLine> Charges { get; set; } = new();

        /// <summary>Only the payments already made, as negative amounts.</summary>
        public List<BillLine> PaymentLines { get; set; } = new();

        public decimal TotalBill { get; set; }
        public decimal Paid { get; set; }
        public decimal Remaining { get; set; }

        /// <summary>Filled in when the payments table could not be read.</summary>
        public string? PaymentsWarning { get; set; }
    }

    /// <summary>Result of paying the whole remaining balance.</summary>
    public class PayResult
    {
        public bool Success { get; set; }

        /// <summary>True when someone else saved a payment first, so nothing was saved.</summary>
        public bool BalanceChanged { get; set; }

        public string Message { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime PaidAt { get; set; }
    }

    /// <summary>Result of checking a payment before it is saved.</summary>
    public class PaymentCheck
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool AlreadyPaid { get; set; }
        public int AdmissionId { get; set; }
        public decimal Amount { get; set; }
        public decimal Remaining { get; set; }
    }
}
using HospitalPRAC.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HospitalPRAC.BusinessLogic.Repository
{
    public interface IBillingRepository
    {
        PatientRecord? GetPatient(int patientId);
        BillAdmission? GetLatestAdmission(int patientId);
        List<ServiceItem> GetServices(int admissionId);
        List<MedicineCharge> GetMedicines(int admissionId);
        List<RoomTransferStay> GetRoomTransfers(int admissionId, int patientId, DateTime since);
        List<PaymentRecord> GetPayments(int admissionId);
        void AddPayment(int admissionId, string paymentType, decimal amount);

        /// <summary>Saves the payment only if the balance is still big enough; false if it changed meanwhile.</summary>
        bool AddPaymentChecked(int admissionId, string paymentType, decimal amount, decimal totalBill, DateTime when);
    }

    /// <summary>Data access only: SQL in, models out. The bill computation lives in the controller.</summary>
    public class BillingRepository : IBillingRepository
    {
        private readonly string _connectionString;

        public BillingRepository() : this(DbConfig.ConnectionString) { }

        public BillingRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public PatientRecord? GetPatient(int patientId)
        {
            const string query = @"
                SELECT PatientID, LastName, FirstName, MiddleName, Suffix, DateOfBirth, Age,
                       Sex, Address, ContactNumber
                FROM Patient
                WHERE PatientID = @id";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", patientId);
            conn.Open();
            using var r = cmd.ExecuteReader();

            if (!r.Read())
                return null;

            return new PatientRecord
            {
                PatientID = Convert.ToInt32(r["PatientID"]),
                LastName = Str(r, "LastName") ?? string.Empty,
                FirstName = Str(r, "FirstName") ?? string.Empty,
                MiddleName = Str(r, "MiddleName"),
                Suffix = Str(r, "Suffix"),
                DateOfBirth = r["DateOfBirth"] == DBNull.Value
                                ? DateTime.MinValue
                                : Convert.ToDateTime(r["DateOfBirth"]),
                Age = r["Age"] == DBNull.Value ? 0 : Convert.ToInt32(r["Age"]),
                Sex = Str(r, "Sex") ?? string.Empty,
                Address = Str(r, "Address"),
                ContactNumber = Str(r, "ContactNumber")
            };
        }

        // Latest admission of the patient + doctor, type, room, bed.
        public BillAdmission? GetLatestAdmission(int patientId)
        {
            const string query = @"
                SELECT TOP 1
                       a.admission_id,
                       ISNULL(a.admission_date, a.admission_datetime) AS AdmitDate,
                       d.doctor_name,
                       d.consultation_fee,
                       t.admission_type_name,
                       r.room_number,
                       b.bed_number,
                       ISNULL(b.daily_rate, r.daily_rate) AS DailyRate
                FROM admissions a
                LEFT JOIN doctors d          ON d.doctor_id = a.doctor_id
                LEFT JOIN admission_types t  ON t.admission_type_id = a.admission_type_id
                LEFT JOIN rooms r            ON r.room_id = a.room_id
                LEFT JOIN Beds  b            ON b.bed_id  = a.bed_id
                WHERE a.PatientID = @id
                ORDER BY a.admission_datetime DESC, a.admission_id DESC";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", patientId);
            conn.Open();
            using var r = cmd.ExecuteReader();

            if (!r.Read())
                return null;

            return new BillAdmission
            {
                AdmissionId = Convert.ToInt32(r["admission_id"]),
                AdmissionDate = r["AdmitDate"] == DBNull.Value ? null : Convert.ToDateTime(r["AdmitDate"]),
                DoctorName = Str(r, "doctor_name"),
                ConsultationFee = r["consultation_fee"] == DBNull.Value ? 0m : Convert.ToDecimal(r["consultation_fee"]),
                AdmissionTypeName = Str(r, "admission_type_name"),
                RoomNumber = Str(r, "room_number"),
                BedNumber = Str(r, "bed_number"),
                DailyRate = r["DailyRate"] == DBNull.Value ? 0m : Convert.ToDecimal(r["DailyRate"])
            };
        }

        // Services chosen when the patient was admitted.
        public List<ServiceItem> GetServices(int admissionId)
        {
            const string query = @"
                SELECT x.ServiceID, s.ServiceName, x.price
                FROM admission_services x
                LEFT JOIN Services s ON s.ServiceID = x.ServiceID
                WHERE x.admission_id = @aid
                ORDER BY x.admission_service_id";

            var list = new List<ServiceItem>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@aid", admissionId);
            conn.Open();
            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                list.Add(new ServiceItem
                {
                    ServiceID = r["ServiceID"] == DBNull.Value ? 0 : Convert.ToInt32(r["ServiceID"]),
                    ServiceName = Str(r, "ServiceName") ?? string.Empty,
                    Price = r["price"] == DBNull.Value ? 0m : Convert.ToDecimal(r["price"])
                });
            }
            return list;
        }

        // Medicines and supplies the nurse added to this admission.
        public List<MedicineCharge> GetMedicines(int admissionId)
        {
            const string query = @"
                SELECT m.medicine_name, am.quantity, am.unit_price
                FROM admission_medicines am
                JOIN Medicines m ON m.medicine_id = am.medicine_id
                WHERE am.admission_id = @aid
                ORDER BY am.admission_medicine_id";

            var list = new List<MedicineCharge>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@aid", admissionId);
            conn.Open();
            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                list.Add(new MedicineCharge
                {
                    Name = Str(r, "medicine_name") ?? string.Empty,
                    Quantity = r["quantity"] == DBNull.Value ? 1 : Convert.ToInt32(r["quantity"]),
                    UnitPrice = r["unit_price"] == DBNull.Value ? 0m : Convert.ToDecimal(r["unit_price"])
                });
            }
            return list;
        }

        // Rooms the patient was moved out of during this admission, oldest first.
        // Rate = the rate saved at the transfer; old transfers without one fall back to the old bed/room rate.
        public List<RoomTransferStay> GetRoomTransfers(int admissionId, int patientId, DateTime since)
        {
            const string query = @"
                SELECT rt.transfer_datetime,
                       fr.room_number AS from_room,
                       fb.bed_number  AS from_bed,
                       COALESCE(rt.from_daily_rate, fb.daily_rate, fr.daily_rate) AS from_rate
                FROM dbo.RoomTransfer rt
                JOIN dbo.rooms fr ON fr.room_id = rt.from_room_id
                LEFT JOIN dbo.Beds fb ON fb.bed_id = rt.from_bed_id
                WHERE rt.PatientID = @patient
                  AND (rt.admission_id = @admission
                       OR (rt.admission_id IS NULL AND rt.transfer_datetime >= @since))
                ORDER BY rt.transfer_datetime";

            var list = new List<RoomTransferStay>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@patient", patientId);
            cmd.Parameters.AddWithValue("@admission", admissionId);
            cmd.Parameters.AddWithValue("@since", since);
            conn.Open();
            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                list.Add(new RoomTransferStay
                {
                    RoomNumber = Str(r, "from_room") ?? string.Empty,
                    BedNumber = Str(r, "from_bed"),
                    DailyRate = r["from_rate"] == DBNull.Value ? 0m : Convert.ToDecimal(r["from_rate"]),
                    TransferDateTime = Convert.ToDateTime(r["transfer_datetime"])
                });
            }
            return list;
        }

        public List<PaymentRecord> GetPayments(int admissionId)
        {
            const string query = @"
                SELECT payment_type, amount, payment_datetime
                FROM payments
                WHERE admission_id = @aid
                ORDER BY payment_datetime, payment_id";

            var list = new List<PaymentRecord>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@aid", admissionId);
            conn.Open();
            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                list.Add(new PaymentRecord
                {
                    PaymentType = Str(r, "payment_type") ?? string.Empty,
                    Amount = r["amount"] == DBNull.Value ? 0m : Convert.ToDecimal(r["amount"]),
                    PaymentDateTime = r["payment_datetime"] == DBNull.Value
                                        ? null
                                        : Convert.ToDateTime(r["payment_datetime"])
                });
            }
            return list;
        }

        public void AddPayment(int admissionId, string paymentType, decimal amount)
        {
            const string query = @"
                INSERT INTO payments (admission_id, payment_type, amount)
                VALUES (@aid, @type, @amt)";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@aid", admissionId);
            cmd.Parameters.AddWithValue("@type", paymentType);
            cmd.Parameters.AddWithValue("@amt", amount);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        // Locks the payments of this admission, re-checks the balance, then inserts, all in one transaction.
        public bool AddPaymentChecked(int admissionId, string paymentType, decimal amount, decimal totalBill, DateTime when)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var tx = conn.BeginTransaction(IsolationLevel.Serializable);

            decimal alreadyPaid;
            using (var cmd = new SqlCommand(
                "SELECT ISNULL(SUM(amount), 0) FROM payments WITH (UPDLOCK, HOLDLOCK) WHERE admission_id = @aid",
                conn, tx))
            {
                cmd.Parameters.AddWithValue("@aid", admissionId);
                alreadyPaid = Convert.ToDecimal(cmd.ExecuteScalar());
            }

            // Someone else already paid part of it: nothing is inserted.
            if (Math.Round(totalBill - alreadyPaid, 2) < amount)
            {
                tx.Rollback();
                return false;
            }

            using (var cmd = new SqlCommand(
                "INSERT INTO payments (admission_id, payment_type, amount, payment_datetime) " +
                "VALUES (@aid, @type, @amt, @dt)", conn, tx))
            {
                cmd.Parameters.AddWithValue("@aid", admissionId);
                cmd.Parameters.AddWithValue("@type", paymentType);
                cmd.Parameters.AddWithValue("@amt", amount);
                cmd.Parameters.AddWithValue("@dt", when);
                cmd.ExecuteNonQuery();
            }

            tx.Commit();
            return true;
        }

        private static string? Str(SqlDataReader r, string column)
        {
            return r[column] == DBNull.Value ? null : r[column].ToString()?.Trim();
        }
    }
}
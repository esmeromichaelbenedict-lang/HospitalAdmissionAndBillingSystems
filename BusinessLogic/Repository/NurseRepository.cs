using HospitalPRAC.Model;
using Microsoft.Data.SqlClient;

namespace HospitalPRAC.BusinessLogic.Repository
{
    public interface INurseRepository
    {
        List<PatientListItem> SearchPatients(string keyword);
        NursePatientInfo? GetPatientInfo(int patientId);
        List<MedicineItem> GetMedicines(string category);
        int AddMedicines(int admissionId, IEnumerable<int> medicineIds);
    }

    /// <summary>Data access for the Nurse dashboard: SQL in, models out.</summary>
    public class NurseRepository : INurseRepository
    {
        private readonly string _connectionString;

        public NurseRepository() : this(DbConfig.ConnectionString) { }

        public NurseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<PatientListItem> SearchPatients(string keyword)
        {
            const string query = @"
                SELECT PatientID, LastName, FirstName, MiddleName, Suffix
                FROM Patient
                WHERE LastName LIKE @k
                   OR FirstName LIKE @k
                   OR (FirstName + ' ' + LastName) LIKE @k
                ORDER BY LastName, FirstName";

            var list = new List<PatientListItem>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@k", "%" + keyword + "%");
            conn.Open();
            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                list.Add(new PatientListItem
                {
                    PatientID = Convert.ToInt32(r["PatientID"]),
                    FullName = BuildName(r)
                });
            }
            return list;
        }

        // Latest admission of the patient (same rule as BillingRepository.GetLatestAdmission).
        public NursePatientInfo? GetPatientInfo(int patientId)
        {
            const string query = @"
                SELECT TOP 1
                       p.PatientID, p.LastName, p.FirstName, p.MiddleName, p.Suffix,
                       p.DateOfBirth, p.Sex, p.Height, p.Weight, p.Age,
                       a.admission_id, t.admission_type_name, r.room_number, b.bed_number
                FROM Patient p
                LEFT JOIN admissions a      ON a.PatientID = p.PatientID
                LEFT JOIN admission_types t ON t.admission_type_id = a.admission_type_id
                LEFT JOIN rooms r           ON r.room_id = a.room_id
                LEFT JOIN Beds b            ON b.bed_id  = a.bed_id
                WHERE p.PatientID = @id
                ORDER BY a.admission_datetime DESC, a.admission_id DESC";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", patientId);
            conn.Open();
            using var r = cmd.ExecuteReader();

            if (!r.Read())
                return null;

            return new NursePatientInfo
            {
                PatientID = Convert.ToInt32(r["PatientID"]),
                AdmissionId = r["admission_id"] == DBNull.Value ? 0 : Convert.ToInt32(r["admission_id"]),
                FullName = BuildName(r),
                DateOfBirth = r["DateOfBirth"] == DBNull.Value ? null : Convert.ToDateTime(r["DateOfBirth"]),
                Sex = Str(r, "Sex") ?? string.Empty,
                Height = r["Height"] == DBNull.Value ? 0m : Convert.ToDecimal(r["Height"]),
                Weight = r["Weight"] == DBNull.Value ? 0m : Convert.ToDecimal(r["Weight"]),
                Age = r["Age"] == DBNull.Value ? 0 : Convert.ToInt32(r["Age"]),
                RoomType = Str(r, "admission_type_name") ?? "-",
                RoomNumber = Str(r, "room_number") ?? "-",
                BedNumber = Str(r, "bed_number") ?? "-"
            };
        }

        public List<MedicineItem> GetMedicines(string category)
        {
            const string query = @"
                SELECT medicine_id, medicine_name, price
                FROM Medicines
                WHERE category = @cat
                ORDER BY medicine_name";

            var list = new List<MedicineItem>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@cat", category);
            conn.Open();
            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                list.Add(new MedicineItem
                {
                    MedicineID = Convert.ToInt32(r["medicine_id"]),
                    Name = Str(r, "medicine_name") ?? string.Empty,
                    Price = Convert.ToDecimal(r["price"])
                });
            }
            return list;
        }

        // All-or-nothing. The price is read from Medicines by SQL, never taken from the screen.
        public int AddMedicines(int admissionId, IEnumerable<int> medicineIds)
        {
            const string query = @"
                INSERT INTO admission_medicines (admission_id, medicine_id, quantity, unit_price)
                SELECT @aid, medicine_id, 1, price
                FROM Medicines
                WHERE medicine_id = @mid";

            int added = 0;

            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var tx = conn.BeginTransaction();

            foreach (int mid in medicineIds)
            {
                using var cmd = new SqlCommand(query, conn, tx);
                cmd.Parameters.AddWithValue("@aid", admissionId);
                cmd.Parameters.AddWithValue("@mid", mid);
                added += cmd.ExecuteNonQuery();
            }

            tx.Commit();
            return added;
        }

        private static string BuildName(SqlDataReader r)
        {
            var parts = new[] { Str(r, "FirstName"), Str(r, "MiddleName"), Str(r, "LastName"), Str(r, "Suffix") };
            return string.Join(" ", parts.Where(p => !string.IsNullOrWhiteSpace(p)));
        }

        private static string? Str(SqlDataReader r, string column)
        {
            return r[column] == DBNull.Value ? null : r[column].ToString()?.Trim();
        }
    }
}
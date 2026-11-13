using HospitalPRAC.Model;
using Microsoft.Data.SqlClient;

namespace HospitalPRAC.BusinessLogic.Repository
{
    public interface ICashierRepository
    {
        List<PatientRecord> SearchPatients(string keyword);
        CompanionInfo? GetCompanion(int patientId);
        AdmissionSummary? GetLatestAdmission(int patientId);
    }

    /// <summary>Data access only: SQL in, models out. No formatting or rules here.</summary>
    public class CashierRepository : ICashierRepository
    {
        private readonly string _connectionString;

        public CashierRepository() : this(DbConfig.ConnectionString) { }

        public CashierRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Empty keyword = all patients.
        public List<PatientRecord> SearchPatients(string keyword)
        {
            const string query = @"
                SELECT PatientID, LastName, FirstName, MiddleName, Suffix,
                       DateOfBirth, Age, Sex, Address, ContactNumber
                FROM Patient
                WHERE @kw = ''
                   OR CAST(PatientID AS NVARCHAR(20)) LIKE @like
                   OR LastName      LIKE @like
                   OR FirstName     LIKE @like
                   OR FullName      LIKE @like
                   OR (LastName + ', ' + FirstName) LIKE @like
                   OR ContactNumber LIKE @like
                ORDER BY PatientID";

            var list = new List<PatientRecord>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@kw", keyword);
            cmd.Parameters.AddWithValue("@like", "%" + keyword + "%");
            conn.Open();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new PatientRecord
                {
                    PatientID = Convert.ToInt32(reader["PatientID"]),
                    LastName = Str(reader, "LastName") ?? string.Empty,
                    FirstName = Str(reader, "FirstName") ?? string.Empty,
                    MiddleName = Str(reader, "MiddleName"),
                    Suffix = Str(reader, "Suffix"),
                    DateOfBirth = reader["DateOfBirth"] == DBNull.Value
                                    ? DateTime.MinValue
                                    : Convert.ToDateTime(reader["DateOfBirth"]),
                    Age = reader["Age"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Age"]),
                    Sex = Str(reader, "Sex") ?? string.Empty,
                    Address = Str(reader, "Address"),
                    ContactNumber = Str(reader, "ContactNumber")
                });
            }
            return list;
        }

        public CompanionInfo? GetCompanion(int patientId)
        {
            const string query = @"
                SELECT TOP 1 FullName, Relationship, ContactNumber
                FROM Companion
                WHERE PatientID = @id
                ORDER BY CompanionID";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", patientId);
            conn.Open();
            using var reader = cmd.ExecuteReader();

            if (!reader.Read())
                return null;

            return new CompanionInfo
            {
                FullName = Str(reader, "FullName"),
                Relationship = Str(reader, "Relationship"),
                ContactNumber = Str(reader, "ContactNumber")
            };
        }

        // Latest admission of the patient, with its room and bed.
        public AdmissionSummary? GetLatestAdmission(int patientId)
        {
            const string query = @"
                SELECT TOP 1
                       r.room_number,
                       b.bed_number,
                       ISNULL(a.admission_date, a.admission_datetime) AS AdmitDate
                FROM admissions a
                LEFT JOIN rooms r ON r.room_id = a.room_id
                LEFT JOIN Beds  b ON b.bed_id  = a.bed_id
                WHERE a.PatientID = @id
                ORDER BY a.admission_datetime DESC, a.admission_id DESC";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", patientId);
            conn.Open();
            using var reader = cmd.ExecuteReader();

            if (!reader.Read())
                return null;

            return new AdmissionSummary
            {
                RoomNumber = Str(reader, "room_number"),
                BedNumber = Str(reader, "bed_number"),
                AdmissionDate = reader["AdmitDate"] == DBNull.Value
                                    ? null
                                    : Convert.ToDateTime(reader["AdmitDate"])
            };
        }

        private static string? Str(SqlDataReader reader, string column)
        {
            return reader[column] == DBNull.Value ? null : reader[column].ToString()?.Trim();
        }
    }
}
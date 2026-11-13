using HospitalPRAC.Model;
using Microsoft.Data.SqlClient;

namespace HospitalPRAC.BusinessLogic.Repository
{
    public interface IPatientRepository
    {
        List<PatientRecord> GetPatients(string search);
        int AddPatient(PatientRecord patient);
        void UpdatePatient(PatientRecord patient);
        void DeletePatient(int patientId);
    }

    public class PatientRepository : IPatientRepository
    {
        private readonly string _connectionString;

        public PatientRepository() : this(DbConfig.ConnectionString) { }

        public PatientRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<PatientRecord> GetPatients(string search)
        {
            string query = @"
                SELECT p.PatientID,p.FullName, p.LastName, p.FirstName, p.MiddleName, p.Suffix,
                       p.DateOfBirth, p.Sex, p.CivilStatus, p.Address, p.ContactNumber, p.Age,
                       p.Weight, p.Height,
                       c.FullName AS CompanionName, c.Relationship AS CompanionRelationship,
                       c.ContactNumber AS CompanionContact
                FROM dbo.Patient p
                OUTER APPLY (SELECT TOP 1 *
                             FROM dbo.Companion
                             WHERE PatientID = p.PatientID
                             ORDER BY CompanionID DESC) c";

            bool hasSearch = !string.IsNullOrWhiteSpace(search);
            if (hasSearch)
            {
                query += @" WHERE CONVERT(VARCHAR(20), p.PatientID) LIKE @search
                               OR p.FullName LIKE @search
                               OR p.LastName LIKE @search
                               OR p.FirstName LIKE @search";
            }

            var list = new List<PatientRecord>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);
            if (hasSearch)
                cmd.Parameters.AddWithValue("@search", "%" + search + "%");

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new PatientRecord
                {
                    PatientID = Convert.ToInt32(reader["PatientID"]),
                    FullName = Str(reader, "FullName") ?? string.Empty,
                    LastName = Str(reader, "LastName") ?? string.Empty,
                    FirstName = Str(reader, "FirstName") ?? string.Empty,
                    MiddleName = Str(reader, "MiddleName"),
                    Suffix = Str(reader, "Suffix"),
                    DateOfBirth = reader["DateOfBirth"] == DBNull.Value
                                    ? DateTime.Today
                                    : Convert.ToDateTime(reader["DateOfBirth"]),
                    Sex = Str(reader, "Sex") ?? string.Empty,
                    CivilStatus = Str(reader, "CivilStatus") ?? string.Empty,
                    Address = Str(reader, "Address"),
                    ContactNumber = Str(reader, "ContactNumber"),
                    Age = reader["Age"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Age"]),
                    Weight = reader["Weight"] == DBNull.Value ? null : Convert.ToDecimal(reader["Weight"]),
                    Height = reader["Height"] == DBNull.Value ? null : Convert.ToDecimal(reader["Height"]),
                    CompanionName = Str(reader, "CompanionName"),
                    CompanionRelationship = Str(reader, "CompanionRelationship"),
                    CompanionContact = Str(reader, "CompanionContact")
                });
            }
            return list;
        }


        public int AddPatient(PatientRecord patient)
        {
            const string query = @"
                INSERT INTO dbo.Patient
                    (FullName, LastName, FirstName, MiddleName, Suffix, DateOfBirth,
                     Sex, Age, CivilStatus, Address, ContactNumber, Weight, Height)
                VALUES
                    (@FullName, @LastName, @FirstName, @MiddleName, @Suffix, @DateOfBirth,
                     @Sex, @Age, @CivilStatus, @Address, @ContactNumber, @Weight, @Height);
                SELECT CAST(SCOPE_IDENTITY() AS int);";

            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var tx = conn.BeginTransaction();

            try
            {
                int newId;
                using (var cmd = new SqlCommand(query, conn, tx))
                {
                    AddPatientParameters(cmd, patient);
                    newId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                SaveCompanion(conn, tx, newId, patient);
                tx.Commit();
                return newId;
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }



        public void UpdatePatient(PatientRecord patient)
        {
            const string query = @"
                UPDATE dbo.Patient
                SET FullName = @FullName,
                    LastName = @LastName,
                    FirstName = @FirstName,
                    MiddleName = @MiddleName,
                    Suffix = @Suffix,
                    DateOfBirth = @DateOfBirth,
                    Sex = @Sex,
                    Age = @Age,
                    CivilStatus = @CivilStatus,
                    Address = @Address,
                    ContactNumber = @ContactNumber,
                    Weight = @Weight,
                    Height = @Height
                WHERE PatientID = @PatientID";

            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var tx = conn.BeginTransaction();

            try
            {
                using (var cmd = new SqlCommand(query, conn, tx))
                {
                    cmd.Parameters.AddWithValue("@PatientID", patient.PatientID);
                    AddPatientParameters(cmd, patient);
                    cmd.ExecuteNonQuery();
                }

                SaveCompanion(conn, tx, patient.PatientID, patient);
                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }


        public void DeletePatient(int patientId)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var tx = conn.BeginTransaction();

            try
            {
                DeleteRows(conn, tx, "Companion", patientId);
                DeleteRows(conn, tx, "admissions", patientId);
                DeleteRows(conn, tx, "Patient", patientId);
                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }

        private static void AddPatientParameters(SqlCommand cmd, PatientRecord p)
        {
            cmd.Parameters.AddWithValue("@FullName", p.FullName);
            cmd.Parameters.AddWithValue("@LastName", p.LastName);
            cmd.Parameters.AddWithValue("@FirstName", p.FirstName);
            cmd.Parameters.AddWithValue("@MiddleName", DbValue(p.MiddleName));
            cmd.Parameters.AddWithValue("@Suffix", DbValue(p.Suffix));
            cmd.Parameters.AddWithValue("@DateOfBirth", p.DateOfBirth.Date);
            cmd.Parameters.AddWithValue("@Sex", p.Sex);
            cmd.Parameters.AddWithValue("@Age", p.Age);
            cmd.Parameters.AddWithValue("@CivilStatus", p.CivilStatus);
            cmd.Parameters.AddWithValue("@Address", p.Address ?? string.Empty);
            cmd.Parameters.AddWithValue("@ContactNumber", p.ContactNumber ?? string.Empty);
            cmd.Parameters.AddWithValue("@Weight", p.Weight.HasValue ? p.Weight.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@Height", p.Height.HasValue ? p.Height.Value : DBNull.Value);
        }

        private static void SaveCompanion(SqlConnection conn, SqlTransaction tx, int patientId, PatientRecord p)
        {
            DeleteRows(conn, tx, "Companion", patientId);

            if (string.IsNullOrWhiteSpace(p.CompanionName))
                return;

            const string query = @"
                INSERT INTO dbo.Companion (PatientID, FullName, Relationship, ContactNumber)
                VALUES (@PatientID, @FullName, @Relationship, @ContactNumber)";

            using var cmd = new SqlCommand(query, conn, tx);
            cmd.Parameters.AddWithValue("@PatientID", patientId);
            cmd.Parameters.AddWithValue("@FullName", p.CompanionName);
            cmd.Parameters.AddWithValue("@Relationship", DbValue(p.CompanionRelationship));
            cmd.Parameters.AddWithValue("@ContactNumber", DbValue(p.CompanionContact));
            cmd.ExecuteNonQuery();
        }

        private static void DeleteRows(SqlConnection conn, SqlTransaction tx, string tableName, int patientId)
        {

            using var cmd = new SqlCommand(
                "DELETE FROM dbo." + tableName + " WHERE PatientID = @PatientID", conn, tx);
            cmd.Parameters.AddWithValue("@PatientID", patientId);
            cmd.ExecuteNonQuery();
        }

        private static object DbValue(string? value)
        {
            return string.IsNullOrWhiteSpace(value) ? DBNull.Value : value.Trim();
        }

        private static string? Str(SqlDataReader reader, string column)
        {
            return reader[column] == DBNull.Value ? null : reader[column].ToString()?.Trim();
        }
    }
}
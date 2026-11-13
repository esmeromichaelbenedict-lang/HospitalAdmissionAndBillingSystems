using HospitalPRAC.Model;
using Microsoft.Data.SqlClient;

namespace HospitalPRAC.BusinessLogic.Repository
{
    public interface IDashboardRepository
    {
        DashboardCounts GetCounts();
        List<AdmissionRecord> GetRecentAdmissions(int top);
    }

    public class DashboardRepository : IDashboardRepository
    {
        private readonly string _connectionString;

        public DashboardRepository() : this(DbConfig.ConnectionString) { }

        public DashboardRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DashboardCounts GetCounts()
        {
            const string query = @"
                SELECT
                    (SELECT COUNT(*) FROM dbo.rooms r
                     WHERE NOT EXISTS (SELECT 1 FROM dbo.admissions a WHERE a.room_id = r.room_id)) AS AvailableRooms,
                    (SELECT COUNT(*) FROM dbo.Patient) AS Patients,
                    (SELECT COUNT(*) FROM dbo.Users)   AS Users";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);
            conn.Open();
            using var reader = cmd.ExecuteReader();

            var counts = new DashboardCounts();
            if (reader.Read())
            {
                counts.AvailableRooms = Convert.ToInt32(reader["AvailableRooms"]);
                counts.Patients = Convert.ToInt32(reader["Patients"]);
                counts.Users = Convert.ToInt32(reader["Users"]);
            }
            return counts;
        }

        public List<AdmissionRecord> GetRecentAdmissions(int top)
        {
            const string query = @"
                SELECT TOP (@top)
                       a.admission_id          AS AdmissionId,
                       p.FullName              AS Patient,
                       d.doctor_name           AS Doctor,
                       r.room_number           AS Room,
                       t.admission_type_name   AS [Type],
                       a.reason_for_admission  AS Reason,
                       a.admission_datetime    AS AdmittedOn
                FROM dbo.admissions a
                INNER JOIN dbo.Patient p          ON p.PatientID = a.PatientID
                LEFT JOIN  dbo.doctors d          ON d.doctor_id = a.doctor_id
                LEFT JOIN  dbo.rooms r            ON r.room_id = a.room_id
                LEFT JOIN  dbo.admission_types t  ON t.admission_type_id = a.admission_type_id
                ORDER BY a.admission_datetime DESC";

            var list = new List<AdmissionRecord>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@top", top);
            conn.Open();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new AdmissionRecord
                {
                    AdmissionId = reader.GetInt32(reader.GetOrdinal("AdmissionId")),
                    Patient = reader["Patient"]?.ToString() ?? string.Empty,
                    Doctor = reader["Doctor"] as string,
                    Room = reader["Room"] == DBNull.Value ? null : reader["Room"].ToString(),
                    Type = reader["Type"] as string,
                    Reason = reader["Reason"] as string,
                    AdmittedOn = reader.GetDateTime(reader.GetOrdinal("AdmittedOn"))
                });
            }
            return list;
        }
    }
}
using HospitalPRAC.Model;
using Microsoft.Data.SqlClient;

namespace HospitalPRAC.BusinessLogic.Repository
{
    public interface IAdmissionRepository
    {
        List<DoctorItem> GetDoctors();
        List<AdmissionTypeItem> GetAdmissionTypes();
        List<ServiceItem> GetServices();
        int AdmitPatient(AdmissionRequest request);
    }

    /// <summary>Data access only: SQL in, models out. No validation here.</summary>
    public class AdmissionRepository : IAdmissionRepository
    {
        private readonly string _connectionString;

        public AdmissionRepository() : this(DbConfig.ConnectionString) { }

        public AdmissionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // ---------- LOOKUPS ----------

        public List<DoctorItem> GetDoctors()
        {
            const string query = @"SELECT doctor_id, doctor_name, consultation_fee
                                   FROM doctors ORDER BY doctor_name";
            var list = new List<DoctorItem>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new DoctorItem
                {
                    DoctorID = Convert.ToInt32(reader["doctor_id"]),
                    DoctorName = reader["doctor_name"].ToString() ?? string.Empty,
                    ConsultationFee = Convert.ToDecimal(reader["consultation_fee"])
                });
            }
            return list;
        }

        public List<AdmissionTypeItem> GetAdmissionTypes()
        {
            const string query = @"SELECT admission_type_id, admission_type_name
                                   FROM admission_types ORDER BY admission_type_id";
            var list = new List<AdmissionTypeItem>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new AdmissionTypeItem
                {
                    AdmissionTypeID = Convert.ToInt32(reader["admission_type_id"]),
                    AdmissionTypeName = reader["admission_type_name"].ToString() ?? string.Empty
                });
            }
            return list;
        }

        public List<ServiceItem> GetServices()
        {
            const string query = @"SELECT ServiceID, ServiceName, Price
                                   FROM Services ORDER BY ServiceName";
            var list = new List<ServiceItem>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new ServiceItem
                {
                    ServiceID = Convert.ToInt32(reader["ServiceID"]),
                    ServiceName = reader["ServiceName"].ToString() ?? string.Empty,
                    Price = Convert.ToDecimal(reader["Price"])
                });
            }
            return list;
        }

        // ---------- ADMIT (existing patient) ----------

        public int AdmitPatient(AdmissionRequest request)
        {
            const string reserveBed = @"
                UPDATE dbo.Beds SET status = 'Occupied'
                WHERE bed_id = @bed AND status = 'Available'";

            const string insertAdmission = @"
                INSERT INTO admissions
                    (PatientID, admission_datetime, reason_for_admission,
                     doctor_id, room_id, bed_id, admission_type_id)
                VALUES (@pid, @date, @reason, @doctor, @room, @bed, @type);
                SELECT CAST(SCOPE_IDENTITY() AS int);";

            const string insertService = @"
                INSERT INTO admission_services (admission_id, ServiceID, Price)
                VALUES (@aid, @sid, @price)";

            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var tx = conn.BeginTransaction();

            try
            {
                int bedId = request.Bed!.BedID;

                // 1. Reserve the bed first (fails if someone else took it).
                using (var cmd = new SqlCommand(reserveBed, conn, tx))
                {
                    cmd.Parameters.AddWithValue("@bed", bedId);
                    if (cmd.ExecuteNonQuery() == 0)
                        throw new InvalidOperationException("That bed is no longer available.");
                }

                // 2. Create the admission with its room and bed.
                int admissionId;
                using (var cmd = new SqlCommand(insertAdmission, conn, tx))
                {
                    cmd.Parameters.AddWithValue("@pid", request.PatientID);
                    cmd.Parameters.AddWithValue("@date", request.AdmissionDateTime);
                    cmd.Parameters.AddWithValue("@reason", request.Reason);
                    cmd.Parameters.AddWithValue("@doctor", request.Doctor!.DoctorID);
                    cmd.Parameters.AddWithValue("@room", request.Room!.RoomID);
                    cmd.Parameters.AddWithValue("@bed", bedId);
                    cmd.Parameters.AddWithValue("@type", request.AdmissionType!.AdmissionTypeID);
                    admissionId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // 3. Save the chosen services with their prices.
                foreach (ServiceItem service in request.Services)
                {
                    using var cmd = new SqlCommand(insertService, conn, tx);
                    cmd.Parameters.AddWithValue("@aid", admissionId);
                    cmd.Parameters.AddWithValue("@sid", service.ServiceID);
                    cmd.Parameters.AddWithValue("@price", service.Price);
                    cmd.ExecuteNonQuery();
                }

                tx.Commit();
                return admissionId;
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }
    }
}
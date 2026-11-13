using HospitalPRAC.Model;
using Microsoft.Data.SqlClient;

namespace HospitalPRAC.BusinessLogic.Repository
{
    public interface IRoomRepository
    {
        List<AdmittedPatientRow> GetAdmittedPatients(string keyword);
        List<string> GetRoomTypes();
        List<RoomOption> GetAvailableRooms(string roomType);
        List<BedOption> GetAvailableBeds(int roomId);
        List<RoomTransferRecord> GetTransferHistory(int admissionId, int patientId);
        void TransferPatient(TransferRequest request);
    }

    /// <summary>Data access only: SQL in, models out. No validation here.</summary>
    public class RoomRepository : IRoomRepository
    {
        private readonly string _connectionString;

        public RoomRepository() : this(DbConfig.ConnectionString) { }

        public RoomRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // ---------- PATIENT LIST ----------

        public List<AdmittedPatientRow> GetAdmittedPatients(string keyword)
        {
            // Rate = the bed's rate if the patient has a bed, otherwise the room's rate.
            const string query = @"
                SELECT a.admission_id, p.PatientID, p.FullName AS Patient,
                       r.room_number, r.room_type, b.bed_number,
                       COALESCE(b.daily_rate, r.daily_rate) AS Rate,
                       COALESCE(a.admission_date, a.admission_datetime) AS Admitted,
                       a.room_id, a.bed_id
                FROM dbo.admissions a
                JOIN dbo.Patient p ON p.PatientID = a.PatientID
                JOIN dbo.rooms r ON r.room_id = a.room_id
                LEFT JOIN dbo.Beds b ON b.bed_id = a.bed_id
                WHERE p.FullName LIKE '%' + @kw + '%'
                ORDER BY p.FullName";

            var list = new List<AdmittedPatientRow>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@kw", keyword ?? string.Empty);
            conn.Open();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new AdmittedPatientRow
                {
                    AdmissionId = Convert.ToInt32(reader["admission_id"]),
                    PatientID = Convert.ToInt32(reader["PatientID"]),
                    Patient = reader["Patient"].ToString() ?? string.Empty,
                    Room = reader["room_number"].ToString() ?? string.Empty,
                    Type = reader["room_type"].ToString() ?? string.Empty,
                    Bed = reader["bed_number"] == DBNull.Value ? null : reader["bed_number"].ToString(),
                    Rate = reader["Rate"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["Rate"]),
                    Admitted = reader["Admitted"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["Admitted"]),
                    RoomId = Convert.ToInt32(reader["room_id"]),
                    BedId = reader["bed_id"] == DBNull.Value ? null : Convert.ToInt32(reader["bed_id"])
                });
            }
            return list;
        }

        // ---------- DROPDOWNS ----------

        public List<string> GetRoomTypes()
        {
            const string query = "SELECT DISTINCT room_type FROM dbo.rooms ORDER BY room_type";
            var list = new List<string>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(reader["room_type"].ToString() ?? string.Empty);
            return list;
        }

        public List<RoomOption> GetAvailableRooms(string roomType)
        {
            const string query = @"
                SELECT room_id, room_number FROM dbo.rooms
                WHERE room_type = @type
                AND room_id IN (SELECT room_id FROM dbo.Beds WHERE status = 'Available')
                ORDER BY room_number";
            var list = new List<RoomOption>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@type", roomType);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new RoomOption
                {
                    RoomID = Convert.ToInt32(reader["room_id"]),
                    RoomNumber = reader["room_number"].ToString() ?? string.Empty
                });
            }
            return list;
        }

        public List<BedOption> GetAvailableBeds(int roomId)
        {
            const string query = @"
                SELECT bed_id, bed_number, daily_rate FROM dbo.Beds
                WHERE room_id = @room AND status = 'Available'
                ORDER BY bed_number";
            var list = new List<BedOption>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@room", roomId);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new BedOption
                {
                    BedID = Convert.ToInt32(reader["bed_id"]),
                    BedNumber = reader["bed_number"].ToString() ?? string.Empty,
                    DailyRate = Convert.ToDecimal(reader["daily_rate"])
                });
            }
            return list;
        }

        // ---------- ROOM HISTORY ----------

        public List<RoomTransferRecord> GetTransferHistory(int admissionId, int patientId)
        {
            // Rows saved before admission_id existed have NULL there, so they are included by PatientID.
            const string query = @"
                SELECT rt.transfer_datetime, rt.transfer_reason,
                       fr.room_number AS from_room, fr.room_type AS from_type,
                       fb.bed_number AS from_bed, rt.from_daily_rate,
                       tr.room_number AS to_room, tr.room_type AS to_type,
                       tb.bed_number AS to_bed, rt.to_daily_rate
                FROM dbo.RoomTransfer rt
                JOIN dbo.rooms fr ON fr.room_id = rt.from_room_id
                JOIN dbo.rooms tr ON tr.room_id = rt.to_room_id
                LEFT JOIN dbo.Beds fb ON fb.bed_id = rt.from_bed_id
                LEFT JOIN dbo.Beds tb ON tb.bed_id = rt.to_bed_id
                WHERE rt.PatientID = @patient
                  AND (rt.admission_id = @admission OR rt.admission_id IS NULL)
                ORDER BY rt.transfer_datetime";

            var list = new List<RoomTransferRecord>();

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@patient", patientId);
            cmd.Parameters.AddWithValue("@admission", admissionId);
            conn.Open();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new RoomTransferRecord
                {
                    FromRoom = reader["from_room"] + " - " + reader["from_type"],
                    FromBed = reader["from_bed"] == DBNull.Value ? null : reader["from_bed"].ToString(),
                    FromRate = reader["from_daily_rate"] == DBNull.Value ? null : Convert.ToDecimal(reader["from_daily_rate"]),
                    ToRoom = reader["to_room"] + " - " + reader["to_type"],
                    ToBed = reader["to_bed"] == DBNull.Value ? null : reader["to_bed"].ToString(),
                    ToRate = reader["to_daily_rate"] == DBNull.Value ? null : Convert.ToDecimal(reader["to_daily_rate"]),
                    TransferredOn = Convert.ToDateTime(reader["transfer_datetime"]),
                    Reason = reader["transfer_reason"] == DBNull.Value ? null : reader["transfer_reason"].ToString()
                });
            }
            return list;
        }

        // ---------- TRANSFER ----------

        public void TransferPatient(TransferRequest request)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var tx = conn.BeginTransaction();

            try
            {
                int newBedId = request.NewBed!.BedID;

                // 1. Reserve the new bed (fails if someone else took it).
                using (var cmd = new SqlCommand(
                    "UPDATE dbo.Beds SET status = 'Occupied' WHERE bed_id = @bed AND status = 'Available'", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@bed", newBedId);
                    if (cmd.ExecuteNonQuery() == 0)
                        throw new InvalidOperationException("That bed is no longer available.");
                }

                // 2. Save the rates as they are right now: the old rate (before moving) and the new one.
                decimal fromRate;
                using (var cmd = new SqlCommand(@"
                    SELECT COALESCE(b.daily_rate, r.daily_rate)
                    FROM dbo.admissions a
                    JOIN dbo.rooms r ON r.room_id = a.room_id
                    LEFT JOIN dbo.Beds b ON b.bed_id = a.bed_id
                    WHERE a.admission_id = @id", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@id", request.AdmissionId);
                    object? value = cmd.ExecuteScalar();
                    fromRate = value == null || value == DBNull.Value ? 0 : Convert.ToDecimal(value);
                }

                decimal toRate = request.NewBed.DailyRate;

                // 3. Free the old bed.
                if (request.CurrentBedId != null)
                {
                    using var cmd = new SqlCommand(
                        "UPDATE dbo.Beds SET status = 'Available' WHERE bed_id = @bed", conn, tx);
                    cmd.Parameters.AddWithValue("@bed", request.CurrentBedId.Value);
                    cmd.ExecuteNonQuery();
                }

                // 4. Move the admission to the new room and bed.
                using (var cmd = new SqlCommand(
                    "UPDATE dbo.admissions SET room_id = @room, bed_id = @bed WHERE admission_id = @id", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@room", request.NewRoomId);
                    cmd.Parameters.AddWithValue("@bed", newBedId);
                    cmd.Parameters.AddWithValue("@id", request.AdmissionId);
                    cmd.ExecuteNonQuery();
                }

                // 5. Write the history row, including both rates.
                using (var cmd = new SqlCommand(@"
                    INSERT INTO dbo.RoomTransfer
                        (PatientID, admission_id, from_room_id, to_room_id, from_bed_id, to_bed_id,
                         from_daily_rate, to_daily_rate, transfer_datetime, transfer_reason)
                    VALUES
                        (@patient, @admission, @fromRoom, @toRoom, @fromBed, @toBed,
                         @fromRate, @toRate, @date, @reason)", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@patient", request.PatientId);
                    cmd.Parameters.AddWithValue("@admission", request.AdmissionId);
                    cmd.Parameters.AddWithValue("@fromRoom", request.CurrentRoomId);
                    cmd.Parameters.AddWithValue("@toRoom", request.NewRoomId);
                    cmd.Parameters.AddWithValue("@fromBed", request.CurrentBedId.HasValue ? request.CurrentBedId.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@toBed", newBedId);
                    cmd.Parameters.AddWithValue("@fromRate", fromRate);
                    cmd.Parameters.AddWithValue("@toRate", toRate);
                    cmd.Parameters.AddWithValue("@date", request.TransferDateTime);
                    cmd.Parameters.AddWithValue("@reason", request.Reason);
                    cmd.ExecuteNonQuery();
                }

                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }
    }
}
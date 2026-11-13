namespace HospitalPRAC.Model
{
    public class DashboardCounts
    {
        public int AvailableRooms { get; set; }
        public int Patients { get; set; }
        public int Users { get; set; }
    }

    public class AdmissionRecord
    {
        public int AdmissionId { get; set; }
        public string Patient { get; set; } = string.Empty;
        public string? Doctor { get; set; }
        public string? Room { get; set; }
        public string? Type { get; set; }
        public string? Reason { get; set; }
        public DateTime AdmittedOn { get; set; }
    }
}
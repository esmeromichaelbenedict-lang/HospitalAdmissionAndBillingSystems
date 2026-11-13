using HospitalPRAC.BusinessLogic.Repository;
using HospitalPRAC.Model;

namespace HospitalPRAC.BusinessLogic.Controller
{
    public class DashboardController
    {
        private const int DefaultRecentCount = 10;
        private const int MaxRecentCount = 100;
        private const string Placeholder = "N/A";

        private readonly IDashboardRepository _repository;

        public DashboardController() : this(new DashboardRepository()) { }

        public DashboardController(IDashboardRepository repository)
        {
            _repository = repository;
        }

        public DashboardCounts GetCounts()
        {
            var counts = _repository.GetCounts();

            counts.AvailableRooms = Math.Max(0, counts.AvailableRooms);
            counts.Patients = Math.Max(0, counts.Patients);
            counts.Users = Math.Max(0, counts.Users);
            return counts;
        }

        public List<AdmissionRecord> GetRecentAdmissions(int count = DefaultRecentCount)
        {
            if (count < 1) count = DefaultRecentCount;
            if (count > MaxRecentCount) count = MaxRecentCount;

            var records = _repository.GetRecentAdmissions(count);

            foreach (var r in records)
            {
                r.Doctor = string.IsNullOrWhiteSpace(r.Doctor) ? Placeholder : r.Doctor;
                r.Room = string.IsNullOrWhiteSpace(r.Room) ? Placeholder : r.Room;
                r.Type = string.IsNullOrWhiteSpace(r.Type) ? Placeholder : r.Type;
                r.Reason = string.IsNullOrWhiteSpace(r.Reason) ? Placeholder : r.Reason;
            }
            return records;
        }
    }
}
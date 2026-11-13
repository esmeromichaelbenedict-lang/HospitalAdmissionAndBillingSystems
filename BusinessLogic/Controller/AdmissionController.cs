using HospitalPRAC.BusinessLogic.Repository;
using HospitalPRAC.Model;

namespace HospitalPRAC.BusinessLogic.Controller
{
    /// <summary>
    /// Business logic for admitting an existing patient: searching patients,
    /// loading the Room Type, Room and Bed dropdowns, checking the admission details,
    /// and keeping the service list free of duplicates.
    /// </summary>
    public class AdmissionController
    {
        private readonly IAdmissionRepository _admissions;
        private readonly IPatientRepository _patients;
        private readonly IRoomRepository _rooms;

        public AdmissionController()
            : this(new AdmissionRepository(), new PatientRepository(), new RoomRepository()) { }

        public AdmissionController(
            IAdmissionRepository admissions,
            IPatientRepository patients,
            IRoomRepository rooms)
        {
            _admissions = admissions;
            _patients = patients;
            _rooms = rooms;
        }

        // ---------- SEARCH ----------

        public List<PatientRecord> SearchPatients(string search)
        {
            return _patients.GetPatients((search ?? string.Empty).Trim());
        }

        // ---------- DROPDOWN DATA ----------

        public List<DoctorItem> GetDoctors() => _admissions.GetDoctors();
        public List<AdmissionTypeItem> GetAdmissionTypes() => _admissions.GetAdmissionTypes();
        public List<ServiceItem> GetServices() => _admissions.GetServices();

        // Same Room Type -> Room -> Bed chain as the Room page: only rooms/beds that are still available.
        public List<string> GetRoomTypes() => _rooms.GetRoomTypes();
        public List<RoomOption> GetRooms(string roomType) => _rooms.GetAvailableRooms(roomType);
        public List<BedOption> GetBeds(int roomId) => _rooms.GetAvailableBeds(roomId);

        // ---------- SERVICES LIST ----------

        /// <summary>Adds a service to the list, unless nothing is chosen or it is already there.</summary>
        public OperationResult AddService(IList<ServiceItem> selected, ServiceItem? service)
        {
            if (service == null)
                return OperationResult.Fail("Please select a service first.");

            if (selected.Any(s => s.ServiceID == service.ServiceID))
                return OperationResult.Fail("This service is already added.");

            selected.Add(service);
            return OperationResult.Ok("Service added.");
        }

        public decimal GetServicesTotal(IEnumerable<ServiceItem> services)
        {
            return services.Sum(s => s.Price);
        }

        // ---------- ADMIT ----------

        public OperationResult AdmitPatient(AdmissionRequest request)
        {
            string? error = Validate(request);
            if (error != null)
                return OperationResult.Fail(error);

            request.Reason = request.Reason.Trim();

            try
            {
                _admissions.AdmitPatient(request);
                return OperationResult.Ok("Patient admitted successfully!");
            }
            catch (InvalidOperationException ex)
            {
                // e.g. "That bed is no longer available."
                return OperationResult.Fail(ex.Message);
            }
            catch (Exception ex)
            {
                return OperationResult.Fail("Could not admit the patient: " + ex.Message);
            }
        }

        public string? Validate(AdmissionRequest request)
        {
            if (request.PatientID <= 0)
                return "Please search and double-click a patient first.";

            if (string.IsNullOrWhiteSpace(request.Reason))
                return "Please enter the Reason for Admission.";

            if (request.Doctor == null)
                return "Please select an Admitting Doctor.";

            if (request.Room == null || request.Bed == null)
                return "Please select a Room and a Bed.";

            if (request.AdmissionType == null)
                return "Please select an Admission Type.";

            return null;
        }
    }
}
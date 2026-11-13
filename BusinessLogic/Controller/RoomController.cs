using HospitalPRAC.BusinessLogic.Repository;
using HospitalPRAC.Model;

namespace HospitalPRAC.BusinessLogic.Controller
{
 
    public class RoomController
    {
        private readonly IRoomRepository _repository;

        public RoomController() : this(new RoomRepository()) { }

        public RoomController(IRoomRepository repository)
        {
            _repository = repository;
        }

        public List<AdmittedPatientRow> GetAdmittedPatients(string keyword)
            => _repository.GetAdmittedPatients((keyword ?? string.Empty).Trim());

        public List<string> GetRoomTypes() => _repository.GetRoomTypes();

        public List<RoomOption> GetRooms(string roomType) => _repository.GetAvailableRooms(roomType);

        public List<BedOption> GetBeds(int roomId) => _repository.GetAvailableBeds(roomId);

        public List<RoomTransferRecord> GetTransferHistory(AdmittedPatientRow patient)
        {
            List<RoomTransferRecord> history =
                _repository.GetTransferHistory(patient.AdmissionId, patient.PatientID)
                           .OrderBy(h => h.TransferredOn)
                           .ToList();

            DateTime? stayStart = patient.Admitted == DateTime.MinValue ? null : patient.Admitted;
            foreach (RoomTransferRecord row in history)
            {
                row.StayedFrom = stayStart;
                stayStart = row.TransferredOn;
            }
            return history;
        }

        public OperationResult Transfer(TransferRequest request)
        {
            string? error = Validate(request);
            if (error != null)
                return OperationResult.Fail(error);

            request.Reason = request.Reason.Trim();

            try
            {
                _repository.TransferPatient(request);
                return OperationResult.Ok("Patient transferred.");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail(ex.Message);
            }
        }

        public string? Validate(TransferRequest request)
        {
            if (request.AdmissionId == 0)
                return "Click a patient and press Edit first.";

            if (request.NewBed == null || request.NewRoomId == 0)
                return "Select a room and bed.";

            if (string.IsNullOrWhiteSpace(request.Reason))
                return "Enter a reason.";

            if (request.CurrentBedId == request.NewBed.BedID)
                return "The patient is already in that bed.";

            if (request.TransferDateTime < request.AdmissionDate)
                return "Transfer date cannot be earlier than the admission date.";

            return null;
        }
    }
}
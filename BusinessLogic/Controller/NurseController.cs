using HospitalPRAC.BusinessLogic.Repository;
using HospitalPRAC.Model;

namespace HospitalPRAC.BusinessLogic.Controller
{
    /// <summary>Business rules for the Nurse dashboard.</summary>
    public class NurseController
    {
        private readonly INurseRepository _repository;

        public NurseController() : this(new NurseRepository()) { }

        public NurseController(INurseRepository repository)
        {
            _repository = repository;
        }

        public List<PatientListItem> SearchPatients(string? keyword)
            => _repository.SearchPatients((keyword ?? string.Empty).Trim());

        public NursePatientInfo? GetPatientInfo(int patientId)
            => _repository.GetPatientInfo(patientId);

        public List<MedicineItem> GetMedicines(string category)
            => _repository.GetMedicines(category);

        /// <summary>Returns how many items were added. Throws InvalidOperationException if the rules fail.</summary>
        public int AddMedicines(int admissionId, IEnumerable<int> medicineIds)
        {
            if (admissionId <= 0)
                throw new InvalidOperationException("This patient has no admission to charge.");

            var ids = medicineIds.ToList();
            if (ids.Count == 0)
                throw new InvalidOperationException("You haven't selected anything.");

            return _repository.AddMedicines(admissionId, ids);
        }
    }
}
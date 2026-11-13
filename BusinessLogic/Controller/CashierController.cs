using HospitalPRAC.BusinessLogic.Repository;
using HospitalPRAC.Model;

namespace HospitalPRAC.BusinessLogic.Controller
{
    /// <summary>
    /// Business logic for the Cashier dashboard: searching patients and turning a patient
    /// (plus companion and latest admission) into the text the form displays.
    /// </summary>
    public class CashierController
    {
        private const string NotAvailable = "N/A";

        private readonly ICashierRepository _repository;

        public CashierController() : this(new CashierRepository()) { }

        public CashierController(ICashierRepository repository)
        {
            _repository = repository;
        }

        // ---------- SEARCH ----------

        // Empty keyword = all patients.
        public List<PatientRecord> SearchPatients(string keyword)
        {
            return _repository.SearchPatients((keyword ?? string.Empty).Trim());
        }

        // ---------- DETAILS OF THE SELECTED PATIENT ----------

        public PatientDetails GetDetails(PatientRecord patient)
        {
            CompanionInfo? companion = _repository.GetCompanion(patient.PatientID);
            AdmissionSummary? admission = _repository.GetLatestAdmission(patient.PatientID);

            var details = new PatientDetails();

            // Last name, with the suffix after it (e.g. "Santos Jr.")
            string suffix = Clean(patient.Suffix);
            details.LastName = Clean(patient.LastName) + (suffix != "" ? " " + suffix : "");
            details.FirstName = Clean(patient.FirstName);

            // Middle initial: first letter of the middle name
            string middle = Clean(patient.MiddleName);
            details.MiddleInitial = middle.Length > 0 ? middle.Substring(0, 1) + "." : "";

            // Birthdate and age: compute the age from the birthdate; if there is none, use the saved age.
            if (patient.DateOfBirth != DateTime.MinValue)
            {
                details.Birthdate = patient.DateOfBirth.ToString("MMM dd, yyyy");
                details.Age = ComputeAge(patient.DateOfBirth).ToString();
            }
            else
            {
                details.Birthdate = "";
                details.Age = patient.Age.ToString();
            }

            details.Sex = Clean(patient.Sex);
            details.Address = Clean(patient.Address);
            details.ContactNo = Clean(patient.ContactNumber);

            // Accompanying person (blank if the patient has none)
            if (companion != null)
            {
                details.AccName = Clean(companion.FullName);
                details.AccRelationship = Clean(companion.Relationship);
                details.AccContact = Clean(companion.ContactNumber);
            }

            // Bed information ("N/A" if never admitted, or no room/bed)
            if (admission != null)
            {
                details.RoomNo = OrNotAvailable(admission.RoomNumber);
                details.BedNo = OrNotAvailable(admission.BedNumber);
                details.AdmissionDate = admission.AdmissionDate.HasValue
                    ? admission.AdmissionDate.Value.ToString("MMM dd, yyyy")
                    : NotAvailable;
            }

            return details;
        }

        // ---------- helpers ----------

        public static int ComputeAge(DateTime birthdate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthdate.Year;
            if (birthdate.Date > today.AddYears(-age)) age--;
            return age;
        }

        private static string Clean(string? value)
        {
            return (value ?? string.Empty).Trim();
        }

        private static string OrNotAvailable(string? value)
        {
            return string.IsNullOrWhiteSpace(value) ? NotAvailable : value.Trim();
        }
    }
}
using HospitalPRAC.BusinessLogic.Repository;
using HospitalPRAC.Model;

namespace HospitalPRAC.BusinessLogic.Controller
{

    public class PatientController
    {
        private readonly IPatientRepository _repository;

        public PatientController() : this(new PatientRepository()) { }

        public PatientController(IPatientRepository repository)
        {
            _repository = repository;
        }

        public List<PatientRecord> GetPatients(string search = "")
        {
            return _repository.GetPatients((search ?? string.Empty).Trim());
        }


        public OperationResult AddPatient(PatientInput input)
        {
            string? error = Validate(input);
            if (error != null)
                return OperationResult.Fail(error);

            try
            {
                _repository.AddPatient(ToRecord(input, 0));
                return OperationResult.Ok("Patient added successfully!");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail("Could not add the patient: " + ex.Message);
            }
        }


        public OperationResult UpdatePatient(int patientId, PatientInput input)
        {
            if (patientId <= 0)
                return OperationResult.Fail("Please select a patient first.");

            string? error = Validate(input);
            if (error != null)
                return OperationResult.Fail(error);

            try
            {
                _repository.UpdatePatient(ToRecord(input, patientId));
                return OperationResult.Ok("Patient updated successfully!");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail("Could not update the patient: " + ex.Message);
            }
        }


        public OperationResult DeletePatient(int patientId)
        {
            if (patientId <= 0)
                return OperationResult.Fail("Please select a patient first.");

            try
            {
                _repository.DeletePatient(patientId);
                return OperationResult.Ok("Patient deleted successfully!");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail("Could not delete the patient: " + ex.Message);
            }
        }


        public string? Validate(PatientInput input)
        {
            if (string.IsNullOrWhiteSpace(input.LastName) || string.IsNullOrWhiteSpace(input.FirstName))
                return "Last Name and First Name are required.";

            if (string.IsNullOrWhiteSpace(input.Sex) || string.IsNullOrWhiteSpace(input.CivilStatus))
                return "Please select Sex and Civil Status.";

            if (input.DateOfBirth.Date > DateTime.Today)
                return "Date of birth cannot be in the future.";

            if (!int.TryParse(input.Age, out int age) || age < 0 || age > 130)
                return "Age must be a number from 0 to 130.";

            if (!string.IsNullOrWhiteSpace(input.Weight) &&
                (!decimal.TryParse(input.Weight, out decimal weight) || weight <= 0 || weight > 500))
                return "Weight must be a number in kg. Example: 65.5";

            if (!string.IsNullOrWhiteSpace(input.Height) &&
                (!decimal.TryParse(input.Height, out decimal height) || height < 30 || height > 272))
                return "Height must be a number in cm. Example: 170";

            if (string.IsNullOrWhiteSpace(input.CompanionName) &&
                (!string.IsNullOrWhiteSpace(input.CompanionRelationship) ||
                 !string.IsNullOrWhiteSpace(input.CompanionContact)))
                return "Please enter the Accompanying Person's full name.";

            return null;
        }

        public static string MakeFullName(PatientInput input)
        {
            string name = input.FirstName.Trim();

            if (!string.IsNullOrWhiteSpace(input.MiddleName))
                name += " " + input.MiddleName.Trim();

            name += " " + input.LastName.Trim();

            if (!string.IsNullOrWhiteSpace(input.Suffix))
                name += " " + input.Suffix.Trim();

            return name;
        }

        private static PatientRecord ToRecord(PatientInput input, int patientId)
        {
            return new PatientRecord
            {
                PatientID = patientId,
                FullName = MakeFullName(input),
                LastName = input.LastName.Trim(),
                FirstName = input.FirstName.Trim(),
                MiddleName = NullIfBlank(input.MiddleName),
                Suffix = NullIfBlank(input.Suffix),
                DateOfBirth = input.DateOfBirth.Date,
                Sex = input.Sex,
                CivilStatus = input.CivilStatus,
                Age = int.Parse(input.Age),
                Address = NullIfBlank(input.Address),
                ContactNumber = NullIfBlank(input.ContactNumber),
                Weight = string.IsNullOrWhiteSpace(input.Weight) ? null : decimal.Parse(input.Weight),
                Height = string.IsNullOrWhiteSpace(input.Height) ? null : decimal.Parse(input.Height),
                CompanionName = NullIfBlank(input.CompanionName),
                CompanionRelationship = NullIfBlank(input.CompanionRelationship),
                CompanionContact = NullIfBlank(input.CompanionContact)
            };
        }

        private static string? NullIfBlank(string? value)
        {
            return string.IsNullOrWhiteSpace(value) ? null : value.Trim();
        }
    }
}
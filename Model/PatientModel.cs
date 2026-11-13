namespace HospitalPRAC.Model
{
    public class PatientRecord
    {
        public int PatientID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public string? Suffix { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Sex { get; set; } = string.Empty;
        public string CivilStatus { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? ContactNumber { get; set; }
        public int Age { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }

        public string? CompanionName { get; set; }
        public string? CompanionRelationship { get; set; }
        public string? CompanionContact { get; set; }
    }
    public class PatientInput
    {
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string Suffix { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.Today;
        public string Sex { get; set; } = string.Empty;
        public string CivilStatus { get; set; } = string.Empty;
        public string Age { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
        public string Weight { get; set; } = string.Empty;
        public string Height { get; set; } = string.Empty;

        public string CompanionName { get; set; } = string.Empty;
        public string CompanionRelationship { get; set; } = string.Empty;
        public string CompanionContact { get; set; } = string.Empty;
    }
    public class OperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;

        public static OperationResult Ok(string message) => new() { Success = true, Message = message };
        public static OperationResult Fail(string message) => new() { Success = false, Message = message };
    }
}
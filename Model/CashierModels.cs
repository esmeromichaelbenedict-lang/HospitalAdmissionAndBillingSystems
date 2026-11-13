namespace HospitalPRAC.Model
{
    /// <summary>The accompanying person of a patient (from the Companion table).</summary>
    public class CompanionInfo
    {
        public string? FullName { get; set; }
        public string? Relationship { get; set; }
        public string? ContactNumber { get; set; }
    }

    /// <summary>The room, bed and date of a patient's latest admission.</summary>
    public class AdmissionSummary
    {
        public string? RoomNumber { get; set; }
        public string? BedNumber { get; set; }
        public DateTime? AdmissionDate { get; set; }
    }


    public class PatientDetails
    {
        // Patient Information
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string MiddleInitial { get; set; } = string.Empty;
        public string Birthdate { get; set; } = string.Empty;
        public string Age { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ContactNo { get; set; } = string.Empty;

        // Accompanying person
        public string AccName { get; set; } = string.Empty;
        public string AccRelationship { get; set; } = string.Empty;
        public string AccContact { get; set; } = string.Empty;

        // Bed Information
        public string RoomNo { get; set; } = "N/A";
        public string BedNo { get; set; } = "N/A";
        public string AdmissionDate { get; set; } = "N/A";
    }
}
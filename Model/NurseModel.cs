namespace HospitalPRAC.Model
{
    /// <summary>One row of the Patient List box on the Nurse dashboard.</summary>
    public class PatientListItem
    {
        public int PatientID { get; set; }
        public string FullName { get; set; } = string.Empty;

        public override string ToString() => FullName;   // the ListBox shows this
    }

    /// <summary>Everything the Nurse dashboard labels show for the double-clicked patient.</summary>
    public class NursePatientInfo
    {
        public int PatientID { get; set; }
        public int AdmissionId { get; set; }             // 0 = no admission
        public string FullName { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public string Sex { get; set; } = string.Empty;
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public int Age { get; set; }
        public string RoomType { get; set; } = "-";
        public string RoomNumber { get; set; } = "-";
        public string BedNumber { get; set; } = "-";
    }

    /// <summary>A medicine or supply in a combo box.</summary>
    public class MedicineItem
    {
        public int MedicineID { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public string Display => $"{Name} - ₱{Price:N2}";   // the ComboBox shows this
    }

    /// <summary>A medicine or supply the nurse already charged to an admission (used by billing).</summary>
    public class MedicineCharge
    {
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
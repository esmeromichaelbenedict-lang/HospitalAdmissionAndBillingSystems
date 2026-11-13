namespace HospitalPRAC.Model
{

    public class DoctorItem
    {
        public int DoctorID { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public decimal ConsultationFee { get; set; }

        public override string ToString() => DoctorName;
    }

    public class AdmissionTypeItem
    {
        public int AdmissionTypeID { get; set; }
        public string AdmissionTypeName { get; set; } = string.Empty;

        public override string ToString() => AdmissionTypeName;
    }

    public class ServiceItem
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public override string ToString() => ServiceName;
    }
    public class AdmissionRequest
    {
        public int PatientID { get; set; }
        public DateTime AdmissionDateTime { get; set; }
        public string Reason { get; set; } = string.Empty;
        public DoctorItem? Doctor { get; set; }
        public RoomOption? Room { get; set; }
        public BedOption? Bed { get; set; }
        public AdmissionTypeItem? AdmissionType { get; set; }
        public List<ServiceItem> Services { get; set; } = new();
    }
}
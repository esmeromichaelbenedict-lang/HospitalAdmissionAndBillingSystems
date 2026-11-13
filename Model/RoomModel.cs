namespace HospitalPRAC.Model
{
    public class AdmittedPatientRow
    {
        public int AdmissionId { get; set; }
        public int PatientID { get; set; }
        public string Patient { get; set; } = string.Empty;
        public string Room { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string? Bed { get; set; }
        public decimal Rate { get; set; }
        public DateTime Admitted { get; set; }
        public int RoomId { get; set; }
        public int? BedId { get; set; }
    }

    public class RoomOption
    {
        public int RoomID { get; set; }
        public string RoomNumber { get; set; } = string.Empty;

        public override string ToString() => RoomNumber;
    }

    public class BedOption
    {
        public int BedID { get; set; }
        public string BedNumber { get; set; } = string.Empty;
        public decimal DailyRate { get; set; }

        public override string ToString() => BedNumber;
    }
    public class RoomTransferRecord
    {
        public string FromRoom { get; set; } = string.Empty;
        public string? FromBed { get; set; }
        public decimal? FromRate { get; set; }

        public string ToRoom { get; set; } = string.Empty;
        public string? ToBed { get; set; }
        public decimal? ToRate { get; set; }

        public DateTime? StayedFrom { get; set; }
        public DateTime TransferredOn { get; set; }
        public string? Reason { get; set; }
    }
    public class TransferRequest
    {
        public int AdmissionId { get; set; }
        public int PatientId { get; set; }
        public int CurrentRoomId { get; set; }
        public int? CurrentBedId { get; set; }
        public DateTime AdmissionDate { get; set; }

        public int NewRoomId { get; set; }
        public BedOption? NewBed { get; set; }
        public DateTime TransferDateTime { get; set; }
        public string Reason { get; set; } = string.Empty;
    }
}
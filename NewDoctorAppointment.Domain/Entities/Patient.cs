using NewDoctorAppointment.Domain.Enums;


namespace NewDoctorAppointment.Domain.Entities
{
    public class Patient : UserBase
    {
        public IllnestTypes IllnestType { get; set; }
        public string? AdditionalInfo { get; set; }
        public string? Address { get; set; }
    }
}
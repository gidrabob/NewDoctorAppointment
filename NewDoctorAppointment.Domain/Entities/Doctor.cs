using NewDoctorAppointment.Domain.Enums;


namespace NewDoctorAppointment.Domain.Entities
{
    public class Doctor : UserBase
    {
        public DoctorTypes DoctorType { get; set; }
        public byte Experience { get; set; }
        public decimal Salary { get; set; }
    }
}

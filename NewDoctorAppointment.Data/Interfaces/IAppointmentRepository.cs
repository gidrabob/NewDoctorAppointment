using NewDoctorAppointment.Domain.Entities;

namespace NewDoctorAppointment.Data.Interfaces
{
    public interface IAppointmentRepository
    {
        Appointment GetAllByDoctor(Doctor doctor);
        Appointment GetAllByPatient(Patient patient);
    }
}
using NewDoctorAppointment.Data.Interfaces;
using NewDoctorAppointment.Data.Repositories;
using NewDoctorAppointment.Domain.Entities;
using NewDoctorAppointment.Service.Interfaces;

namespace NewDoctorAppointment.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorService(string appSettings, ISerializationService serializationService)
        {
            _doctorRepository = new DoctorRepository(appSettings, serializationService);
        }
        public Doctor Create(Doctor doctor)
        {
            return _doctorRepository.Create(doctor);
        }
        public bool Delete(int id)
        {
            return _doctorRepository.Delete(id);
        }
        public Doctor? Get(int id)
        {
            return _doctorRepository.GetById(id);
        }
        public IEnumerable<Doctor> GetAll()
        {
            var doctors = _doctorRepository.GetAll();
            //var doctorViewModels = doctors.Select(x => x.ConvertTo());
            return doctors;
        }
        public Doctor Update(int id, Doctor doctor)
        {
            return _doctorRepository.Update(id, doctor);
        }
    }
}
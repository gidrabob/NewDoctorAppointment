using NewDoctorAppointment.Data.Interfaces;
using NewDoctorAppointment.Domain.Entities;

namespace NewDoctorAppointment.Data.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        private readonly ISerializationService serializationService;
        public override string Path { get; set; }
        public override int LastId { get; set; }
        public DoctorRepository(string appSettings, ISerializationService serializationService) : base(appSettings, serializationService)
        {
            this.serializationService = serializationService;

            var result = ReadFromAppSettings();

            Path = result.Database.Doctors.Path;
            LastId = result.Database.Doctors.LastId;
        }
        public override void ShowInfo(Doctor source)
        {
            Console.WriteLine();
        }
        protected override void SaveLastId()
        {
            dynamic result = ReadFromAppSettings();

            result.Database.Doctors.LastId = LastId;

            serializationService.Serialize(AppSettings, result);
        }
    }
}
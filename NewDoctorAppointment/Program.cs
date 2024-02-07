using NewDoctorAppointment.Service.Interfaces;
using NewDoctorAppointment.Service;
using NewDoctorAppointment.Data.Interfaces;
using NewDoctorAppointment.Domain.Entities;
using NewDoctorAppointment.Data.Configuration;

namespace NewDoctorAppointment
{
    public class DoctorAppointment
    {
        private readonly IDoctorService _doctorService;
        public DoctorAppointment(string appSettings, ISerializationService serializationService)
        {
            _doctorService = new DoctorService(appSettings, serializationService);
        }
        public void Menu()
        {
            Console.WriteLine("Current doctors list:");
            var docs = _doctorService.GetAll();

            foreach (var doc in docs)
            {
                Console.WriteLine(doc.Name);
            }

            Console.WriteLine("Adding new doctor:");
            var newDoctor = new Doctor
            {
                Name = "Vasya",
                Surname = "Petrov",
                Experience = 20,
                DoctorType = Domain.Enums.DoctorTypes.Dentist
            };

            _doctorService.Create(newDoctor);

            Console.WriteLine("Current doctors list:");
            docs = _doctorService.GetAll();

            foreach (var doc in docs)
            {
                Console.WriteLine(doc.Name);
            }

        }
    }
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Select data format:");
            Console.WriteLine("Press 1 if you want Xml");
            Console.WriteLine("Press 2 if you want Json");

            int choice = Convert.ToInt32(Console.ReadLine());

            DoctorAppointment? doctorAppointment = null;

            while (true)
            {
                if (choice.Equals(1))
                {
                    doctorAppointment = new DoctorAppointment(Constants.XmlAppSettingsPath, new XmlDataSerializerService());
                    break;
                }
                else if (choice.Equals(2))
                {
                    doctorAppointment = new DoctorAppointment(Constants.JsonAppSettingsPath, new JsonDataSerializerService());
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong choice.");
                    choice = Convert.ToInt32(Console.ReadLine());
                }
            }
            doctorAppointment.Menu();
        }
    }
}
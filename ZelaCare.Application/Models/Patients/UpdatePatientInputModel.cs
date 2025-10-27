using ZelaCare.Core.ValueObjects;

namespace ZelaCare.Application.Models.Patients
{
    public class UpdatePatientInputModel
    {
        public UpdatePatientInputModel(
            string fullName,
            string? cpf,
            DateTime birthDate,
            string phone,
            string? email,
            Address? address,
            string emergencyContact,
            string emergencyPhone,
            bool isPrivate,
            HealthPlan? healthPlan)
        {
            FullName = fullName;
            CPF = cpf;
            BirthDate = birthDate;
            Phone = phone;
            Email = email;
            Address = address;
            EmergencyContact = emergencyContact;
            EmergencyPhone = emergencyPhone;
            IsPrivate = isPrivate;
            HealthPlan = healthPlan;
        }

        public string FullName { get; private set; }
        public string? CPF { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Phone { get; private set; }
        public string? Email { get; private set; }
        public Address? Address { get; private set; }
        public string EmergencyContact { get; private set; }
        public string EmergencyPhone { get; private set; }
        public bool IsPrivate { get; private set; }
        public HealthPlan? HealthPlan { get; private set; }
    }
}

using ZelaCare.Core.Shared;
using ZelaCare.Core.ValueObjects;

namespace ZelaCare.Core.Entities
{
    public class Patient : BaseEntity
    {
        private Patient() { }
        public Patient(string fullName, string cpf, DateTime birthDate, string phone, string email, Address? address, Guid clinicId, string emergencyContact, string emergencyPhone, bool isPrivate)
        {
            FullName = fullName;
            CPF = cpf;
            BirthDate = birthDate;
            Phone = phone;
            Email = email;
            Address = address;
            ClinicId = clinicId;
            EmergencyContact = emergencyContact;
            EmergencyPhone = emergencyPhone;
            IsPrivate = isPrivate;
            IsActive = true;
        }

        public string FullName { get; private set; }
        public string? CPF { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Phone { get; private set; }
        public string? Email { get; private set; }
        public Address? Address { get; private set; }
        public Guid ClinicId { get; private set; }
        public Clinic Clinic { get; private set; }
        public string EmergencyContact { get; private set; }
        public string EmergencyPhone { get; private set; }
        public bool IsPrivate { get; private set; }
        public bool IsActive { get; private set; }
        public HealthPlan HealthPlan { get; private set; }
    }
}

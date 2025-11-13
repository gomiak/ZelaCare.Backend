using ZelaCare.Core.Shared;
using ZelaCare.Core.ValueObjects;

namespace ZelaCare.Core.Entities
{
    public class Patient : BaseEntity
    {
        private Patient() { }
        public Patient(string fullName, string? cpf, DateTime birthDate, string phone, string? email, Address? address, Guid clinicId, string emergencyContact, string emergencyPhone, bool isPrivate)
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

        public string FullName { get; private set; } = default!;
        public string? CPF { get; private set; } = default!;
        public DateTime BirthDate { get; private set; } = default!;
        public string Phone { get; private set; } = default!;
        public string? Email { get; private set; } = default!;
        public Address? Address { get; private set; } = default!;
        public Guid ClinicId { get; private set; }
        public Clinic Clinic { get; private set; } = default!;
        public string EmergencyContact { get; private set; } = default!;
        public string EmergencyPhone { get; private set; } = default!;
        public bool IsPrivate { get; private set; } = false;
        public bool IsActive { get; private set; } = false;
        public HealthPlan HealthPlan { get; private set; } = default!;
    }
}

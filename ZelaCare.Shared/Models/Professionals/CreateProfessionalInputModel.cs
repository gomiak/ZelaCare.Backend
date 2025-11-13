using ZelaCare.Core.Entities;
using ZelaCare.Core.Enums;

namespace ZelaCare.Shared.Models.Professionals
{
    public class CreateProfessionalInputModel
    {
        public CreateProfessionalInputModel(string fullName, string phone, Specialty specialty, RegistryType? registryType, string? professionalRegistry, Guid userId)
        {
            FullName = fullName;
            Phone = phone;
            Specialty = specialty;
            RegistryType = registryType;
            ProfessionalRegistry = professionalRegistry;
            UserId = userId;
        }

        public string FullName { get; private set; }
        public string Phone { get; private set; }
        public Specialty Specialty { get; private set; }
        public RegistryType? RegistryType { get; private set; }
        public string? ProfessionalRegistry { get; private set; }
        public Guid UserId { get; private set; }

        public Professional ToEntity() => new(FullName, Phone, Specialty, ProfessionalRegistry, RegistryType, UserId);
    }
}

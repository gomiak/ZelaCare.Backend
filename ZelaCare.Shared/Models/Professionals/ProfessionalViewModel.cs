using ZelaCare.Core.Entities;
using ZelaCare.Core.Enums;

namespace ZelaCare.Shared.Models.Professionals
{
    public class ProfessionalViewModel
    {
        public ProfessionalViewModel(string fullName, string phone, Specialty specialty, RegistryType? registryType, string? professionalRegistry, Guid userId)
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
        public User User { get; private set; }

        public ProfessionalViewModel FromEntity(Professional professional) => new(professional.FullName, professional.Phone, professional.Specialty, professional.RegistryType, professional.ProfessionalRegistry, professional.UserId);
    }
}

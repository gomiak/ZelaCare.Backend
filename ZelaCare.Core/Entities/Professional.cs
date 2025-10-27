using ZelaCare.Core.Enums;
using ZelaCare.Core.Shared;

namespace ZelaCare.Core.Entities
{
    public class Professional : BaseEntity
    {
        public Professional(string fullName, string phone, Specialty specialty, string? professionalRegistry, RegistryType? registryType, Guid userId)
        {
            FullName = fullName;
            Phone = phone;
            Specialty = specialty;
            ProfessionalRegistry = professionalRegistry;
            RegistryType = registryType;
            UserId = userId;
        }

        public string FullName { get; private set; }
        public string Phone { get; private set; }
        public Specialty Specialty { get; private set; }
        public RegistryType? RegistryType { get; private set; }
        public string? ProfessionalRegistry { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }

    }
}

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

        public string FullName { get; private set; } = default!;
        public string Phone { get; private set; } = default!;
        public Specialty Specialty { get; private set; } = default!;
        public RegistryType? RegistryType { get; private set; } = default!;
        public string? ProfessionalRegistry { get; private set; } = default!;
        public Guid UserId { get; private set; }
        public User User { get; private set; } = default!;

    }
}

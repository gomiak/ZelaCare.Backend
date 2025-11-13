using ZelaCare.Core.Enums;

namespace ZelaCare.Shared.Models.Professionals
{
    public class UpdateProfessionalInputModel
    {
        public UpdateProfessionalInputModel(string phone, Specialty specialty, RegistryType? registryType, string? professionalRegistry)
        {
            Phone = phone;
            Specialty = specialty;
            RegistryType = registryType;
            ProfessionalRegistry = professionalRegistry;
        }

        public string FullName { get; private set; }
        public string Phone { get; private set; }
        public Specialty Specialty { get; private set; }
        public RegistryType? RegistryType { get; private set; }
        public string? ProfessionalRegistry { get; private set; }
    }
}

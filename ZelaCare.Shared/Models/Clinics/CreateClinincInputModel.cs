using ZelaCare.Core.Entities;

namespace ZelaCare.Shared.Models.Clinics
{
    public class CreateClinincInputModel
    {
        public CreateClinincInputModel(string name, string? cnpj, string phone)
        {
            Name = name;
            CNPJ = cnpj;
            Phone = phone;
        }

        public string Name { get; private set; }
        public string? CNPJ { get; private set; }
        public string Phone { get; private set; }

        public Clinic ToEntity() => new Clinic(Name, CNPJ, Phone);
    }
}

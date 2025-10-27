using ZelaCare.Core.Entities;

namespace ZelaCare.Shared.Models.Clinics
{
    public class ClinicViewModel
    {
        public ClinicViewModel(string name, string? cnpj, string phone)
        {
            Name = name;
            CNPJ = cnpj;
            Phone = phone;
        }

        public string Name { get; private set; }
        public string? CNPJ { get; private set; }
        public string Phone { get; private set; }
        //public Address? Address { get; private set; }
        //public List<User> Users { get; private set; }

        public static ClinicViewModel FromEntity(Clinic clinic) => new ClinicViewModel(clinic.Name, clinic.CNPJ, clinic.Phone);
    }
}

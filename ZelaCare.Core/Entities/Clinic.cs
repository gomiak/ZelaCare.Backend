using ZelaCare.Core.Shared;
using ZelaCare.Core.ValueObjects;

namespace ZelaCare.Core.Entities
{
    public class Clinic : BaseEntity
    {
        private Clinic()
        {
            Users = new List<User>();
            Patients = new List<Patient>();
        }
        public Clinic(string name, string? cnpj, string phone)
        {
            Name = name;
            CNPJ = cnpj;
            Phone = phone;
        }

        public string Name { get; private set; }
        public string? CNPJ { get; private set; }
        public string Phone { get; private set; }
        public Address? Address { get; private set; }
        public List<User> Users { get; private set; }
        public List<Patient> Patients { get; private set; }
        public void SetAddress(Address address)
        {
            Address = address;
        }
    }
}

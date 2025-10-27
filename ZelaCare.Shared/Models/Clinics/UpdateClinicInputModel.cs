namespace ZelaCare.Shared.Models.Clinics
{
    public class UpdateClinicInputModel
    {
        public UpdateClinicInputModel(string name, string? cnpj, string phone)
        {
            Name = name;
            CNPJ = cnpj;
            Phone = phone;
        }

        public string Name { get; private set; }
        public string? CNPJ { get; private set; }
        public string Phone { get; private set; }
    }
}

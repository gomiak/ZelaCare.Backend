using ZelaCare.Core.Entities;

namespace ZelaCare.Core.Repositories
{
    public interface IPatientRepository
    {
        Task<Patient?> GetByIdAsync(Guid id);
        Task<Patient?> GetByCpfAsync(string cpf);
        Task<List<Patient>> GetByClinicIdAsync(Guid clinicId);
        Task AddAsync(Patient patient);
        Task UpdateAsync(Patient patient);
        Task<List<Patient>> SearchByNameAsync(string name, Guid clinicId);
        Task<Patient?> GetByEmailAsync(string email);
    }
}

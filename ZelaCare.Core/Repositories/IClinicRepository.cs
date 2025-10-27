using ZelaCare.Core.Entities;

namespace ZelaCare.Core.Repositories
{
    public interface IClinicRepository
    {
        Task<Clinic?> GetByIdAsync(Guid id);
        Task<Clinic?> GetByCnpjAsync(string cnpj);
        Task<List<Clinic>> GetAllAsync();
        Task<Guid> AddAsync(Clinic clinic);
        Task UpdateAsync(Clinic clinic);
    }
}

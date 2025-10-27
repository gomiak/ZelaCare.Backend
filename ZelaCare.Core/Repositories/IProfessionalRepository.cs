using ZelaCare.Core.Entities;

namespace ZelaCare.Core.Repositories
{
    public interface IProfessionalRepository
    {
        Task<Professional?> GetByIdAsync(Guid id);
        Task<Professional?> GetByUserIdAsync(Guid userId);
        Task<List<Professional>> GetByClinicIdAsync(Guid clinicId);
        Task<List<Professional>> GetBySpecialtyAsync(string specialty);
        Task AddAsync(Professional professional);
        Task UpdateAsync(Professional professional);
    }
}

using ZelaCare.Core.Entities;
using ZelaCare.Core.Enums;

namespace ZelaCare.Core.Repositories
{
    public interface IProfessionalRepository
    {
        Task<Professional?> GetByIdAsync(Guid id);
        Task<Professional?> GetByUserIdAsync(Guid userId);
        Task<List<Professional>> GetByClinicIdAsync(Guid clinicId);
        Task<List<Professional>> GetBySpecialtyAsync(Specialty specialty);
        Task<Guid> AddAsync(Professional professional);
        Task UpdateAsync(Professional professional);
    }
}

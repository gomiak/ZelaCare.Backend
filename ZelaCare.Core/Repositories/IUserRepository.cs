using ZelaCare.Core.Entities;

namespace ZelaCare.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(Guid id);
        Task<List<User>> GetByClinicIdAsync(Guid clinicId);
        Task<bool> Exists(Guid id);
        Task<Guid> AddAsync(User user);
        Task UpdateAsync(User user);
    }
}

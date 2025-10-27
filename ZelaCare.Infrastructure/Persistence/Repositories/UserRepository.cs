using Microsoft.EntityFrameworkCore;
using ZelaCare.Core.Entities;
using ZelaCare.Core.Repositories;

namespace ZelaCare.Infrastructure.Persistence.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly ZelaCareDbContext _context;
        public UserRepository(ZelaCareDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user.Id;

        }

        public async Task<bool> Exists(Guid id)
        {
            return await _context.Users.AnyAsync(u => u.Id == id);
        }

        public async Task<List<User>> GetByClinicIdAsync(Guid clinicId)
        {
            return await _context.Users
                .Include(u => u.Clinic)
                .Where(u => u.ClinicId == clinicId).ToListAsync();

        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);


        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateAsync(User user)
        {
             _context.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}

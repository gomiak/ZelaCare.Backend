using Microsoft.EntityFrameworkCore;
using ZelaCare.Core.Entities;
using ZelaCare.Core.Enums;
using ZelaCare.Core.Repositories;

namespace ZelaCare.Infrastructure.Persistence.Repositories
{
    public class ProfessionalRepository : IProfessionalRepository
    {
        private readonly ZelaCareDbContext _context;
        public ProfessionalRepository(ZelaCareDbContext context) 
        {
            _context = context;
        }
        public async Task<Guid> AddAsync(Professional professional)
        {
            await _context.AddAsync(professional);
            await _context.SaveChangesAsync();

            return professional.Id;
        }

        public async Task<List<Professional>> GetByClinicIdAsync(Guid clinicId)
        {
            return await _context.Professional.Where(p => !p.IsDeleted && p.User.ClinicId == clinicId)
                .Include(p => p.User)
                .ToListAsync();
        }

        public async Task<Professional?> GetByIdAsync(Guid id)
        {
            return await _context.Professional.Where(p => !p.IsDeleted && p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Professional>> GetBySpecialtyAsync(Specialty specialty)
        {
            return await _context.Professional.Where(p => !p.IsDeleted && p.Specialty == specialty)
                .ToListAsync();
              
        }

        public async Task<Professional?> GetByUserIdAsync(Guid userId)
        {
            return await _context.Professional.Where(p => !p.IsDeleted && p.User.Id == userId)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Professional professional)
        {
            _context.Update(professional);
            await _context.SaveChangesAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using ZelaCare.Core.Entities;
using ZelaCare.Core.Repositories;

namespace ZelaCare.Infrastructure.Persistence.Repositories
{
    internal class ClinicRepository : IClinicRepository
    {
        private readonly ZelaCareDbContext _context;
        public ClinicRepository(ZelaCareDbContext context)
        {
            _context = context;

        }
        public async Task<Guid> AddAsync(Clinic clinic)
        {

            await _context.Clinics.AddAsync(clinic);
            await _context.SaveChangesAsync();

            return clinic.Id;
        }

        public async Task<List<Clinic>> GetAllAsync()
        {
            return await _context.Clinics.Where(c => !c.IsDeleted).ToListAsync();
        }

        public async Task<Clinic?> GetByCnpjAsync(string cnpj)
        {
            return await _context.Clinics.FirstOrDefaultAsync(c => !c.IsDeleted && c.CNPJ.Equals(cnpj));
        }

        public async Task<Clinic?> GetByIdAsync(Guid id)
        {
            return await _context.Clinics.FirstOrDefaultAsync(c => !c.IsDeleted && c.Id == id);
        }

        public async Task UpdateAsync(Clinic clinic)
        {
            _context.Update(clinic);
            await _context.SaveChangesAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using ZelaCare.Core.Entities;
using ZelaCare.Core.Repositories;

namespace ZelaCare.Infrastructure.Persistence.Repositories
{
    internal class PatientRepository : IPatientRepository
    {
        private readonly ZelaCareDbContext _context;

        public PatientRepository(ZelaCareDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();

            return patient.Id;
        }

        public async Task UpdateAsync(Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }

        public async Task<Patient?> GetByIdAsync(Guid id)
        {
            return await _context.Patients
                .Where(p => !p.IsDeleted && p.Id == id)
                .Include(p => p.Address)
                .Include(p => p.HealthPlan)
                .FirstOrDefaultAsync();
        }

        public async Task<Patient?> GetByCpfAsync(string cpf)
        {
            return await _context.Patients
                .Where(p => !p.IsDeleted && p.CPF == cpf)
                .Include(p => p.Address)
                .Include(p => p.HealthPlan)
                .FirstOrDefaultAsync();
        }

        public async Task<Patient?> GetByEmailAsync(string email)
        {
            return await _context.Patients
                .Where(p => !p.IsDeleted && p.Email == email)
                .Include(p => p.Address)
                .Include(p => p.HealthPlan)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Patient>> GetByClinicIdAsync(Guid clinicId)
        {
            return await _context.Patients
                .Where(p => !p.IsDeleted && p.ClinicId == clinicId)
                .Include(p => p.Address)
                .Include(p => p.HealthPlan)
                .ToListAsync();
        }

        public async Task<List<Patient>> SearchByNameAsync(string name, Guid clinicId)
        {
            return await _context.Patients
                .Where(p => !p.IsDeleted && p.ClinicId == clinicId && p.FullName.Contains(name))
                .Include(p => p.Address)
                .Include(p => p.HealthPlan)
                .ToListAsync();
        }
    }
}

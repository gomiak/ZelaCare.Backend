using Microsoft.EntityFrameworkCore;
using ZelaCare.Core.Entities;

namespace ZelaCare.Infrastructure.Persistence
{
    public class ZelaCareDbContext : DbContext
    {
        public ZelaCareDbContext(DbContextOptions<ZelaCareDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ZelaCareDbContext).Assembly);

            base.OnModelCreating(builder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Professional> Professional { get; set; }
    }
}

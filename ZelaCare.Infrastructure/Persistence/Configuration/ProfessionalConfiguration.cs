using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZelaCare.Core.Entities;

namespace ZelaCare.Infrastructure.Persistence.Configuration
{
    public class ProfessionalConfiguration : IEntityTypeConfiguration<Professional>
    {
        public void Configure(EntityTypeBuilder<Professional> professional)
        {
            professional.HasKey(p => p.Id);

            professional.Property(p => p.FullName)
                .HasMaxLength(128);

            professional.Property(p => p.Phone)
               .HasMaxLength(15);

            professional.Property(p => p.RegistryType)
                .HasMaxLength(10);

            professional.Property(p => p.ProfessionalRegistry)
                .HasMaxLength(30);

            professional.Property(p => p.Specialty)
                .HasMaxLength(50);
        }
    }
}

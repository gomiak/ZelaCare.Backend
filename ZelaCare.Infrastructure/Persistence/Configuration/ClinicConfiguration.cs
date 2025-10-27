using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZelaCare.Core.Entities;

namespace ZelaCare.Infrastructure.Persistence.Configuration
{
    internal class ClinicConfiguration : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> clinic)
        {
            clinic.HasKey(c => c.Id);

            clinic.HasMany(c => c.Users)
                .WithOne(u => u.Clinic);

            clinic.Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();

            clinic.Property(c => c.CNPJ)
                .HasMaxLength(14)
                .IsRequired(false);

            clinic.HasIndex(c => c.CNPJ)
                .IsUnique();

            clinic.OwnsOne(c => c.Address, a => a.ConfigureAddress());

            clinic.Navigation(c => c.Address).IsRequired(false);
        }
    }
}

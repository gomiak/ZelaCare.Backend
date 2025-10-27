using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZelaCare.Core.Entities;

namespace ZelaCare.Infrastructure.Persistence.Configuration
{
    internal class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> patient)
        {
            patient.HasKey(p => p.Id);

            patient.HasOne(p => p.Clinic)
                .WithMany(c => c.Patients);

            patient.Property(p => p.FullName)
                .HasMaxLength(128);

            patient.Property(p => p.BirthDate)
                .HasColumnType("date");

            patient.Property(p => p.Phone)
                .HasMaxLength(15);

            patient.Property(p => p.EmergencyContact)
                .HasMaxLength(128);

            patient.Property(p => p.EmergencyPhone)
                .HasMaxLength(15);

            patient.Property(p => p.CPF)
                .HasMaxLength(11);

            patient.HasIndex(p => p.CPF)
                .IsUnique();



            patient.OwnsOne(p => p.Address, a => a.ConfigureAddress());
            patient.OwnsOne(p => p.HealthPlan, healthPlan =>
            {
                healthPlan.Property(h => h.Name)
                    .HasColumnName("HealthPlanName")
                    .HasMaxLength(100)
                    .IsRequired(false);

                healthPlan.Property(h => h.Number)
                    .HasColumnName("HealthPlanNumber")
                    .HasMaxLength(30)
                    .IsRequired(false);

                healthPlan.Property(h => h.HolderName)
                    .HasColumnName("HealthPlanHolderName")
                    .HasMaxLength(100)
                    .IsRequired(false);
            });
            patient.Navigation(p => p.Address).IsRequired(false);
            patient.Navigation(p => p.HealthPlan).IsRequired(false);


        }
    }
}

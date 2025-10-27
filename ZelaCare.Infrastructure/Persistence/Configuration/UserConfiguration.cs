using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZelaCare.Core.Entities;

namespace ZelaCare.Infrastructure.Persistence.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> user)
        {
            user.HasKey(u => u.Id);

            user.HasOne(u => u.Clinic)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.ClinicId)
                .OnDelete(DeleteBehavior.Restrict);

            user.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(150);

            user.Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(128);
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZelaCare.Core.ValueObjects;

namespace ZelaCare.Infrastructure.Persistence.Configuration
{
    internal static class AddressConfigurationExtensions
    {
        internal static OwnedNavigationBuilder<TEntity, Address> ConfigureAddress<TEntity>(
       this OwnedNavigationBuilder<TEntity, Address> address)
       where TEntity : class
        {
            address.Property(a => a.Street).HasMaxLength(100).IsRequired();
            address.Property(a => a.Number).HasMaxLength(10).IsRequired();
            address.Property(a => a.Complement).HasMaxLength(50);
            address.Property(a => a.City).HasMaxLength(50).IsRequired();
            address.Property(a => a.State).HasMaxLength(2).IsRequired();
            address.Property(a => a.ZipCode).HasMaxLength(8).IsRequired();

            return address;
        }
    }
}

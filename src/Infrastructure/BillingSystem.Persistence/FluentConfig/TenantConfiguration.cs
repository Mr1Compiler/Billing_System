using BillingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillingSystem.Persistence.FluentConfig;

public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        // Required 
        // Nullable is enabled in csproj so there is not need for 
        // writing any property.IsRequired(); 
        // EF will read that automatically from the entity class 

        // Length
        builder.Property(u => u.Name)
            .HasMaxLength(255);

        builder.Property(u => u.Address)
            .HasMaxLength(255);

        builder.Property(u => u.Domain)
            .HasMaxLength(255);

        builder.Property(u => u.Address)
            .HasMaxLength(255);

        builder.HasIndex(u => u.Name)
            .IsUnique();

        // Relations
    }
}
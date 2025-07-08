using BillingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillingSystem.Persistence.FluentConfig;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        // Required 
        // Nullable is enabled in csproj so there is not need for 
        // writing any property.IsRequired(); 
        // EF will read that automatically from the entity class


        // Length
        builder.Property(u => u.FirstName)
            .HasMaxLength(100);

        builder.Property(u => u.LastName)
            .HasMaxLength(100);

        builder.Property(u => u.Email)
            .HasMaxLength(255);

        builder.Property(u => u.Address)
            .HasMaxLength(255);

        builder.Property(u => u.PhoneNumber)
            .HasMaxLength(20);
        
        builder.Property(u => u.Address)
            .HasMaxLength(255);

        // Ignore 
        builder.Ignore(u => u.FullName);

        // Relations
        builder.HasOne(u => u.Tenant)
            .WithMany(u => u.Customers)
            .HasForeignKey(u => u.TenantId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
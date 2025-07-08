using BillingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillingSystem.Persistence.FluentConfig;

public class SubscriptionPlanConfiguration : IEntityTypeConfiguration<SubscriptionPlan>
{
    public void Configure(EntityTypeBuilder<SubscriptionPlan> builder)
    {
        // Required 
        // Nullable is enabled in csproj so there is not need for 
        // writing any property.IsRequired(); 
        // EF will read that automatically from the entity class 
        
        // Length
        builder.Property(u => u.Name)
            .HasMaxLength(150);
        
         builder.Property(u => u.Description)
            .HasMaxLength(1000);       
         
        // Relations
        builder.HasOne(u => u.Tenant)
            .WithMany(u => u.SubscriptionPlans)
            .HasForeignKey(u => u.TenantId)
            .OnDelete(DeleteBehavior.Restrict);
    }   
}
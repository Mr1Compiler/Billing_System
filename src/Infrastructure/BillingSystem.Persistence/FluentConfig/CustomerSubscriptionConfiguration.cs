using BillingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillingSystem.Persistence.FluentConfig;

public class CustomerSubscriptionConfiguration : IEntityTypeConfiguration<CustomerSubscription>
{
    public void Configure(EntityTypeBuilder<CustomerSubscription> builder)
    {
        // Required 
        // Nullable is enabled in csproj so there is not need for 
        // writing any property.IsRequired(); 
        // EF will read that automatically from the entity class 
        
        // Relations 
        builder.HasOne(u => u.Customer)
            .WithMany(u => u.CustomerSubscriptions)
            .HasForeignKey(u => u.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(u => u.SubscriptionPlan)
            .WithMany(u => u.CustomerSubscriptions)
            .HasForeignKey(u => u.SubscriptionPlanId)
            .OnDelete(DeleteBehavior.Restrict);
    }  
}
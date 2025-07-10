using System.ComponentModel.DataAnnotations.Schema;
using BillingSystem.Domain.Enums;

namespace BillingSystem.Domain.Entities;

public class CustomerSubscription
{
    public Guid Id { get; private set; }
    public DateTime StartDate { get; set; } = DateTime.UtcNow;
    public DateTime EndDate { get; set; }
    public SubscriptionStatus SubscriptionStatus { get; set; } = SubscriptionStatus.Pending;
    public bool IsRenewable { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    
    // Relations
    // Customer
    public Guid CustomerId { get; set; } // Foreign key
    public Customer Customer { get; set; } = null!;
    
    // Subscription  Plan
    public Guid SubscriptionPlanId { get; set; } // Foreign key
    public SubscriptionPlan SubscriptionPlan { get; set; } = null!;
}
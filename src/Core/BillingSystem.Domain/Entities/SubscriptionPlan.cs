using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BillingSystem.Domain.Enums;

namespace BillingSystem.Domain.Entities;

public class SubscriptionPlan
{
    public Guid Id { get; private set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public SubscriptionPlanStatus SubscriptionPlanStatus { get; set; } = SubscriptionPlanStatus.Draft;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    // public Currency Currency { get; set; } "*Review this feature*"


    // Relations 
    // Tenant  
    public Guid TenantId { get; set; } // Foreign Key 
    public Tenant Tenant { get; set; } = null!;

    // Customer Subscription   
    public List<CustomerSubscription> CustomerSubscriptions { get; set; } = null!;
}
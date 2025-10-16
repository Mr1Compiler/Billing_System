using BillingSystem.Domain.Enums;

namespace BillingSystem.Domain.Entities;

public class Tenant
{
    public Guid Id { get; private set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public TenantStatus TenantStatus { get; set; } = TenantStatus.Active;
    public string? Domain { get; set; } 
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
   
    // Relations 
    // Admins 
    public List<ApplicationUser> Admins { get; set; } = null!;
    
    // Relation with Customer
    public List<Customer> Customers { get; set; } = null!;
     
    // Relation with Plans
    public List<SubscriptionPlan> SubscriptionPlans { get; set; } = null!;
}
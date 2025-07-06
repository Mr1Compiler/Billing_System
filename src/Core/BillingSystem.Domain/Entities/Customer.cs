using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  BillingSystem.Domain.Entities;

public class Customer 
{
    public Guid Id { get; private set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string FullName => $"{FirstName}  + {LastName}"; // Get full name *Not Mapped (Ignore) 
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    
    // Relations
    // Tenant 
    public Guid TenantId { get; set; } // Foreign key
    public Tenant Tenant { get; set; } = null!;
    
    // Customer Subscription
    public List<CustomerSubscription> CustomerSubscriptions { get; set; } = null!;

}
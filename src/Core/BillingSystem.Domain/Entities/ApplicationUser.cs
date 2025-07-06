using BillingSystem.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace BillingSystem.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string FullName => $"{FirstName} + {LastName}"; // Ignore [NotMapped]
    public AdminStatus AdminStatus { get; set; } = AdminStatus.Active;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    
    // Relations 
    // Tenant
    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; } = null!;
}
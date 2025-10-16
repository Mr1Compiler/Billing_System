using BillingSystem.Domain.Enums;

namespace BillingSystem.Application.DTOs.V1.Tenants;

/*
    Read-only DTO for returning tenants details.
    No validation attributes needed.
*/
public class TenantDto
{
    public Guid Id { get; init; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string? Domain { get; set; } 
    public TenantStatus TenantStatus { get; set; }
    public DateTime CreatedAt { get; set; } 
    public DateTime UpdatedAt { get; set; }
}
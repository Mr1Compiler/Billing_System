using BillingSystem.Domain.Enums;

namespace BillingSystem.Application.DTOs.V1.Tenants;

/*
    Read-only DTO for returning tenants details.
    No validation attributes needed.
*/
public class TenantDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public TenantStatus TenantStatus { get; set; }
}
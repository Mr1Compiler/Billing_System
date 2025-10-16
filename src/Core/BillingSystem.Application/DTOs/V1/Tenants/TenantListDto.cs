namespace BillingSystem.Application.DTOs.V1.Tenants;

public record TenantListDto(
    Guid Id,
    string Name,
    string? Domain,
    string Address
);
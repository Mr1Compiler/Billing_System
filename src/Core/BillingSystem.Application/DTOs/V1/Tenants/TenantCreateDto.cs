namespace BillingSystem.Application.DTOs.V1.Tenants;

public record TenantCreateDto(
    string Name,
    string Address,
    string? Domain
);
namespace BillingSystem.Application.DTOs.V1.Tenants;

public record TenantUpdateDto(
    Guid Id,
    string? Name,
    string? Address,
    string? Domain
);
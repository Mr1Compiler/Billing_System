using BillingSystem.Domain.Enums;

namespace BillingSystem.Application.DTOs.V1.Tenants;

public record TenantDto(
    Guid Id,
    string Name,
    string Address,
    string? Domain,
    TenantStatus TenantStatus,
    DateTime CreatedAt,
    DateTime UpdatedAt
);
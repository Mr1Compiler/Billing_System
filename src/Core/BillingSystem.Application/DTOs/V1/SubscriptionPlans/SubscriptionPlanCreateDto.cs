using BillingSystem.Domain.Enums;

namespace BillingSystem.Application.DTOs.V1.SubscriptionPlans;

public record SubscriptionPlanCreateDto(
    string Name,
    decimal Price,
    string? Description,
    SubscriptionPlanStatus SubscriptionPlanStatus,
    Guid TenantId
);

using BillingSystem.Domain.Enums;

namespace BillingSystem.Application.DTOs.V1.SubscriptionPlans;

public record SubscriptionPlanUpdateDto(
    Guid Id,
    string? Name,
    decimal? Price,
    string? Description,
    SubscriptionPlanStatus? SubscriptionPlanStatus
);
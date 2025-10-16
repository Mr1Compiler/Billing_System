namespace BillingSystem.Application.DTOs.V1.SubscriptionPlans;

public record SubscriptionPlanListDto(
    Guid Id,
    string Name,
    decimal Price,
    string? Description
);
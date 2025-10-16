using BillingSystem.Domain.Enums;

namespace BillingSystem.Application.DTOs.V1.CustomerSubscriptions;

public record CustomerSubscriptionCreateDto(
    DateTime StartDate,
    DateTime EndDate,
    SubscriptionStatus SubscriptionStatus,
    bool IsRenewable,
    Guid CustomerId,
    Guid SubscriptionPlanId
);

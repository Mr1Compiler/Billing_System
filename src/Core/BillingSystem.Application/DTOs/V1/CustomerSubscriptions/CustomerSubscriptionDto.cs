using BillingSystem.Domain.Enums;

namespace BillingSystem.Application.DTOs.V1.CustomerSubscriptions;

public record CustomerSubscriptionDto(
    Guid Id,
    DateTime StartDate,
    DateTime EndDate,
    SubscriptionStatus SubscriptionStatus,
    bool IsRenewable,
    DateTime CreatedAt,
    DateTime UpdatedAt
);

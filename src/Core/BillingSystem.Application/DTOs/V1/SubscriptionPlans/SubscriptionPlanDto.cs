using BillingSystem.Domain.Enums;

namespace BillingSystem.Application.DTOs.V1.SubscriptionPlans;
/*
    Read-only DTO for returning SubscriptionPlans details.
    No validation attributes needed.
*/
public class SubscriptionPlanDto
{
    public Guid Id { get; private set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public SubscriptionPlanStatus SubscriptionPlanStatus { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
using BillingSystem.Domain.Enums;

namespace BillingSystem.Application.DTOs.V1.SubscriptionPlans;

public class SubscriptionPlanCreateDto
{
    public Guid Id { get; private set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public SubscriptionPlanStatus SubscriptionPlanStatus { get; set; }
    public Guid TenantId { get; set; }
}
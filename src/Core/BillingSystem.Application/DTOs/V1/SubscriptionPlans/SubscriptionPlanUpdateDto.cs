using BillingSystem.Domain.Enums;

namespace BillingSystem.Application.DTOs.V1.SubscriptionPlans;

public class SubscriptionPlanUpdateDto
{
    public Guid Id { get; init; }
    public string? Name { get; set; } = null!;
    public decimal? Price { get; set; }
    public string? Description { get; set; }
    public SubscriptionPlanStatus? SubscriptionPlanStatus { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; } 
}
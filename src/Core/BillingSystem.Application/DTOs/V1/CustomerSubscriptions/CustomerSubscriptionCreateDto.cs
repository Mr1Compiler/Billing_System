using BillingSystem.Domain.Enums;

namespace BillingSystem.Application.DTOs.V1.CustomerSubscriptions;

public class CustomerSubscriptionCreateDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public SubscriptionStatus SubscriptionStatus { get; set; }
    public bool IsRenewable { get; set; }
    public Guid CustomerId { get; set; }
    public Guid SubscriptionPlanId { get; set; }
}
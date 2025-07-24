using BillingSystem.Domain.Enums;

namespace BillingSystem.Application.DTOs.V1.CustomerSubscriptions;

public class CustomerSubscriptionListDto
{
    public Guid Id { get; init; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public SubscriptionStatus SubscriptionStatus { get; set; }
    public bool IsRenewable { get; set; }
}
using BillingSystem.Domain.Enums;

namespace BillingSystem.Application.DTOs.V1.CustomerSubscriptions;

/*
    Read-only DTO for returning CustomerSubscriptions details.
    No validation attributes needed.
*/
public class CustomerSubscriptionDto
{
    public Guid Id { get; private set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public SubscriptionStatus SubscriptionStatus { get; set; }
    public bool IsRenewable { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
 }
using BillingSystem.Domain.Entities;

namespace BillingSystem.Domain.Interfaces;

public interface ISubscriptionPlanRepository
{
    Task<IEnumerable<SubscriptionPlan>> GetAllAsync();
    Task<SubscriptionPlan> GetByIdAsync(Guid id);
    Task<SubscriptionPlan> AddAsync(SubscriptionPlan subscriptionPlan);
    Task<SubscriptionPlan> UpdateAsync(SubscriptionPlan subscriptionPlan);
    Task<bool> DeleteAsync(Guid id); 
}
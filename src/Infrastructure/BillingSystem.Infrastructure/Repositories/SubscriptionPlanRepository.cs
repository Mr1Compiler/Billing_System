using BillingSystem.Domain.Entities;
using BillingSystem.Domain.Interfaces;

namespace BillingSystem.Infrastructure.Repositories;

public class SubscriptionPlanRepository : ISubscriptionPlanRepository
{
    public Task<IEnumerable<SubscriptionPlan>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<SubscriptionPlan> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<SubscriptionPlan> AddAsync(SubscriptionPlan subscriptionPlan)
    {
        throw new NotImplementedException();
    }

    public Task<SubscriptionPlan> UpdateAsync(SubscriptionPlan subscriptionPlan)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
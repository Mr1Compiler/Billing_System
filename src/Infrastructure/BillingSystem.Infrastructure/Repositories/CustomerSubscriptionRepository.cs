using BillingSystem.Domain.Entities;
using BillingSystem.Domain.Interfaces;

namespace BillingSystem.Infrastructure.Repositories;

public class CustomerSubscriptionRepository : ICustomerSubscriptionRepository
{
    public Task<IEnumerable<CustomerSubscription>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CustomerSubscription> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<CustomerSubscription> AddAsync(CustomerSubscription customerSubscription)
    {
        throw new NotImplementedException();
    }

    public Task<CustomerSubscription> UpdateAsync(CustomerSubscription customerSubscription)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
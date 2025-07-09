using BillingSystem.Domain.Entities;

namespace BillingSystem.Domain.Interfaces;

public interface ICustomerSubscriptionRepository
{
    Task<IEnumerable<CustomerSubscription>> GetAllAsync();
    Task<CustomerSubscription> GetByIdAsync(Guid id);
    Task<CustomerSubscription> AddAsync(CustomerSubscription customerSubscription);
    Task<CustomerSubscription> UpdateAsync(CustomerSubscription customerSubscription);
    Task<bool> DeleteAsync(Guid id);
}
using BillingSystem.Domain.Entities;
using BillingSystem.Domain.Interfaces;

namespace BillingSystem.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    public Task<IEnumerable<Customer>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Customer> AddAsync(Customer customer)
    {
        throw new NotImplementedException();
    }

    public Task<Customer> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Customer> UpdateAsync(Customer customer)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
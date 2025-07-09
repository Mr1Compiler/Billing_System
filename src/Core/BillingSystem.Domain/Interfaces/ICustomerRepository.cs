using BillingSystem.Domain.Entities;

namespace BillingSystem.Domain.Interfaces;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<Customer> AddAsync(Customer customer);
    Task<Customer> GetByIdAsync(Guid id);
    Task<Customer> UpdateAsync(Customer customer);
    Task<bool> DeleteAsync(Guid id);
}
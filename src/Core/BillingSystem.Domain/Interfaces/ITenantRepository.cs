using BillingSystem.Domain.Entities;

namespace BillingSystem.Domain.Interfaces;

public interface ITenantRepository
{
    Task<IEnumerable<Tenant>> GetAllAsync();
    Task<Tenant> GetByIdAsync(Guid id);
    Task<Tenant> AddAsync(Tenant tenant);
    Task<Tenant> UpdateAsync(Tenant tenant);
    Task<bool> DeleteAsync(Guid id);  
}
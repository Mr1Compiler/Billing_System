using BillingSystem.Domain.Entities;
using BillingSystem.Domain.Interfaces;

namespace BillingSystem.Infrastructure.Repositories;

public class TenantRepository : ITenantRepository
{
    public Task<IEnumerable<Tenant>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Tenant> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Tenant> AddAsync(Tenant tenant)
    {
        throw new NotImplementedException();
    }

    public Task<Tenant> UpdateAsync(Tenant tenant)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
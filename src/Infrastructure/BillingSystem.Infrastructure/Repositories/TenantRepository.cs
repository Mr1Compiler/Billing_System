using BillingSystem.Domain.Entities;
using BillingSystem.Domain.Interfaces;
using BillingSystem.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace BillingSystem.Infrastructure.Repositories;

public class TenantRepository : ITenantRepository
{
    private readonly ApplicationDbContext _dbContext;

    public TenantRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<Tenant>> GetAllAsync()
        => await _dbContext.Tenants.ToListAsync();
    
    public async Task<Tenant> GetByIdAsync(Guid id)
        => await _dbContext.Tenants.FirstOrDefaultAsync(u => u.Id == id);

    public async Task<Tenant> AddAsync(Tenant tenant)
    {
        var result = await _dbContext.Tenants.AddAsync(tenant);
        await _dbContext.SaveChangesAsync();
        return tenant;
    }

    public async Task<Tenant> UpdateAsync(Tenant tenant)
    {
        var result = _dbContext.Tenants.Update(tenant);
        await _dbContext.SaveChangesAsync();
        return tenant;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var tenant = await _dbContext.Tenants.FirstOrDefaultAsync(u => u.Id == id);

        if (tenant != null)
        {
            _dbContext.Tenants.Remove(tenant);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        return false;
    }
}
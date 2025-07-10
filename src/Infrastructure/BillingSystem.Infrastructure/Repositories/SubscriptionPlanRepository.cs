using BillingSystem.Domain.Entities;
using BillingSystem.Domain.Interfaces;
using BillingSystem.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace BillingSystem.Infrastructure.Repositories;

public class SubscriptionPlanRepository : ISubscriptionPlanRepository
{
    private readonly ApplicationDbContext _dbContext;

    public SubscriptionPlanRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<SubscriptionPlan>> GetAllAsync()
        => await _dbContext.SubscriptionPlans.ToListAsync();


    public async Task<SubscriptionPlan> GetByIdAsync(Guid id)
        => await _dbContext.SubscriptionPlans.FirstOrDefaultAsync(u => u.Id == id);

    public async Task<SubscriptionPlan> AddAsync(SubscriptionPlan subscriptionPlan)
    {
        var result = await _dbContext.SubscriptionPlans.AddAsync(subscriptionPlan);
        await _dbContext.SaveChangesAsync();
        return subscriptionPlan; 
    }

    public async Task<SubscriptionPlan> UpdateAsync(SubscriptionPlan subscriptionPlan)
    {
        var result = _dbContext.SubscriptionPlans.Update(subscriptionPlan);
        await _dbContext.SaveChangesAsync();
        return subscriptionPlan;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var subscriptionPlan = await _dbContext.SubscriptionPlans.FirstOrDefaultAsync(u => u.Id == id);
        
        if (subscriptionPlan != null)
        {
            _dbContext.SubscriptionPlans.Remove(subscriptionPlan);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        
        return false;
    }
}
using BillingSystem.Domain.Entities;
using BillingSystem.Domain.Interfaces;
using BillingSystem.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace BillingSystem.Infrastructure.Repositories;

public class CustomerSubscriptionRepository : ICustomerSubscriptionRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CustomerSubscriptionRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<CustomerSubscription>> GetAllAsync() 
        => await _dbContext.CustomerSubscriptions.ToListAsync();

    public async Task<CustomerSubscription> GetByIdAsync(Guid id)
        => await _dbContext.CustomerSubscriptions.FirstOrDefaultAsync(u => u.Id == id);

    public async Task<bool> ExistsAsync(Guid id)
        => await _dbContext.CustomerSubscriptions.AnyAsync(u => u.Id == id);

    public async Task<CustomerSubscription> AddAsync(CustomerSubscription customerSubscription)
    {
        var result = await _dbContext.CustomerSubscriptions.AddAsync(customerSubscription);
        await _dbContext.SaveChangesAsync();
        return customerSubscription;
    }

    public async Task<CustomerSubscription> UpdateAsync(CustomerSubscription customerSubscription)
    {
        var result = _dbContext.CustomerSubscriptions.Update(customerSubscription);
        await _dbContext.SaveChangesAsync();
        return customerSubscription;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var customerSubscription = await _dbContext.CustomerSubscriptions.FirstOrDefaultAsync(u => u.Id == id);

        if (customerSubscription != null)
        {
            _dbContext.CustomerSubscriptions.Remove(customerSubscription);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        return false;
    }
}
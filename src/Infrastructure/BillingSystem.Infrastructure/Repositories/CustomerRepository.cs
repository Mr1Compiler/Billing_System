using BillingSystem.Domain.Entities;
using BillingSystem.Domain.Interfaces;
using BillingSystem.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace BillingSystem.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CustomerRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Customer>> GetAllAsync() 
        => await _dbContext.Customers.ToListAsync();

    public async Task<bool> ExistsAsync(Guid id)
        => await _dbContext.Customers.AnyAsync(u => u.Id == id);

    public async Task<Customer> AddAsync(Customer customer)
    {
        var result = await _dbContext.Customers.AddAsync(customer);
        await _dbContext.SaveChangesAsync();
        return customer;
    }
    
    public async Task<Customer> GetByIdAsync(Guid id)
        => await _dbContext.Customers.FirstOrDefaultAsync(u => u.Id == id);

    public async Task<Customer> UpdateAsync(Customer customer)
    {
        var result = _dbContext.Customers.Update(customer);
        await _dbContext.SaveChangesAsync();
        return customer;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var customer = await _dbContext.Customers.FirstOrDefaultAsync(u => u.Id == id);
        
        if (customer != null)
        {
            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        
        return false;
    }
}
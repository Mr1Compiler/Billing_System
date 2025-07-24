using BillingSystem.Domain.Entities;
using BillingSystem.Domain.Interfaces;
using BillingSystem.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace BillingSystem.Infrastructure.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly ApplicationDbContext _dbContext;

    public AdminRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        => await _dbContext.Users.ToListAsync();

    public async Task<bool> ExistsAsync(Guid id)
        => await _dbContext.Users.AnyAsync(u => u.Id == id.ToString());

    public async Task<bool> ExistsByEmailAsync(string email)
        => await _dbContext.Users.AnyAsync(u => u.Email == email);

    public async Task<ApplicationUser> AddAsync(ApplicationUser admin)
    {
        var result = await _dbContext.Users.AddAsync(admin);
        await _dbContext.SaveChangesAsync();
        return admin;
    }

    public async Task<ApplicationUser?> GetByIdAsync(Guid id)
        => await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id.ToString());

    public async Task<ApplicationUser> UpdateAsync(ApplicationUser admin)
    {
        _dbContext.Users.Update(admin);
        await _dbContext.SaveChangesAsync();
        return admin;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var admin = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id.ToString());

        if (admin != null)
        {
            _dbContext.Users.Remove(admin);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        return false;
    }
}

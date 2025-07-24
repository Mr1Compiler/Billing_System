using BillingSystem.Domain.Entities;

namespace BillingSystem.Domain.Interfaces;

public interface IAdminRepository
{
    Task<IEnumerable<ApplicationUser>> GetAllAsync();
    Task<bool> ExistsAsync(Guid id);
    Task<bool> ExistsByEmailAsync(string email);
    Task<ApplicationUser> AddAsync(ApplicationUser admin);
    Task<ApplicationUser?> GetByIdAsync(Guid id);
    Task<ApplicationUser> UpdateAsync(ApplicationUser admin);
    Task<bool> DeleteAsync(Guid id);
}

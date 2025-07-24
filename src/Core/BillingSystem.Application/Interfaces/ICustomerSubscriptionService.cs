using BillingSystem.Application.DTOs.V1.CustomerSubscriptions;
using FluentResults;

namespace BillingSystem.Application.Interfaces;

public interface ICustomerSubscriptionService
{
    Task<Result<CustomerSubscriptionDto>> GetByIdAsync(Guid id);
    Task<Result<IEnumerable<CustomerSubscriptionListDto>>> GetAllAsync();
    Task<Result<CustomerSubscriptionDto>> CreateAsync(CustomerSubscriptionCreateDto dto);
    Task<Result<CustomerSubscriptionDto>> UpdateAsync(CustomerSubscriptionUpdateDto dto);
    Task<Result<bool>> DeleteAsync(Guid id);
}

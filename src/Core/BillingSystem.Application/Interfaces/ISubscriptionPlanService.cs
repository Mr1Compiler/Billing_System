using BillingSystem.Application.DTOs.V1.SubscriptionPlans;
using FluentResults;

namespace BillingSystem.Application.Interfaces;

public interface ISubscriptionPlanService
{
    Task<Result<SubscriptionPlanDto>> GetByIdAsync(Guid id);
    Task<Result<IEnumerable<SubscriptionPlanListDto>>> GetAllAsync();
    Task<Result<SubscriptionPlanDto>> CreateAsync(SubscriptionPlanCreateDto dto);
    Task<Result<SubscriptionPlanDto>> UpdateAsync(SubscriptionPlanUpdateDto dto);
    Task<Result<bool>> DeleteAsync(Guid id);
}

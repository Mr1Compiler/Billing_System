using AutoMapper;
using BillingSystem.Application.DTOs.V1.SubscriptionPlans;
using BillingSystem.Application.Interfaces;
using BillingSystem.Domain.Entities;
using BillingSystem.Domain.Interfaces;
using FluentResults;

namespace BillingSystem.Application.Services;

public class SubscriptionPlanService : ISubscriptionPlanService
{
    private readonly ISubscriptionPlanRepository _repository;
    private readonly IMapper _mapper;

    public SubscriptionPlanService(ISubscriptionPlanRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<SubscriptionPlanDto>> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
            return Result.Fail<SubscriptionPlanDto>("Plan not found");

        return Result.Ok(_mapper.Map<SubscriptionPlanDto>(entity));
    }

    public async Task<Result<IEnumerable<SubscriptionPlanListDto>>> GetAllAsync()
    {
        var list = await _repository.GetAllAsync();
        return Result.Ok(_mapper.Map<IEnumerable<SubscriptionPlanListDto>>(list));
    }

    public async Task<Result<SubscriptionPlanDto>> CreateAsync(SubscriptionPlanCreateDto dto)
    {
        var entity = _mapper.Map<SubscriptionPlan>(dto);
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;

        await _repository.AddAsync(entity);
        return Result.Ok(_mapper.Map<SubscriptionPlanDto>(entity));
    }

    public async Task<Result<SubscriptionPlanDto>> UpdateAsync(SubscriptionPlanUpdateDto dto)
    {
        var existing = await _repository.GetByIdAsync(dto.Id);
        if (existing == null)
            return Result.Fail<SubscriptionPlanDto>("Plan not found");

        if (!string.IsNullOrWhiteSpace(dto.Name))
            existing.Name = dto.Name;

        if (dto.Price.HasValue)
            existing.Price = dto.Price.Value;

        if (!string.IsNullOrWhiteSpace(dto.Description))
            existing.Description = dto.Description;

        if (dto.SubscriptionPlanStatus.HasValue)
            existing.SubscriptionPlanStatus = dto.SubscriptionPlanStatus.Value;

        existing.UpdatedAt = DateTime.UtcNow;

        var updated = await _repository.UpdateAsync(existing);
        return Result.Ok(_mapper.Map<SubscriptionPlanDto>(updated));
    }

    public async Task<Result<bool>> DeleteAsync(Guid id)
    {
        var exists = await _repository.ExistsAsync(id);
        if (!exists)
            return Result.Fail<bool>("Plan not found");

        var success = await _repository.DeleteAsync(id);
        return success ? Result.Ok(true) : Result.Fail<bool>("Failed to delete");
    }
}

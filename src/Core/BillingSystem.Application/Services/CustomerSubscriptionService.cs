using AutoMapper;
using BillingSystem.Application.DTOs.V1.CustomerSubscriptions;
using BillingSystem.Application.Interfaces;
using BillingSystem.Domain.Entities;
using BillingSystem.Domain.Interfaces;
using FluentResults;

namespace BillingSystem.Application.Services;

public class CustomerSubscriptionService : ICustomerSubscriptionService
{
    private readonly ICustomerSubscriptionRepository _repository;
    private readonly IMapper _mapper;

    public CustomerSubscriptionService(ICustomerSubscriptionRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<CustomerSubscriptionDto>> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
            return Result.Fail<CustomerSubscriptionDto>("Not found");

        var dto = _mapper.Map<CustomerSubscriptionDto>(entity);
        return Result.Ok(dto);
    }

    public async Task<Result<IEnumerable<CustomerSubscriptionListDto>>> GetAllAsync()
    {
        var list = await _repository.GetAllAsync();
        var dtoList = _mapper.Map<IEnumerable<CustomerSubscriptionListDto>>(list);
        return Result.Ok(dtoList);
    }

    public async Task<Result<CustomerSubscriptionDto>> CreateAsync(CustomerSubscriptionCreateDto dto)
    {
        var entity = _mapper.Map<CustomerSubscription>(dto);
        var result = await _repository.AddAsync(entity);
        return Result.Ok(_mapper.Map<CustomerSubscriptionDto>(result));
    }

    public async Task<Result<CustomerSubscriptionDto>> UpdateAsync(CustomerSubscriptionUpdateDto dto)
    {
        var existing = await _repository.GetByIdAsync(dto.Id);
        if (existing == null)
            return Result.Fail<CustomerSubscriptionDto>("Not found");

        if (dto.StartDate.HasValue) existing.StartDate = dto.StartDate.Value;
        if (dto.EndDate.HasValue) existing.EndDate = dto.EndDate.Value;
        if (dto.SubscriptionStatus.HasValue) existing.SubscriptionStatus = dto.SubscriptionStatus.Value;
        if (dto.IsRenewable.HasValue) existing.IsRenewable = dto.IsRenewable.Value;
        existing.UpdatedAt = DateTime.UtcNow;

        var updated = await _repository.UpdateAsync(existing);
        return Result.Ok(_mapper.Map<CustomerSubscriptionDto>(updated));
    }

    public async Task<Result<bool>> DeleteAsync(Guid id)
    {
        var exists = await _repository.ExistsAsync(id);
        if (!exists) return Result.Fail<bool>("Not found");

        var success = await _repository.DeleteAsync(id);
        return success ? Result.Ok(true) : Result.Fail<bool>("Failed to delete");
    }
}

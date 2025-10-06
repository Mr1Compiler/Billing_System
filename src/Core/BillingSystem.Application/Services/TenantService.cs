using AutoMapper;
using BillingSystem.Application.DTOs.V1.Tenants;
using BillingSystem.Application.Interfaces;
using BillingSystem.Domain.Entities;
using BillingSystem.Domain.Interfaces;
using FluentResults;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BillingSystem.Application.Services;

public class TenantService : ITenantService
{
    private readonly ITenantRepository _tenantRepository;
    private readonly IMapper _mapper;
    private readonly IServiceProvider _serviceProvider;

    public TenantService(ITenantRepository tenantRepository, IMapper mapper,
        IServiceProvider serviceProvider)
    {
        _tenantRepository = tenantRepository;
        _mapper = mapper;
        _serviceProvider = serviceProvider;
    }

    private IValidator<T> GetValidator<T>()
    {
        return _serviceProvider.GetRequiredService<IValidator<T>>();
    }

    public async Task<Result<TenantDto>> GetTenantByIdAsync(Guid id)
    {
        var tenant = await _tenantRepository.GetByIdAsync(id);
        if (tenant == null)
            return Result.Fail<TenantDto>("Tenant not found");

        var dto = _mapper.Map<TenantDto>(tenant);
        return Result.Ok(dto);
    }

    public async Task<Result<IEnumerable<TenantListDto>>> GetAllTenantsAsync()
    {
        var tenants = await _tenantRepository.GetAllAsync();
        if (!tenants.Any())
            return Result.Fail<IEnumerable<TenantListDto>>("No tenants found");

        var dtoList = _mapper.Map<IEnumerable<TenantListDto>>(tenants);
        return Result.Ok(dtoList);
    }

    public async Task<Result<TenantDto>> CreateTenantAsync(TenantCreateDto dto)
    {
        var validationResult = await GetValidator<TenantCreateDto>().ValidateAsync(dto);
        if (!validationResult.IsValid)
            return Result.Fail<TenantDto>("Invalid or missing fields");

        var entity = _mapper.Map<Tenant>(dto);
        await _tenantRepository.AddAsync(entity);

        var resultDto = _mapper.Map<TenantDto>(entity);
        return Result.Ok(resultDto);
    }

    public async Task<Result<TenantDto>> UpdateTenantAsync(TenantUpdateDto dto)
    {
        var validationResult = await GetValidator<TenantUpdateDto>().ValidateAsync(dto);
        if (!validationResult.IsValid)
            return Result.Fail<TenantDto>("Invalid or missing fields");

        var tenant = await _tenantRepository.GetByIdAsync(dto.Id);
        if (tenant == null)
            return Result.Fail<TenantDto>("Tenant not found");

        _mapper.Map(dto, tenant);
        tenant.UpdatedAt = DateTime.UtcNow;

        await _tenantRepository.UpdateAsync(tenant);

        var resultDto = _mapper.Map<TenantDto>(tenant);
        return Result.Ok(resultDto);
    }

    public async Task<Result<bool>> DeleteTenantAsync(Guid id)
    {
        var exists = await _tenantRepository.ExistsAsync(id);
        if (!exists)
            return Result.Fail<bool>("Tenant not found");

        var success = await _tenantRepository.DeleteAsync(id);
        return success ? Result.Ok(true) : Result.Fail<bool>("Failed to delete tenant");
    }
}

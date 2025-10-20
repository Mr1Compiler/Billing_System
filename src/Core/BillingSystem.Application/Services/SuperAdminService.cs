using AutoMapper;
using BillingSystem.Application.DTOs.V1.SuperAdmin;
using BillingSystem.Application.Interfaces;
using BillingSystem.Domain.Entities;
using BillingSystem.Domain.Interfaces;
using FluentResults;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BillingSystem.Application.Services;

public class SuperAdminService : ISuperAdminService
{
    private readonly ITenantRepository _tenantRepository;
    private readonly IAdminRepository _adminRepository;
    private readonly IServiceProvider _serviceProvider;
    private readonly IMapper _mapper;
    
    public SuperAdminService(ITenantRepository tenantRepository, IAdminRepository adminRepository, IServiceProvider serviceProvider, IMapper mapper)
    {
        _tenantRepository = tenantRepository;
        _adminRepository = adminRepository;
        _serviceProvider = serviceProvider;
        _mapper = mapper;
    }

    private IValidator<T> GetValidator<T>()
    {
        return _serviceProvider.GetRequiredService<IValidator<T>>();
    }

    public async Task<Result<TenantWithAdminDto>> RegisterAdminWithTenant(RegisterTenantWithSuperAdminDto registerDto)
    {
        var validationResult = await GetValidator<RegisterTenantWithSuperAdminDto>().ValidateAsync(registerDto);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors
                .Select(e => e.ErrorMessage);

            return Result.Fail(errors);
        }

        var tenant = _mapper.Map<Tenant>(registerDto);
        await _tenantRepository.AddAsync(tenant);

        var superAdminData = (registerDto, tenant.Id);
        var superAdmin = _mapper.Map<ApplicationUser>(superAdminData);
        await _adminRepository.AddAsync(superAdmin);

        var tenantWithAdminData = (superAdmin, tenant);
        var tenantWithAdminDto = _mapper.Map<TenantWithAdminDto>(tenantWithAdminData);

        return Result.Ok();
    }
}
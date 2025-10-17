using BillingSystem.Application.DTOs.V1.SuperAdmin;
using FluentResults;

namespace BillingSystem.Application.Interfaces;

public interface ISuperAdminService
{
    Task<Result<TenantWithAdminDto>> RegisterAdminWithTenant(RegisterTenantWithSuperAdminDto registerDto);
}
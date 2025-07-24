using BillingSystem.Application.DTOs.V1.Tenants;
using FluentResults;

namespace BillingSystem.Application.Interfaces;

public interface ITenantService
{
    Task<Result<TenantDto>> GetTenantByIdAsync(Guid id);
    Task<Result<IEnumerable<TenantListDto>>> GetAllTenantsAsync();
    Task<Result<TenantDto>> CreateTenantAsync(TenantCreateDto tenantCreateDto);
    Task<Result<TenantDto>> UpdateTenantAsync(TenantUpdateDto tenantUpdateDto);
    Task<Result<bool>> DeleteTenantAsync(Guid id);
}

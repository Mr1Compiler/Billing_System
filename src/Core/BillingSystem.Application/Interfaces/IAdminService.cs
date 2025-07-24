using BillingSystem.Application.DTOs.V1.Admins;
using FluentResults;

namespace BillingSystem.Application.Interfaces;

public interface IAdminService
{
    Task<Result<AdminDto>> GetAdminByIdAsync(Guid id);
    Task<Result<IEnumerable<AdminListDto>>> GetAllAdminsAsync();
    Task<Result<AdminDto>> CreateAdminAsync(AdminCreateDto adminCreateDto);
    Task<Result<AdminDto>> UpdateAdminAsync(AdminUpdateDto adminUpdateDto);
    Task<Result<bool>> DeleteAdminAsync(Guid id);
}
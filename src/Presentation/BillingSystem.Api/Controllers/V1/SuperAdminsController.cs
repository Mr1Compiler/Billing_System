using BillingSystem.Api.Common;
using BillingSystem.Application.DTOs.V1.Admins;
using BillingSystem.Application.DTOs.V1.SuperAdmin;
using BillingSystem.Application.Interfaces;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.Api.Controllers.V1;

[Authorize(Roles = "SuperAdmin")]
[ApiController]
[Route("api/v1/[controller]")]
public class SuperAdminsController : ControllerBase
{
    private readonly ISuperAdminService _superAdminService;
    private readonly IAdminService _adminService;
    public SuperAdminsController(ISuperAdminService superAdminService, IAdminService adminService)
    {
        _superAdminService = superAdminService;
        _adminService = adminService;
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ApiResponse<AdminDto>>> GetSuperAdminById(Guid id)
    {
        var admin = await _adminService.GetAdminByIdAsync(id);

        if (admin.IsFailed)
        {
            return NotFound(new ApiResponse<AdminDto>
            {
                Success = false,
                Message = ErrorMessage.GetErrorMessage(admin.ToResult()),
            });
        }

        return Ok(new ApiResponse<AdminDto>
        {
            Success = true,
            Message = "ok",
            Data = admin.Value
        });
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TenantWithAdminDto>> RegisterSuperAdmin(RegisterTenantWithSuperAdminDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new ApiResponse<TenantWithAdminDto>
            {
                Success = false,
                Message = "Something wrong happened make sure the data is correct"
            });
        }

        var newSuperAdmin = await _superAdminService.RegisterAdminWithTenant(dto);

        if (newSuperAdmin.IsFailed)
        {
            var errors = newSuperAdmin.Errors.Select(u => u.Message);

            return BadRequest(errors);
        }

        return Ok(new ApiResponse<TenantWithAdminDto>
        {
            Success = true,
            Message = "Admin created successfully",
            Data = newSuperAdmin.Value
        });
    }
}
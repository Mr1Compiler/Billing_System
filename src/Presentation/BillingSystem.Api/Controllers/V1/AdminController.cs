using BillingSystem.Api.Common;
using BillingSystem.Application.DTOs.V1.Admins;
using BillingSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.Api.Controllers.V1;

[ApiController]
[Route("api")]
public class AdminController : ControllerBase
{
       private readonly IAdminService _adminService;
    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpGet("Admins")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ApiResponse<IEnumerable<AdminListDto>>>> GetAllAdmins()
    {
        var admins = await _adminService.GetAllAdminsAsync();

        if (admins.IsFailed)
        {
            return BadRequest(new ApiResponse<IEnumerable<AdminListDto>>
            {
                Success = false,
                Message = ErrorMessage.GetErrorMessage(admins.ToResult()),
            });
        }

        return Ok(new ApiResponse<IEnumerable<AdminListDto>>
        {
            Success = true,
            Message = "ok",
            Data = admins.Value
        });
    }

    [HttpGet("Admin/{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ApiResponse<AdminDto>>> GetAdminById(Guid Id)
    {
        var admin = await _adminService.GetAdminByIdAsync(Id);

        if (admin.IsFailed)
        {
            return BadRequest(new ApiResponse<AdminDto>
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AdminDto>> CreateNewAdmin(AdminCreateDto dto)
    {
        var newAdmin = await _adminService.CreateAdminAsync(dto);

        if (newAdmin.IsFailed)
        {
            return BadRequest(new ApiResponse<AdminDto>
            {
                Success = false,
                Message = ErrorMessage.GetErrorMessage(newAdmin.ToResult()),
            });
        }

        return CreatedAtAction(nameof(GetAdminById),
            new { Id = newAdmin.Value.Id },
            new ApiResponse<AdminDto>
            {
                Success = true,
                Message = "Admin created successfully",
                Data = newAdmin.Value
            });
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)] 
    public async Task<ActionResult<AdminDto>> UpdateAdmin(AdminUpdateDto dto)
    {
        var updatedAdmin = await _adminService.UpdateAdminAsync(dto);

        if (updatedAdmin.IsFailed)
        {
            return BadRequest(new ApiResponse<AdminDto>
            {
                Success = false,
                Message = ErrorMessage.GetErrorMessage(updatedAdmin.ToResult()),
            });
        }

        return Ok(new ApiResponse<AdminDto>
        {
            Success = true,
            Message = "ok",
            Data = updatedAdmin.Value
        });
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<bool>> DeleteAdminr(Guid Id)
    {
        var deleted = await _adminService.DeleteAdminAsync(Id);

        if (deleted.IsFailed)
        {
            return BadRequest(new ApiResponse<bool>
            {
                Success = false,
                Message = ErrorMessage.GetErrorMessage(deleted.ToResult())
            });
        }

        return Ok(new ApiResponse<bool>
        {
            Success = true,
            Message = "ok",
            Data = deleted.Value,
        });
    }
}
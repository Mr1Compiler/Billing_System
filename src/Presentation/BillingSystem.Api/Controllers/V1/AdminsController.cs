using BillingSystem.Api.Common;
using BillingSystem.Application.DTOs.V1.Admins;
using BillingSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.Api.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class AdminsController : ControllerBase
{
    private readonly IAdminService _adminService;
    public AdminsController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ApiResponse<IEnumerable<AdminListDto>>>> GetAllAdmins()
    {
        var admins = await _adminService.GetAllAdminsAsync();

        if (admins.IsFailed)
        {
            return NotFound(new ApiResponse<IEnumerable<AdminListDto>>
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

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ApiResponse<AdminDto>>> GetAdminById(Guid id)
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
    public async Task<ActionResult<AdminDto>> CreateNewAdmin(AdminCreateDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new ApiResponse<AdminDto>
            {
                Success = false,
                Message = "Something wrong happened make sure the data is correct"
            });
        }
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
            new { id = newAdmin.Value.Id },
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
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AdminDto>> UpdateAdmin(AdminUpdateDto dto)
    {
        var updatedAdmin = await _adminService.UpdateAdminAsync(dto);

        if (updatedAdmin.IsFailed)
        {
            return NotFound(new ApiResponse<AdminDto>
            {
                Success = false,
                Message = ErrorMessage.GetErrorMessage(updatedAdmin.ToResult()),
            });
        }

        return Ok(new ApiResponse<AdminDto>
        {
            Success = true,
            Message = "Admin updated successfully",
            Data = updatedAdmin.Value
        });
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAdmin(Guid id)
    {
        var deleted = await _adminService.DeleteAdminAsync(id);

        if (deleted.IsFailed)
        {
            return NotFound(new ApiResponse<bool>
            {
                Success = false,
                Message = ErrorMessage.GetErrorMessage(deleted.ToResult())
            });
        }

        return NoContent();
    }
}
using BillingSystem.Api.Common;
using BillingSystem.Application.DTOs.V1.Tenants;
using BillingSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.Api.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class TenantsController : ControllerBase
{
    private readonly ITenantService _tenantService;
    public TenantsController(ITenantService tenantService)
    {
        _tenantService = tenantService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ApiResponse<IEnumerable<TenantListDto>>>> GetAllTenants()
    {
        var tenants = await _tenantService.GetAllTenantsAsync();

        if (tenants.IsFailed)
        {
            return NotFound(new ApiResponse<IEnumerable<TenantListDto>>
            {
                Success = false,
                Message = ErrorMessage.GetErrorMessage(tenants.ToResult()),
            });
        }

        return Ok(new ApiResponse<IEnumerable<TenantListDto>>
        {
            Success = true,
            Message = "ok",
            Data = tenants.Value
        });
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ApiResponse<TenantDto>>> GetTenantById(Guid id)
    {
        var tenant = await _tenantService.GetTenantByIdAsync(id);

        if (tenant.IsFailed)
        {
            return NotFound(new ApiResponse<TenantDto>
            {
                Success = false,
                Message = ErrorMessage.GetErrorMessage(tenant.ToResult()),
            });
        }

        return Ok(new ApiResponse<TenantDto>
        {
            Success = true,
            Message = "ok",
            Data = tenant.Value
        });
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TenantDto>> CreateNewTenant(TenantCreateDto dto)
    {
        var newTenant = await _tenantService.CreateTenantAsync(dto);

        if (newTenant.IsFailed)
        {
            return BadRequest(new ApiResponse<TenantDto>
            {
                Success = false,
                Message = ErrorMessage.GetErrorMessage(newTenant.ToResult()),
            });
        }

        return CreatedAtAction(nameof(GetTenantById),
            new { id = newTenant.Value.Id },
            new ApiResponse<TenantDto>
            {
                Success = true,
                Message = "Tenant created successfully",
                Data = newTenant.Value
            });
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TenantDto>> UpdateTenant(TenantUpdateDto dto)
    {
        var updatedTenant = await _tenantService.UpdateTenantAsync(dto);

        if (updatedTenant.IsFailed)
        {
            return NotFound(new ApiResponse<TenantDto>
            {
                Success = false,
                Message = ErrorMessage.GetErrorMessage(updatedTenant.ToResult()),
            });
        }

        return Ok(new ApiResponse<TenantDto>
        {
            Success = true,
            Message = "Tenant updated successfully",
            Data = updatedTenant.Value
        });
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteTenant(Guid id)
    {
        var deleted = await _tenantService.DeleteTenantAsync(id);

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

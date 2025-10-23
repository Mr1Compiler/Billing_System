using BillingSystem.Api.Common;
using BillingSystem.Application.DTOs.V1.SubscriptionPlans;
using BillingSystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.Api.Controllers.V1;

[Authorize(Roles = "SuperAdmin,Admin")]
[ApiController]
[Route("api/v1/[controller]")]
public class SubscriptionPlansController : ControllerBase
{
    private readonly ISubscriptionPlanService _subscriptionPlanService;
    public SubscriptionPlansController(ISubscriptionPlanService subscriptionPlanService)
    {
        _subscriptionPlanService = subscriptionPlanService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ApiResponse<IEnumerable<SubscriptionPlanListDto>>>> GetAllPlans()
    {
        var plans = await _subscriptionPlanService.GetAllAsync();

        return Ok(new ApiResponse<IEnumerable<SubscriptionPlanListDto>>
        {
            Success = true,
            Message = "ok",
            Data = plans.Value
        });
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ApiResponse<SubscriptionPlanDto>>> GetPlanById(Guid id)
    {
        var plan = await _subscriptionPlanService.GetByIdAsync(id);

        if (plan.IsFailed)
        {
            return NotFound(new ApiResponse<SubscriptionPlanDto>
            {
                Success = false,
                Message = ErrorMessage.GetErrorMessage(plan.ToResult()),
            });
        }

        return Ok(new ApiResponse<SubscriptionPlanDto>
        {
            Success = true,
            Message = "ok",
            Data = plan.Value
        });
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SubscriptionPlanDto>> CreateNewPlan(SubscriptionPlanCreateDto dto)
    {
        var newPlan = await _subscriptionPlanService.CreateAsync(dto);

        if (newPlan.IsFailed)
        {
            return BadRequest(new ApiResponse<SubscriptionPlanDto>
            {
                Success = false,
                Message = ErrorMessage.GetErrorMessage(newPlan.ToResult()),
            });
        }

        return CreatedAtAction(nameof(GetPlanById),
            new { id = newPlan.Value.Id },
            new ApiResponse<SubscriptionPlanDto>
            {
                Success = true,
                Message = "Subscription plan created successfully",
                Data = newPlan.Value
            });
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SubscriptionPlanDto>> UpdatePlan(SubscriptionPlanUpdateDto dto)
    {
        var updatedPlan = await _subscriptionPlanService.UpdateAsync(dto);

        if (updatedPlan.IsFailed)
        {
            return NotFound(new ApiResponse<SubscriptionPlanDto>
            {
                Success = false,
                Message = ErrorMessage.GetErrorMessage(updatedPlan.ToResult()),
            });
        }

        return Ok(new ApiResponse<SubscriptionPlanDto>
        {
            Success = true,
            Message = "Subscription plan updated successfully",
            Data = updatedPlan.Value
        });
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeletePlan(Guid id)
    {
        var deleted = await _subscriptionPlanService.DeleteAsync(id);

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

using BillingSystem.Api.Common;
using BillingSystem.Application.DTOs.V1.CustomerSubscriptions;
using BillingSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.Api.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class CustomerSubscriptionsController : ControllerBase
{
    private readonly ICustomerSubscriptionService _customerSubscriptionService;
    public CustomerSubscriptionsController(ICustomerSubscriptionService customerSubscriptionService)
    {
        _customerSubscriptionService = customerSubscriptionService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ApiResponse<IEnumerable<CustomerSubscriptionListDto>>>> GetAllSubscriptions()
    {
        var subscriptions = await _customerSubscriptionService.GetAllAsync();

        return Ok(new ApiResponse<IEnumerable<CustomerSubscriptionListDto>>
        {
            Success = true,
            Message = "ok",
            Data = subscriptions.Value
        });
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ApiResponse<CustomerSubscriptionDto>>> GetSubscriptionById(Guid id)
    {
        var subscription = await _customerSubscriptionService.GetByIdAsync(id);

        if (subscription.IsFailed)
        {
            return NotFound(new ApiResponse<CustomerSubscriptionDto>
            {
                Success = false,
                Message = ErrorMessage.GetErrorMessage(subscription.ToResult()),
            });
        }

        return Ok(new ApiResponse<CustomerSubscriptionDto>
        {
            Success = true,
            Message = "ok",
            Data = subscription.Value
        });
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CustomerSubscriptionDto>> CreateNewSubscription(CustomerSubscriptionCreateDto dto)
    {
        var newSubscription = await _customerSubscriptionService.CreateAsync(dto);

        if (newSubscription.IsFailed)
        {
            return BadRequest(new ApiResponse<CustomerSubscriptionDto>
            {
                Success = false,
                Message = ErrorMessage.GetErrorMessage(newSubscription.ToResult()),
            });
        }

        return CreatedAtAction(nameof(GetSubscriptionById),
            new { id = newSubscription.Value.Id },
            new ApiResponse<CustomerSubscriptionDto>
            {
                Success = true,
                Message = "Customer subscription created successfully",
                Data = newSubscription.Value
            });
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CustomerSubscriptionDto>> UpdateSubscription(CustomerSubscriptionUpdateDto dto)
    {
        var updatedSubscription = await _customerSubscriptionService.UpdateAsync(dto);

        if (updatedSubscription.IsFailed)
        {
            return NotFound(new ApiResponse<CustomerSubscriptionDto>
            {
                Success = false,
                Message = ErrorMessage.GetErrorMessage(updatedSubscription.ToResult()),
            });
        }

        return Ok(new ApiResponse<CustomerSubscriptionDto>
        {
            Success = true,
            Message = "Customer subscription updated successfully",
            Data = updatedSubscription.Value
        });
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteSubscription(Guid id)
    {
        var deleted = await _customerSubscriptionService.DeleteAsync(id);

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

using BillingSystem.Api.Common;
using BillingSystem.Application.DTOs.V1.Customers;
using BillingSystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.Api.Controllers.V1;

[Authorize(Roles = "SuperAdmin,Admin")]
[ApiController]
[Route("api/v1/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;
    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ApiResponse<IEnumerable<CustomerListDto>>>> GetAllCustomers()
    {
        var customers = await _customerService.GetAllCustomersAsync();

        if (customers.IsFailed)
        {
            return NotFound(new ApiResponse<IEnumerable<CustomerListDto>>
            {
                Success = false,
                Message = ErrorMessage.GetErrorMessage(customers.ToResult()),
            });
        }

        return Ok(new ApiResponse<IEnumerable<CustomerListDto>>
        {
            Success = true,
            Message = "ok",
            Data = customers.Value
        });
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ApiResponse<CustomerDto>>> GetCustomerById(Guid id)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id);

        if (customer.IsFailed)
        {
            return NotFound(new ApiResponse<CustomerDto>
            {
                Success = false,
                Message = ErrorMessage.GetErrorMessage(customer.ToResult()),
            });
        }

        return Ok(new ApiResponse<CustomerDto>
        {
            Success = true,
            Message = "ok",
            Data = customer.Value
        });
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CustomerDto>> CreateNewCustomer(CustomerCreateDto dto)
    {
        var newCustomer = await _customerService.CreateCustomerAsync(dto);

        if (newCustomer.IsFailed)
        {
            return BadRequest(new ApiResponse<CustomerDto>
            {
                Success = false,
                Message = ErrorMessage.GetErrorMessage(newCustomer.ToResult()),
            });
        }

        return CreatedAtAction(nameof(GetCustomerById),
            new { id = newCustomer.Value.Id },
            new ApiResponse<CustomerDto>
            {
                Success = true,
                Message = "Customer created successfully",
                Data = newCustomer.Value
            });
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CustomerDto>> UpdateCustomer(CustomerUpdateDto dto)
    {
        var updatedCustomer = await _customerService.UpdateCustomerAsync(dto);

        if (updatedCustomer.IsFailed)
        {
            return NotFound(new ApiResponse<CustomerDto>
            {
                Success = false,
                Message = ErrorMessage.GetErrorMessage(updatedCustomer.ToResult()),
            });
        }

        return Ok(new ApiResponse<CustomerDto>
        {
            Success = true,
            Message = "Customer updated successfully",
            Data = updatedCustomer.Value
        });
    }
    
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteCustomer(CustomerDeleteDto dto)
    {
        var deleted = await _customerService.DeleteCustomerAsync(dto);

        if(deleted.IsFailed)
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
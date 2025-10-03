using BillingSystem.Api.Common;
using BillingSystem.Application.DTOs.V1.Customers;
using BillingSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Services;

namespace BillingSystem.Api.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("customers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ApiResponse<IEnumerable<CustomerListDto>>>> GetAllCustomers()
    {
        var customers = await _customerService.GetAllCustomersAsync();

        if (customers.IsFailed)
        {
            return BadRequest(new ApiResponse<IEnumerable<CustomerListDto>>
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

    [HttpGet("customers/{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ApiResponse<CustomerDto>>> GetCustomerById(Guid Id)
    {
        var customer = await _customerService.GetCustomerByIdAsync(Id);

        if (customer.IsFailed)
        {
            return BadRequest(new ApiResponse<CustomerDto>
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
    [ProducesResponseType(StatusCodes.Status200OK)]
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
            new { Id = newCustomer.Value.Id },
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
    public async Task<ActionResult<CustomerUpdateDto>> UpdateCustomer(CustomerUpdateDto dto)
    {
        var updatedCustomer = await _customerService.UpdateCustomerAsync(dto);

        if (updatedCustomer.IsFailed)
        {
            return BadRequest(new ApiResponse<CustomerDto>
            {
                Success = false,
                Message = ErrorMessage.GetErrorMessage(updatedCustomer.ToResult()),
            });
        }

        return Ok(new ApiResponse<CustomerDto>
        {
            Success = true,
            Message = "ok",
            Data = updatedCustomer.Value
        });
    }
    
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CustomerDeleteDto>> DeleteCustomer(CustomerDeleteDto dto)
    {
        var deleted = await _customerService.DeleteCustomerAsync(dto);
        
        if(deleted.IsFailed)
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
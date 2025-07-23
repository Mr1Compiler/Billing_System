using BillingSystem.Application.DTOs.V1.Customers;
using BillingSystem.Domain.Entities;
using FluentResults;

namespace BillingSystem.Application.Interfaces;

public interface ICustomerService
{
    Task<Result<CustomerDto>> GetCustomerByIdAsync(Guid id);
    Task<Result<IEnumerable<CustomerListDto>>> GetAllCustomersAsync();
    Task<Result<CustomerCreateDto>> CreateCustomerAsync(CustomerCreateDto customerCreateDto);
    Task<Result<CustomerUpdateDto>> UpdateCustomerAsync(CustomerUpdateDto customerUpdateDto); 
    Task<Result<bool>> DeleteCustomerAsync(Guid id);
}
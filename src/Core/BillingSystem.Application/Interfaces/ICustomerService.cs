using BillingSystem.Application.DTOs.V1.Customers;
using BillingSystem.Domain.Entities;

namespace BillingSystem.Application.Interfaces;

public interface ICustomerService
{
    Task<CustomerDto> GetCustomerByIdAsync(Guid id);
    Task<IEnumerable<CustomerListDto>> GetAllCustomersAsync();
    Task<CustomerCreateDto> CreateCustomerAsync(CustomerCreateDto customerCreateDto);
    Task<CustomerUpdateDto> UpdateCustomerAsync(); 
    Task<bool> DeleteCustomerAsync(Guid id);
}
using AutoMapper;
using BillingSystem.Application.DTOs.V1.Customers;
using BillingSystem.Application.Interfaces;
using BillingSystem.Application.Validation;
using BillingSystem.Domain.Entities;
using BillingSystem.Domain.Interfaces;
using FluentResults;

namespace BillingSystem.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<Result<CustomerDto>> GetCustomerByIdAsync(Guid id)
    {
        var customer = await _customerRepository.GetByIdAsync(id); // Get customer 

        if (customer == null) // If customer is null then the id is not valid 
            return Result.Fail<CustomerDto>("Customer not found");

        var customerDto = _mapper.Map<CustomerDto>(customer); // Mapping here 
        return Result.Ok(customerDto);
    }

    public async Task<Result<IEnumerable<CustomerListDto>>> GetAllCustomersAsync()
    {
        var customers = await _customerRepository.GetAllAsync();

        if (!customers.Any())
            return Result.Fail<IEnumerable<CustomerListDto>>("No customers found");

        var customerListDto = _mapper.Map<IEnumerable<CustomerListDto>>(customers);
        return Result.Ok(customerListDto);
    }

    public async Task<Result<CustomerCreateDto>> CreateCustomerAsync(CustomerCreateDto customerCreateDto)
    {
        // I'll user validator later (FluentValidation)
        var customer = _mapper.Map<Customer>(customerCreateDto);
        await _customerRepository.AddAsync(customer);

        return Result.Ok(customerCreateDto);
    }

    public async Task<Result<CustomerUpdateDto>> UpdateCustomerAsync(CustomerUpdateDto customerUpdateDto)
    {
        // I'll user validator later (FluentValidation)

        // Check if customer exists
        var exists = await _customerRepository.ExistsAsync(customerUpdateDto.Id);
        if (!exists)
            return Result.Fail<CustomerUpdateDto>("Customer with the given ID does not exist");

        // Map and update
        var customer = _mapper.Map<Customer>(customerUpdateDto);
        await _customerRepository.UpdateAsync(customer);

        return Result.Ok(customerUpdateDto);
    }

    public async Task<Result<bool>> DeleteCustomerAsync(Guid id)
    {
        // Check if the customer exists
        var exists = await _customerRepository.ExistsAsync(id);
        if (!exists)
            return Result.Fail<bool>("Customer with the given ID does not exist");

        // Perform deletion
        var success = await _customerRepository.DeleteAsync(id);
        if (!success)
            return Result.Fail<bool>("Failed to delete customer");

        return Result.Ok(true);
    }
}
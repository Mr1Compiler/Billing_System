using AutoMapper;
using BillingSystem.Application.DTOs.V1.Customers;
using BillingSystem.Application.Interfaces;
using BillingSystem.Domain.Entities;
using BillingSystem.Domain.Interfaces;
using FluentResults;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BillingSystem.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    private readonly IServiceProvider _serviceProvider;
    private readonly IValidator<CustomerUpdateDto> _updateValidator;


    public CustomerService(ICustomerRepository customerRepository, IMapper mapper,
        IServiceProvider serviceProvider)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
        _serviceProvider = serviceProvider;
    }

    private IValidator<T> GetValidator<T>()
    {
        return _serviceProvider.GetRequiredService<IValidator<T>>();
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

    public async Task<Result<CustomerDto>> CreateCustomerAsync(CustomerCreateDto customerCreateDto)
    {
        var validationResult = await GetValidator<CustomerCreateDto>().ValidateAsync(customerCreateDto);
        if (!validationResult.IsValid)
            return Result.Fail<CustomerDto>("There are missing or invalid fields.");

        var customer = _mapper.Map<Customer>(customerCreateDto);
        await _customerRepository.AddAsync(customer);

        var resultDto = _mapper.Map<CustomerDto>(customer);
        return Result.Ok(resultDto);
    }

    public async Task<Result<CustomerDto>> UpdateCustomerAsync(CustomerUpdateDto dto)
    {
        var validationResult = await GetValidator<CustomerUpdateDto>().ValidateAsync(dto);

        if (!validationResult.IsValid)
            return Result.Fail<CustomerDto>("There are missing or invalid field");
        
        var customer = await _customerRepository.GetByIdAsync(dto.Id);

        customer.UpdatedAt = DateTime.UtcNow;

        await _customerRepository.UpdateAsync(customer);

        var resultDto = _mapper.Map<CustomerDto>(customer);
        return Result.Ok(resultDto);
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
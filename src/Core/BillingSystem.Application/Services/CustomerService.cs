using AutoMapper;
using BillingSystem.Application.DTOs.V1.Customers;
using BillingSystem.Application.Interfaces;
using BillingSystem.Application.Validation;
using BillingSystem.Domain.Entities;
using BillingSystem.Domain.Interfaces;
using FluentResults;
using FluentValidation;

namespace BillingSystem.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CustomerCreateDto> _validator;

    public CustomerService(ICustomerRepository customerRepository, IMapper mapper,
        IValidator<CustomerCreateDto> validator)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
        _validator = validator;
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
        var validationResult = await _validator.ValidateAsync(customerCreateDto);
        if (!validationResult.IsValid)
            return Result.Fail<CustomerDto>("There are missing or invalid fields.");

        var customer = _mapper.Map<Customer>(customerCreateDto);
        await _customerRepository.AddAsync(customer);

        var resultDto = _mapper.Map<CustomerDto>(customer);
        return Result.Ok(resultDto);
    }

    public async Task<Result<CustomerDto>> UpdateCustomerAsync(CustomerUpdateDto dto)
    {
        var customer = await _customerRepository.GetByIdAsync(dto.Id);
        if (customer == null)
            return Result.Fail<CustomerDto>("Customer with the given ID does not exist");

        if (!string.IsNullOrWhiteSpace(dto.FirstName))
            customer.FirstName = dto.FirstName;

        if (!string.IsNullOrWhiteSpace(dto.LastName))
            customer.LastName = dto.LastName;

        if (!string.IsNullOrWhiteSpace(dto.PhoneNumber))
            customer.PhoneNumber = dto.PhoneNumber;

        if (!string.IsNullOrWhiteSpace(dto.Address))
            customer.Address = dto.Address;

        if (dto.DateOfBirth.HasValue)
            customer.DateOfBirth = dto.DateOfBirth;
        
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
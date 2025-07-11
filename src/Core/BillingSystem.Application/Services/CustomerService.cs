using AutoMapper;
using BillingSystem.Application.DTOs.V1.Customers;
using BillingSystem.Application.Interfaces;
using BillingSystem.Domain.Entities;
using BillingSystem.Domain.Interfaces;

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
    
    public async Task<CustomerDto> GetCustomerByIdAsync(Guid id)
    {
        var customer = await _customerRepository.GetByIdAsync(id); // Get customer 
        var customerDto = _mapper.Map<CustomerDto>(customer); // Mapping here 
        return customerDto;
    }

    public async Task<IEnumerable<CustomerListDto>> GetAllCustomersAsync()
    {
        var customers = await _customerRepository.GetAllAsync();
        var customerListDto = _mapper.Map<IEnumerable<CustomerListDto>>(customers);
        return customerListDto;
    }

    public async Task<CustomerCreateDto> CreateCustomerAsync(CustomerCreateDto customerCreateDto)
    {
        // Dont forget to add validation
        var customer = _mapper.Map<Customer>(customerCreateDto);
        var result = await _customerRepository.AddAsync(customer);
        return customerCreateDto;
    }

    public Task<CustomerUpdateDto> UpdateCustomerAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteCustomerAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
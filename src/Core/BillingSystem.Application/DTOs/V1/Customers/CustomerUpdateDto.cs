using System.ComponentModel.DataAnnotations;

namespace BillingSystem.Application.DTOs.V1.Customers;

public class CustomerUpdateDto
{
    public Guid Id { get; init; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public string? Address { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace BillingSystem.Application.DTOs.V1.Customers;

// Don't forget to update the **updatedat** property 
public class CustomerUpdateDto
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Address { get; set; }
}
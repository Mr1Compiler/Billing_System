using System.ComponentModel.DataAnnotations;

namespace BillingSystem.Application.DTOs.V1.Customers;


// Don't forget to update the **updatedat** property 
public class CustomerUpdateDto
{
    public Guid Id { get; set; }
    [Required] public string FirstName { get; set; } = null!;
    [Required] public string LastName { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Address { get; set; } = null!;
}
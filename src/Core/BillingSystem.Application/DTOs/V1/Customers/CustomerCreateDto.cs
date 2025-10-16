namespace BillingSystem.Application.DTOs.V1.Customers;

public class CustomerCreateDto
{
    // public Guid Id { get; set; } ** backend generate the id (client dont need to sent it)
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public string Address { get; set; } = null!;
}
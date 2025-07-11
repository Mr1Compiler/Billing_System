namespace BillingSystem.Application.DTOs.V1.Customers;

public class CustomerListDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Address { get; set; } = null!;
}
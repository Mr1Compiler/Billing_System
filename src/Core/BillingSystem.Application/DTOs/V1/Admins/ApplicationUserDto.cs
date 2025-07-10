namespace BillingSystem.Application.DTOs.V1.Admins;

/*
    Read-only DTO for returning Admins details.
    No validation attributes needed.
*/
public class ApplicationUserDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Address { get; set; } = null!;
    public DateTime? DateOfBirth { get; set; }
}
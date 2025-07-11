using System.ComponentModel.DataAnnotations;

namespace BillingSystem.Application.DTOs.V1.Admins;

public class AdminCreateDto
{
    public Guid Id { get; set; }
    [Required] public string UserName { get; set; } = null!;
    [Required, EmailAddress] public string Email { get; set; } = null!;
    [Required] public string Password { get; set; } = null!;
    [Required] public string FirstName { get; set; } = null!;
    [Required] public string LastName { get; set; } = null!;
    [Required] public string Address { get; set; } = null!;
    public DateTime? DateOfBirth { get; set; }
}
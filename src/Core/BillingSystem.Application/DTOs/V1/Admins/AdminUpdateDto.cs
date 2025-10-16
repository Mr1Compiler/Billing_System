using System.ComponentModel.DataAnnotations;

namespace BillingSystem.Application.DTOs.V1.Admins;

public class AdminUpdateDto
{
    public Guid Id { get; init; }
    public string? UserName { get; set; } = null!;
    public string? Email { get; set; } = null!;
    public string? Password { get; set; } = null!;
    public string? FirstName { get; set; } = null!;
    public string? LastName { get; set; } = null!;
    public string? Address { get; set; } = null!;
    public DateOnly? DateOfBirth { get; set; }
}
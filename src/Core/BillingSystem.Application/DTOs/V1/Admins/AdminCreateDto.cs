using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace BillingSystem.Application.DTOs.V1.Admins;

public class AdminCreateDto
{
    public string UserName { get; set; } = null!;
    public Guid TenantId { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Address { get; set; } = null!;
    public DateOnly? DateOfBirth { get; set; }
}
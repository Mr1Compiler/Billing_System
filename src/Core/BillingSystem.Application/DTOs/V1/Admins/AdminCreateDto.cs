using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace BillingSystem.Application.DTOs.V1.Admins;

public record AdminCreateDto(
    string UserName,
    Guid TenantId,
    string Email,
    string Password,
    string FirstName,
    string LastName,
    string Address,
    DateOnly? DateOfBirth
);

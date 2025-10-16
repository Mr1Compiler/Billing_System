namespace BillingSystem.Application.DTOs.V1.Admins;

public record AdminUpdateDto(
     Guid Id,
     string? UserName,
     string? Email,
     string? Password,
     string? FirstName,
     string? LastName,
     string? Address,
     DateOnly? DateOfBirth
);
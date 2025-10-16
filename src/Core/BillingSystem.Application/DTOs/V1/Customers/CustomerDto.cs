namespace BillingSystem.Application.DTOs.V1.Customers;

public record CustomerDto(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string? PhoneNumber,
    DateOnly? DateOfBirth,
    string Address,
    DateTime CreatedAt,
    DateTime UpdatedAt
);

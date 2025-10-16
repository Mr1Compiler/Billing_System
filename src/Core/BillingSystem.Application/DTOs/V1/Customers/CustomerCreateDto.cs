namespace BillingSystem.Application.DTOs.V1.Customers;

public record CustomerCreateDto(
    string FirstName,
    string LastName,
    string Email,
    string? PhoneNumber,
    DateOnly? DateOfBirth,
    string Address
);

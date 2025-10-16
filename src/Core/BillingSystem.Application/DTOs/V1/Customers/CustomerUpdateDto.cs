namespace BillingSystem.Application.DTOs.V1.Customers;

public record CustomerUpdateDto(
    Guid Id,
    string? FirstName,
    string? LastName,
    string? PhoneNumber,
    DateOnly? DateOfBirth,
    string? Address
);
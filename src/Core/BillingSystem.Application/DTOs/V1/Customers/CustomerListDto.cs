namespace BillingSystem.Application.DTOs.V1.Customers;

public record CustomerListDto(
    Guid Id,
    string FullName,
    string Email,
    string Address
);

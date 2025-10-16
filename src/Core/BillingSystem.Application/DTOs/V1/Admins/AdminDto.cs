namespace BillingSystem.Application.DTOs.V1.Admins;

/*
    Read-only DTO for returning Admins details.
    No validation attributes needed.
*/
public record AdminDto(
    Guid Id,
    string UserName,
    string Email,
    string FirstName,
    string LastName,
    string Address,
    DateOnly? DateOfBirth,
    DateTime CreatedAt,
    DateTime UpdatedAt
);

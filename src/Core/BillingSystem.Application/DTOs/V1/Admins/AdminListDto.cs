namespace BillingSystem.Application.DTOs.V1.Admins;

public record AdminListDto(
    Guid Id,
    string Username,
    string FullName,
    string Email,
    string Address
);

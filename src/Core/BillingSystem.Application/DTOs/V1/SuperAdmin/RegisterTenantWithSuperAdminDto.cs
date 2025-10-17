namespace BillingSystem.Application.DTOs.V1.SuperAdmin;

public record RegisterTenantWithSuperAdminDto(
    string UserName,
    string Email,
    string Password,
    string FirstName,
    string LastName,
    string Address,
    DateOnly? DateOfBirth,
    string TenantName,
    string TenantAddress,
    string? TenantDomain
);
    
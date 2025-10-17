namespace BillingSystem.Application.DTOs.V1.SuperAdmin;

public record TenantWithAdminDto(
    Guid AdminId,
    string UserName,
    string Email,
    string FirstName,
    string LastName,
    string Address,
    DateOnly? DateOfBirth,
    Guid TenantId,
    string TenantName,
    string TenantAddress,
    string? TenantDomain 
);
    
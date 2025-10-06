namespace BillingSystem.Application.DTOs.V1.Tenants;

public class TenantUpdateDto
{
    public Guid Id { get; init; }
    public string? Name { get; set; }
    public string? Address { get; set; }
}
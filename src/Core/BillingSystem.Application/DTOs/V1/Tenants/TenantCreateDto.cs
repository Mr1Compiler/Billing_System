namespace BillingSystem.Application.DTOs.V1.Tenants;

public class TenantCreateDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!; 
}
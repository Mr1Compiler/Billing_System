namespace BillingSystem.Application.DTOs.V1.Tenants;

public class TenantListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Domain { get; set; } 
    public string Address { get; set; } = null!; 
}
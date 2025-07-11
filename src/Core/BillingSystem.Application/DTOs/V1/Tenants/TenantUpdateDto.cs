using System.ComponentModel.DataAnnotations;

namespace BillingSystem.Application.DTOs.V1.Tenants;

public class TenantUpdateDto
{
    public Guid Id { get; set; }
    [Required] public string Name { get; set; } = null!;
    [Required] public string Address { get; set; } = null!;
}
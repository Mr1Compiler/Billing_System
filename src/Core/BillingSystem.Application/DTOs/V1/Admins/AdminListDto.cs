namespace BillingSystem.Application.DTOs.V1.Admins;

public class AdminListDto
{
    public Guid Id { get; init; }
    public string Username { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Address { get; set; } = null!;
}
using System.Security.Claims;
using BillingSystem.Domain.Entities;

namespace BillingSystem.Application.Interfaces;

public interface IAuthService
{
    Task<string> GenerateJwtTokenAsync(ApplicationUser user);
    Task<string> ValidateUserAsync(string username, string password);
    ClaimsPrincipal? ValidateToken(string token);
}
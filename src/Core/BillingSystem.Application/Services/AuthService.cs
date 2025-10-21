using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using BillingSystem.Application.Interfaces;
using BillingSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BillingSystem.Application.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _config;
    
    public AuthService(UserManager<ApplicationUser> userManager, IConfiguration config)
    {
        _userManager = userManager;
        _config = config;
    }
    
    public async Task<string> GenerateJwtTokenAsync(ApplicationUser user)
    {
        var roles = await _userManager.GetRolesAsync(user);
    
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}")
        };
        
        claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));
    
        var keyStr = _config["Auth:Key"] 
                     ?? throw new InvalidOperationException("Missing Auth:Key in config");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyStr));
        
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    
        var token = new JwtSecurityToken(
            issuer: _config["Auth:Issuer"],
            audience: _config["Auth:Audience"],
            claims: claims,
            expires:DateTime.UtcNow.AddMinutes(10),
            signingCredentials: creds
        );
    
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<string> ValidateUserAsync(string username, string password)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == username);
        // var user = await _userManager.FindByNameAsync(username);

        if (user == null)
            return null;

        var isValid = await _userManager.CheckPasswordAsync(user, password);
        
        if (!isValid)
            return null;

        var token = await GenerateJwtTokenAsync(user);

        return token;
    }

    public ClaimsPrincipal? ValidateToken(string token)
    {
        // handler
        var tokenHandler = new JwtSecurityTokenHandler();
        var validateParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Auth:Key"]!))
        };

        try
        {
            // Trying to return the user + claims = claimsPrincipal
            var principal = tokenHandler.ValidateToken(token, validateParameters, out var validatedToken);
            return principal;
        }
        catch (Exception e)
        {
            // return null if not validate 
            return null;
        }
    }
}
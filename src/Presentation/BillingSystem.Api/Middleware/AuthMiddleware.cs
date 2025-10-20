using BillingSystem.Application.Interfaces;

namespace BillingSystem.Api.Middleware;

public class AuthMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IAuthService _authService;

    public AuthMiddleware(RequestDelegate next, IAuthService authService)
    {
        _next = next;
        _authService = authService;
    }

    public async Task InokeAsync(HttpContext context)
    {
        // extract the jwt token 
        var token = context.Request.Headers["Authorization"]
            .FirstOrDefault()?.Split(" ").Last();

        if (!string.IsNullOrEmpty(token))
        {
            var principal = _authService.ValidateToken(token);

            if (principal != null)
                context.User = principal; // attach user to HttpContext
        }
        
        await _next(context);
    } 
}
using BillingSystem.Application.Interfaces;

namespace BillingSystem.Api.Middleware;

public class AuthMiddleware
{
    private readonly RequestDelegate _next;

    public AuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IAuthService authService)
    {
        // extract the jwt token 
        var token = context.Request.Headers["Authorization"]
            .FirstOrDefault()?.Split(" ").Last();

        if (!string.IsNullOrEmpty(token))
        {
            var principal = authService.ValidateToken(token);

            if (principal != null)
                context.User = principal; // attach user to HttpContext
        }
        
        await _next(context);
    } 
}
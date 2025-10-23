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
        var path = context.Request.Path.Value;

        if (path.StartsWith("/api/v1/auth", StringComparison.OrdinalIgnoreCase))
        {
            await _next(context);
            return;
        }
        
        // extract the jwt token 
        var token = context.Request.Headers["Authorization"]
            .FirstOrDefault()?.Split(" ").Last();

        if (!string.IsNullOrEmpty(token))
        {
            var principal = authService.ValidateToken(token);

            if (principal != null)
            {
                context.User = principal; // attach user to HttpContext
                await _next(context);
                return;
            }
        }

        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        await context.Response.WriteAsync("Unauthorized");
    } 
}
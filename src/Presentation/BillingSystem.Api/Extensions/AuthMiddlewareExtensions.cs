using BillingSystem.Api.Middleware;

namespace BillingSystem.Api.Extensions;

public static class AuthMiddlewareExtensions
{
   public static IApplicationBuilder UseAuthMiddleware(this IApplicationBuilder app)
   {
      return app.UseMiddleware<AuthMiddleware>();
   } 
}
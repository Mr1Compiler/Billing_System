using BillingSystem.Application.Interfaces;
using BillingSystem.Application.Services;
using BillingSystem.Domain.Interfaces;
using BillingSystem.Infrastructure.Repositories;

namespace BillingSystem.Api.Extensions;

public static class ServiceCollectionExtensions
{
     public static IServiceCollection AddCustomerService(this IServiceCollection service)
     {
          service.AddScoped<ICustomerRepository, CustomerRepository>();
          service.AddScoped<ICustomerService, CustomerService>();
          return service;
     }

     public static IServiceCollection AddAdminService(this IServiceCollection service)
     {
          service.AddScoped<IAdminRepository, AdminRepository>();
          service.AddScoped<IAdminService, AdminService>();
          return service;
     }
     
     public static IServiceCollection AddSuperAdminService(this IServiceCollection service)
     {
          service.AddScoped<ISuperAdminService, SuperAdminService>();
          return service;
     }

     public static IServiceCollection AddSubscriptionPlanService(this IServiceCollection service)
     {
          service.AddScoped<ISubscriptionPlanRepository, SubscriptionPlanRepository>();
          service.AddScoped<ISubscriptionPlanService, SubscriptionPlanService>();
          return service;
     }

     public static IServiceCollection AddCustomerSubscriptionService(this IServiceCollection service)
     {
          service.AddScoped<ICustomerSubscriptionRepository, CustomerSubscriptionRepository>();
          service.AddScoped<ICustomerSubscriptionService, CustomerSubscriptionService>();
          return service;
     }

     public static IServiceCollection AddTenantService(this IServiceCollection service)
     {
          service.AddScoped<ITenantRepository, TenantRepository>();
          service.AddScoped<ITenantService, TenantService>();
          return service;
     }

     public static IServiceCollection AddAuthService(this IServiceCollection service)
     {
          service.AddScoped<IAuthService, AuthService>();
          return service;
     } 
}
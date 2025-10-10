using BillingSystem.Application.Interfaces;
using BillingSystem.Application.Services;

namespace BillingSystem.Api.Extensions;

public static class ServiceCollectionExtensions
{
     public static IServiceCollection AddApplicationService(this IServiceCollection service)
     {
          service.AddScoped<ICustomerService, CustomerService>();
          return service;
     }
}
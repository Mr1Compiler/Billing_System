using AutoMapper;
using BillingSystem.Api.Extensions;
using BillingSystem.Application.Validation.CustomerValidation;
using BillingSystem.Persistence.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Services
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();

// Db context
builder.Services.AddDbContext<ApplicationDbContext>(option => 
    option.UseNpgsql(connectionString));

// Mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); 
builder.Services.AddValidatorsFromAssemblyContaining<CustomerCreateDtoValidator>();

builder.Services.AddCustomerService()
    .AddAdminService()
    .AddSubscriptionPlanService()
    .AddCustomerSubscriptionService()
    .AddTenantService();

var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.Run();


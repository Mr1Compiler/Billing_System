using AutoMapper;
using BillingSystem.Api.Extensions;
using BillingSystem.Application.Validation.CustomerValidation;
using BillingSystem.Persistence.Data;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Services
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();   // needed for Swagger
builder.Services.AddSwaggerGen();


builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});


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

// Enable Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();            // generate JSON
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseRouting();
app.MapControllers();

app.Run();


using BillingSystem.Api.Extensions;
using BillingSystem.Application.Validation.CustomerValidation;
using BillingSystem.Domain.Entities;
using BillingSystem.Persistence.Data;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

// IdentityUser
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); 
builder.Services.AddValidatorsFromAssemblyContaining<CustomerCreateDtoValidator>();

builder.Services.AddCustomerService()
    .AddAdminService()
    .AddSubscriptionPlanService()
    .AddCustomerSubscriptionService()
    .AddSuperAdminService()
    .AddTenantService();

var app = builder.Build();

// Seeding roles to the database by using IdentityUser and scop
using (var scop = app.Services.CreateScope())
{
    var roleManager = scop.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new [] { "SuperAdmin", "Admin" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

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


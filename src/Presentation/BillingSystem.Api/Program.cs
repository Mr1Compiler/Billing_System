using BillingSystem.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
// Services
builder.Services.AddApplicationService();

var app = builder.Build();

app.Run();


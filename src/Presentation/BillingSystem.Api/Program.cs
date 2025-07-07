var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
// Services

var app = builder.Build();

app.Run();


using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.API;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost5174", policy =>
    {
        policy.WithOrigins("http://localhost:5174")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services
    .AddAplicactionServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();

var app = builder.Build();

app.UseCors("AllowLocalhost5174");
app.UseApiServices();

app.Run();


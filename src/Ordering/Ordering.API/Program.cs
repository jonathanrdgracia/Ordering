using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.API;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
var allowedOrigins = builder.Configuration.GetSection("AllowedCorsOrigins").Get<string[]>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigins", policy =>
    {
        policy.WithOrigins(allowedOrigins)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services
    .AddAplicactionServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();

var app = builder.Build();

app.UseCors("AllowOrigins");
app.UseApiServices();

app.Run();


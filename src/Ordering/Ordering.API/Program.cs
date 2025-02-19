using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddAplicactionServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.Run();


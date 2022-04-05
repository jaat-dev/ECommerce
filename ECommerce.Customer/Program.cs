using Ecommerce.Customer.Persistence;
using HealthChecks.UI.Client;
using MediatR;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. -------------------------------------------------------

// HttpContextAccessor
builder.Services.AddHttpContextAccessor();

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Customer"));
});

// Event handlers
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// Health check
builder.Services.AddHealthChecks()
    .AddSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddHealthChecksUI()
    .AddSqliteStorage($"Data Source=Healthchecks\\db");

// API Controllers
builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline. -------------------------------------------------

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/hc", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.MapHealthChecksUI(config => config.UIPath = "/hc-ui");

app.Run();

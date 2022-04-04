using ECommerce.Catalog.Persistence.Entities;
using ECommerce.Catalog.Services.Queries;
using ECommerce.Common;
using HealthChecks.UI.Client;
using MediatR;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. -------------------------------------------------------

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Catalog"));
});

// Query services
builder.Services.AddTransient<IProductQueryService, ProductQueryService>();
builder.Services.AddTransient<IProductInStockQueryService, ProductInStockQueryService>();

// Event handlers
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// Health check
builder.Services.AddHealthChecks()
    .AddSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddHealthChecksUI().AddInMemoryStorage();

builder.Services.AddControllers();

// Configure the PaperTrail
ILoggerFactory loggerFactory = new LoggerFactory();
loggerFactory.AddSyslog(
    builder.Configuration.GetValue<string>("Papertrail:host"),
    builder.Configuration.GetValue<int>("Papertrail:port"));


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


//--------------------------------------------------------------------------------
//builder.Services.AddHealthChecks()
//    .AddCheck("self", () => HealthCheckResult.Healthy())
//    .AddDbContextCheck<ApplicationDbContext>(typeof(ApplicationDbContext).Name);

//app.MapHealthChecks("/hc", new HealthCheckOptions()
//{
//    Predicate = _ => true,
//    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
//});
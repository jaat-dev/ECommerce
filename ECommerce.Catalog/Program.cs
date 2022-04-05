using ECommerce.Catalog.Persistence.Entities;
using ECommerce.Catalog.Services.Queries;
using ECommerce.Common;
using HealthChecks.UI.Client;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. -------------------------------------------------------

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Catalog"));
});

// Health check
builder.Services.AddHealthChecks()
    .AddSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddHealthChecksUI().AddInMemoryStorage();

// Event handlers
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// Query services
builder.Services.AddTransient<IProductQueryService, ProductQueryService>();
builder.Services.AddTransient<IProductInStockQueryService, ProductInStockQueryService>();


builder.Services.AddControllers();

// Add Authentication
var secretKey = Encoding.ASCII.GetBytes(
    builder.Configuration.GetValue<string>("SecretKey")
);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline. -------------------------------------------------

// Configure the PaperTrail
ILoggerFactory loggerFactory = new LoggerFactory();
loggerFactory.AddSyslog(
    builder.Configuration.GetValue<string>("Papertrail:host"),
    builder.Configuration.GetValue<int>("Papertrail:port"));

app.UseAuthorization();
app.MapControllers();

app.MapHealthChecks("/hc", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.MapHealthChecksUI(config => config.UIPath = "/hc-ui");
app.Run();
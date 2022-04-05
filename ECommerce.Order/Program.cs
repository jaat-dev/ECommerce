using Ecommerce.Order.Persistence;
using Ecommerce.Order.Services.Proxies;
using Ecommerce.Order.Services.Proxies.Catalog;
using Ecommerce.Order.Services.Queries;
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

// HttpContextAccessor
builder.Services.AddHttpContextAccessor();

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Order")
    )
);

// ApiUrls
builder.Services.Configure<ApiUrls>(opts => builder.Configuration.GetSection("ApiUrls").Bind(opts));

// Proxies
builder.Services.AddHttpClient<ICatalogProxy, CatalogProxy>();

// Event handlers
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// Health check
builder.Services.AddHealthChecks()
    .AddSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddHealthChecksUI()
    .AddSqliteStorage($"Data Source=Healthchecks\\db");

// Query services
builder.Services.AddTransient<IOrderQueryService, OrderQueryService>();

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

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline. -------------------------------------------------

app.MapHealthChecks("/hc", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.MapHealthChecksUI(config => config.UIPath = "/hc-ui");

app.UseAuthorization();

app.MapControllers();

app.Run();

using Ecommerce.Order.Persistence;
using Ecommerce.Order.Services.Proxies;
using Ecommerce.Order.Services.Proxies.Catalog;
using Ecommerce.Order.Services.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

// Query services
builder.Services.AddTransient<IOrderQueryService, OrderQueryService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline. -------------------------------------------------

app.UseAuthorization();

app.MapControllers();

app.Run();

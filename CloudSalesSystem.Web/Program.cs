using CloudSalesSystem.Business;
using CloudSalesSystem.Business.Interfaces;
using CloudSalesSystem.DAL;
using CloudSalesSystem.DAL.Interfaces;
using CloudSalesSystem.Proxy;
using CloudSalesSystem.Proxy.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CSSContext>(options =>
{
    options
    .UseSqlServer(builder.Configuration.GetConnectionString("Default"))
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

// Add Services
builder.Services.AddScoped<ICSSService, CSSService>();

// Add Repositories
builder.Services.AddScoped<ICSSRepository, CSSRepository>();

// Add Proxies
builder.Services.AddScoped<ICCPProxy, CCPProxy>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
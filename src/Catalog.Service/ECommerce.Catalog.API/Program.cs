using ECommerce.Catalog.Application.DepencyInjection;
using ECommerce.Catalog.Domain.Events.Product;
using ECommerce.Catalog.Domain.Events.shared;
using ECommerce.Infrastructure.DepencyInjection;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// Event Handlers
builder.Services.AddScoped<IDomainEventHandler<ProductAddedEvent>, ProductAddedEventHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

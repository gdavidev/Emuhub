using Emuhub.API;
using Emuhub.API.Filters;
using Emuhub.API.Middleware;
using Emuhub.Application;
using Emuhub.Infrastructure;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddLogger(config, builder.Host);

// Inject Dependencies.
builder.Services.AddInfrastructure(config);
builder.Services.AddApplication();

// Configuring Swagger/OpenAPI. Learn more at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(options => {
    options.Filters.Add(typeof(ExceptionFilter));
});

// Build
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger(options => options.RouteTemplate = "/openapi/{documentName}.json");
app.MapScalarApiReference(options => options.WithTitle("Emuhub - API docs"));

// Middlewares
app.UseSerilogRequestLogging();
app.UseMiddleware<CultureMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();

// Configuration
app.UseUpdateMigration();

// Endpoint mapping
app.MapControllers();

// Setup file provider service
await app.UseFileStorageService();

app.Run();

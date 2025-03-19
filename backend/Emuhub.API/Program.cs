using Scalar.AspNetCore;
using Emuhub.Infrastructure;
using MyRecipeBook.API.Filters;
using MyRecipeBook.API.Middleware;
using Emuhub.Application;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Inject Dependencies.
builder.Services.AddInfrastructure(builder.Configuration);
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
app.UseMiddleware<CultureMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();

// Endpoint mapping
app.MapControllers();

// Alocate static files provider endpoint
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "..\\Emuhub.Infrastructure\\Uploads")),
    RequestPath = "/Resources"
});

app.Run();

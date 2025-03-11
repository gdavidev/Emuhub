using Scalar.AspNetCore;
using Emuhub.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Inject Dependencies.
builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("Default")!);
builder.Services.AddApplication();

// Configuring Swagger/OpenAPI. Learn more at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger(options => options.RouteTemplate = "/openapi/{documentName}.json");
app.MapScalarApiReference(options => options.WithTitle("Emuhub - API docs"));

// Middlewares
app.UseHttpsRedirection();
app.UseAuthorization();

// Endpoint mapping
app.MapControllers();

app.Run();

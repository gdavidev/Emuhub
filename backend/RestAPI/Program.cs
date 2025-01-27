using Microsoft.EntityFrameworkCore;
using RestAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
	opt.UseSqlServer(
		builder.Configuration.GetConnectionString("DefaultConnection"),
		options => options.EnableRetryOnFailure(
			maxRetryCount: 5,
			maxRetryDelay: System.TimeSpan.FromSeconds(30),
			errorNumbersToAdd: null
		)
	)
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

// Middlewares
app.UseHttpsRedirection();
app.UseAuthorization();

// Endpoint mapping
app.MapControllers();

app.Run();

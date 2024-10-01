using MAVIDI_SMILE.mavidiSmile.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Lê a connection string do appsettings.json
var connectionString = builder.Configuration.GetConnectionString("OracleConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string for Oracle Database is not configured.");
}
builder.Services.AddDbContext<OdontoPrevContext>(options =>
{
    options.UseOracle(connectionString);
});

builder.Services.AddControllers();

// Configurações do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

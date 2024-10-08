using MAVIDI_SMILE.mavidiSmile.Application.Services;
using MAVIDI_SMILE.mavidiSmile.Domais.Repositories;
using MAVIDI_SMILE.mavidiSmile.Domais.Services;
using MAVIDI_SMILE.mavidiSmile.Infrastructure.Data;
using MAVIDI_SMILE.mavidiSmile.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Lê a connection string do appsettings.json
var connectionString = builder.Configuration.GetConnectionString("OracleConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string for Oracle Database is not configured.");
}

// Adiciona o OdontoPrevContext com a configuração para o Oracle
builder.Services.AddDbContext<OdontoPrevContext>(options =>
{
    options.UseOracle(connectionString);
});

// Registra os serviços (por exemplo, repositorios, serviços de domínio etc.)
// Isso pode ser estendido conforme a arquitetura Clean que você está usando.
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IClienteApplicationService, ClienteService>();
// builder.Services.AddScoped<IProgressoRepository, ProgressoRepository>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<ProgressoService>();

// Adiciona serviços de controllers
builder.Services.AddControllers();

// Configurações do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração do pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

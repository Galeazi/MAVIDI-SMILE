using MAVIDI_SMILE.Application.Services;
using MAVIDI_SMILE.mavidiSmile.Domain.Interfaces;
using MAVIDI_SMILE.mavidiSmile.Infrastructure.Repositories;
using MAVIDI_SMILE.mavidiSmile.Application.Interfaces;
using MAVIDI_SMILE.mavidiSmile.Application.Services;
using MAVIDI_SMILE.mavidiSmile.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MAVIDI_SMILE.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Verifique se a string de conexão está correta.
var connectionString = builder.Configuration.GetConnectionString("OracleConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string for Oracle Database is not configured.");
}

// Configure o DbContext para usar Oracle.
builder.Services.AddDbContext<AppData>(options =>
{
    options.UseOracle(connectionString);
});

// Adiciona os repositórios e serviços

// Repositórios
builder.Services.AddScoped<IProgressoRepository, ProgressoRepository>();
builder.Services.AddScoped<IAmigosRepository, AmigosRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// Serviços
builder.Services.AddScoped<IProgressoService, ProgressoService>();
builder.Services.AddScoped<IAmigosService, AmigosService>();

builder.Services.AddControllers();

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Fornecedor",
        Version = "v1",
        Description = "API para cadastro de fornecedores"
    });

    c.EnableAnnotations();
});

var app = builder.Build();

// Configuração do pipeline para desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    // Garantir que está usando HTTP em ambiente de desenvolvimento
    // Se precisar de HTTPS, remova esse comentário:
    // app.UseHttpsRedirection();
}
else
{
    // Em produção, use HSTS e redirecionamento HTTPS
    app.UseHttpsRedirection();
    app.UseHsts();
}

// Configure o pipeline de requisições HTTP
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Fornecedor V1");
    // Remover ou ajustar a linha abaixo se não estiver funcionando como esperado
    // c.RoutePrefix = "swagger"; // ou ajuste o valor de acordo com sua preferência
});

app.UseAuthorization();
app.MapControllers();

app.Run();

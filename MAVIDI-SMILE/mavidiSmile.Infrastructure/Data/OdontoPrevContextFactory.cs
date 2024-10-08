using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MAVIDI_SMILE.mavidiSmile.Infrastructure.Data
{
    public class OdontoPrevContextFactory : IDesignTimeDbContextFactory<OdontoPrevContext>
    {
        public OdontoPrevContext CreateDbContext(string[] args)
        {
            // Configura o builder para acessar o appsettings.json
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = configurationBuilder.Build();

            // Pega a connection string do arquivo de configuração
            var connectionString = configuration.GetConnectionString("OracleConnection");

            // Configura o DbContextOptions com a connection string do Oracle
            var optionsBuilder = new DbContextOptionsBuilder<OdontoPrevContext>();
            optionsBuilder.UseOracle(connectionString);

            // Retorna uma nova instância do OdontoPrevContext com as opções configuradas
            return new OdontoPrevContext(optionsBuilder.Options);
        }
    }
}

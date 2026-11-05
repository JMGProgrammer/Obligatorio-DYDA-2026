using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Reporteros.Api.Data;

namespace Reporteros.Api.Data
{
    /// <summary>
    /// Fábrica en tiempo de diseño para que 'dotnet ef' pueda crear el DbContext
    /// sin necesidad de una base de datos real ni de User Secrets configurados.
    /// En tiempo de ejecución la cadena se toma de Configuration.
    /// </summary>
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var configuracion = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .AddUserSecrets<AppDbContextFactory>(optional: true)
                .Build();

            var cadena = configuracion.GetConnectionString("DefaultConnection")
                ?? "Server=localhost;Database=reporteros;User=reporteros;Password=reporteros;";

            var opciones = new DbContextOptionsBuilder<AppDbContext>()
                .UseMySql(cadena, ServerVersion.Create(new Version(8, 0, 0), ServerType.MySql))
                .Options;

            return new AppDbContext(opciones);
        }
    }
}

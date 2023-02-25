using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Contact.Infrastructure.Microsoft;

    public static class MicrosoftDependencies
    {
        public static void AddCustomDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var connStr = $"Server=localhost;Port=5432;User Id=postgres;Password=postgres;Database=contactReport;SSL Mode=Require;Trust Server Certificate=true";
            
            services.AddTransient<IDbConnection>(con => new NpgsqlConnection(connStr));
            
        }
    }
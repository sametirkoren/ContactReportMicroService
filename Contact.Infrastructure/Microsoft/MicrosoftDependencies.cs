using System.Data;
using Contact.Persistence.Abstract;
using Contact.Persistence.Concrete;
using Contact.Persistence.Concrete.Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Contact.Infrastructure.Microsoft;

    public static class MicrosoftDependencies
    {
        public static void AddCustomDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var connStr = $"Server=localhost;Port=5432;User Id=postgres;Password=postgres;Database=contactReport";
            
            services.AddTransient<IDbConnection>(con => new NpgsqlConnection(connStr));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IContactTypeRepository, ContactTypeRepository>();

        }
    }
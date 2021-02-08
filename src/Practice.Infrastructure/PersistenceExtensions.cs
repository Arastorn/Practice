using System.Data;
using Autofac;
using Dapper;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NodaTime;
using NodaTime.Serialization.JsonNet;
using Npgsql;
using Practice.Core.Interfaces;
using Practice.Infrastructure.Data;
using Practice.Infrastructure.Data.Handlers;

namespace Practice.Infrastructure
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
        {
            NpgsqlConnection.GlobalTypeMapper.UseJsonNet(settings: new JsonSerializerSettings().ConfigureForNodaTime(DateTimeZoneProviders.Tzdb));
            DefaultTypeMap.MatchNamesWithUnderscores = true;

            services.AddTransient<IDbConnection>(c => new NpgsqlConnection(connectionString));

            SqlMapper.AddTypeHandler(new InstantHandler());

            return services;
        }

        public static ContainerBuilder RegisterPersistence(this ContainerBuilder builder)
        {
            builder.RegisterType<DigimonRepository>().As<IDigimonRepository>();

            return builder;
        }
    }
}
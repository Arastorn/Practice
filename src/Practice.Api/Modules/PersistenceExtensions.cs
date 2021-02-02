using Autofac;
using Practice.Core.Interfaces;
using Practice.Infrastructure.InMemory;

namespace Practice.Api.Modules
{
    public static class PersistenceExtensions
    {
        public static ContainerBuilder RegisterPersistence(this ContainerBuilder builder)
        {
            builder.RegisterType<DigimonRepository>().As<IDigimonRepository>();

            return builder;
        }
    }
}
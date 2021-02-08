using Autofac;
using MediatR;
using Microsoft.Extensions.Configuration;
using NodaTime;
using Practice.Core.Features.Digimons.Commands.CreateDigimon;
using Practice.Core.Features.Digimons.Commands.UpdateDigimon;
using Practice.Core.Features.Digimons.Queries.GetDigimonById;
using Practice.Core.Features.Digimons.Queries.GetDigimons;

namespace Practice.Api.Modules
{
    public static class ApplicationExtensions
    {
        public static ContainerBuilder RegisterUseCases(this ContainerBuilder builder, IConfiguration configuration)
        {
            builder.RegisterMediators();

            builder.Register(c => SystemClock.Instance).As<IClock>();
            builder.Register(c => DateTimeZoneProviders.Tzdb).As<IDateTimeZoneProvider>();

            return builder;
        }

        private static ContainerBuilder RegisterMediators(this ContainerBuilder builder)
        {
            // Uncomment to enable polymorphic dispatching of requests, but note that
            // this will conflict with generic pipeline behaviors
            // builder.RegisterSource(new ContravariantRegistrationSource());

            // Mediator itself
            builder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            // request & notification handlers
            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder.RegisterType<GetDigimonsQueryHandler>().AsImplementedInterfaces().InstancePerDependency();
            builder.RegisterType<CreateDigimonCommandHandler>().AsImplementedInterfaces().InstancePerDependency();
            builder.RegisterType<UpdateDigimonCommandHandler>().AsImplementedInterfaces().InstancePerDependency();
            builder.RegisterType<GetDigimonByIdQueryHandler>().AsImplementedInterfaces().InstancePerDependency();

            return builder;
        }
    }
}
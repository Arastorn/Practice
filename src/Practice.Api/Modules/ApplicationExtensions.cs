using Autofac;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Practice.Api.Modules
{
    public static class ApplicationExtensions
    {
        public static ContainerBuilder RegisterUseCases(this ContainerBuilder builder, IConfiguration configuration)
        {
            builder.RegisterMediators();
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

            return builder;
        }
    }
}
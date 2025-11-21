using Cortex.Mediator.DependencyInjection;
using DataFile.BackEnd.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataFile.BackEnd.Application
{
    public static class Dependencies
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddMappings()
                .AddFacades()
                .AddFactories()
                .AddMicellaneous(configuration);

            return services;
        }

        private static IServiceCollection AddFacades(this IServiceCollection services)
        {
            return services;
        }

        private static IServiceCollection AddFactories(this IServiceCollection services)
        {
            return services;
        }

        private static IServiceCollection AddMicellaneous(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddValidatorsFromAssemblyContaining(typeof(Dependencies));
            services.AddCortexMediator(
                configuration,
                new[] { typeof(Dependencies) }, // Assemblies to scan
                options => options.AddDefaultBehaviors()
            );

            return services;
        }
    }
}

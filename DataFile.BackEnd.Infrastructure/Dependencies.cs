using DataFile.BackEnd.Domain.Contracts.Infrastructure;
using DataFile.BackEnd.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataFile.BackEnd.Infrastructure
{
    public static class Dependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddPersistence(configuration);

            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var memoryConnectionString = configuration
                .GetValue<string>("DbConnectionString");
            ArgumentNullException.ThrowIfNullOrEmpty(memoryConnectionString, nameof(memoryConnectionString));

            services.AddDbContext<MemoryDBContext>(opts =>
            {
                opts.UseInMemoryDatabase(memoryConnectionString);
            });

            services.AddScoped<MemoryDBContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}

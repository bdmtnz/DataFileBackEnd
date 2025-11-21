using DataFile.BackEnd.Application;
using DataFile.BackEnd.Infrastructure;
using Microsoft.OpenApi;

namespace DataFile.BackEnd.Api
{
    public static class Dependencies
    {
        public static IServiceCollection AddApiDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddPolicyCors()
                .AddSwagger()
                .AddMiscellaneous(configuration)
                .AddInfrastructureDependencies(configuration)
                .AddApplicationDependencies(configuration);

            return services;
        }

        public static IServiceCollection AddPolicyCors(this IServiceCollection services)
        {
            string? myAllowSpecificOrigins = "_myAllowSpecificOrigins";
            services.AddCors(options =>
            {
                options.AddPolicy(
                    myAllowSpecificOrigins,
                    policy =>
                    {
                        policy.AllowAnyHeader().AllowAnyOrigin();

                        policy.WithOrigins(
                                "http://localhost:4200",
                                "http://localhost:4200/",
                                "http://127.0.0.1",
                                "http://127.0.0.1:80")
                            .AllowAnyHeader()
                            .AllowCredentials()
                            .AllowAnyMethod();
                    });
            });

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var environmentName = string.IsNullOrEmpty(environment) ? "Prod" : environment;
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = $"Stellar API ({environmentName} Mode)",
                    Version = "v1",
                });
            });
            return services;
        }

        public static IServiceCollection AddMiscellaneous(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped<JwtMiddleware>();

            return services;
        }
    }
}

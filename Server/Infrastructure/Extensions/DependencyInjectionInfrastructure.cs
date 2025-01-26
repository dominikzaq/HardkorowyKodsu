using Database.Domain.Interfaces;
using Database.Infrastructure.Context;
using Database.Infrastructure.Repositiories;
using Microsoft.Extensions.DependencyInjection;

namespace Database.Infrastructure.Extensions
{
    public static class DependencyInjectionInfrastructure
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<DapperContext>();
            services.AddScoped<IDatabaseRepository, DatabaseRepository>();

            return services;
        }
    }
}

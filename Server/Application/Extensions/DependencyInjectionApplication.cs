using Database.Application.Interfaces;
using Database.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Database.Application.Extensions
{
    public static class DependencyInjectionApplication
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IDatabaseService, DatabaseService>();

            return services;
        }
    }
}

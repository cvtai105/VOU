using Application.Services.GameServices.Factory;
using Application.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<CreateUserHandler>();
            services.AddScoped<GetUserHandler>();
            services.AddSingleton<GameCreatorFactory>();
            return services;
        }
    }
}
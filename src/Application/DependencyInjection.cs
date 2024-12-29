using Application.Services.GamePrototypeServices;
using Application.Services.GameServices;
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

            services.AddScoped<IGameServices, GameServices>();
            services.AddScoped<IGamePrototypeServices, GamePrototypeServices>();

            services.AddScoped<GameCreatorFactory>();
            
            return services;
        }
    }
}
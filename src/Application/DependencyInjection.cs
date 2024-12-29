using Application.Interfaces.GameBehaviors;
using Application.Services.GamePrototypeServices;
using Application.Services.GameServices;
using Application.Services.QuestionServices;
using Application.Services.User;
using Infrastructure.Services.GameServices;
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

            services.AddSingleton<IGameBehaviorsProviderFactory, GameBehaviorsProviderFactory>();

            services.AddScoped<IQuestionServices, QuestionServices>();
            
            return services;
        }
    }
}
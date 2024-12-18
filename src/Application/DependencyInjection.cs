using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.UserUsecases;
using Application.UserUsecases;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<CreateUserHandler>();
            services.AddScoped<GetUserHandler>();
            return services;
        }
    }
}
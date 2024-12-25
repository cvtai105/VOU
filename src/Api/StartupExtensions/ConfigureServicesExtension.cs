using Api.Commons;
using Api.Config;
using Application.Helpers;
using Application.Interfaces;
using Application.Services.BrandServices;
using Application.Services.EventServices;
using Application.Services.ImageServices;
using Domain.Repository;
using Infrastructure.Data;
using Infrastructure.Repository;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;

namespace Api.StartupExtensions
{
    public static class ConfigureServicesExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration config, IWebHostEnvironment env)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            #region services
            services.AddScoped<IEventServices, EventServices>();
            services.AddScoped<IBrandServices, BrandServices>();
            services.AddScoped<IImageServices, ImageServices>();
            #endregion

            #region repos
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            #endregion

            /* Auto mapper */
            services.AddAutoMapper(typeof(MappingProfiles));

            /* DbContext */
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"), sqlServerOptions =>
                {
                    sqlServerOptions.EnableRetryOnFailure();
                })
            );

            /* Identity Services */
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters 
                    {
                        RoleClaimType = ClaimTypes.Role,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = config["JwtSettings:Issuer"],
                        ValidAudience = config["JwtSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Secret"]))
                    };
                });
            services.ConfigureOptions<JwtOptionConfig>();
            services.ConfigureOptions<JwtValidateConfig>();
            //Tạm thời Authorize băng role, nếu cần phức tạp hơn thì sử dụng Policy
            services.AddAuthorization();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState.Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage).ToList();

                    var errorResponse = new ApiValidationErrorResponse()
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });

            return services;
        }
    }
}

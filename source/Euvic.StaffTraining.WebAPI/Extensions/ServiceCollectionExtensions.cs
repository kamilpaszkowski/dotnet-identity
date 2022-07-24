using System;
using System.Collections.Generic;
using IdentityServer4.AccessTokenValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Euvic.StaffTraining.WebAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            var authorizationUrl = configuration.GetValue<string>("Identity:AuthorizationUrl");

            services.AddSwaggerGen(c =>
           {
               c.SwaggerDoc("v1", new OpenApiInfo { Title = "Euvic.StaffTraining.WebAPI", Version = "v1" });
               c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
               {
                   Type = SecuritySchemeType.OAuth2,
                   Flows = new OpenApiOAuthFlows
                   {
                       AuthorizationCode = new OpenApiOAuthFlow
                       {
                           AuthorizationUrl = new Uri($"{authorizationUrl}/connect/authorize"),
                           TokenUrl = new Uri($"{authorizationUrl}/connect/token"),
                           Scopes = new Dictionary<string, string>
                           {
                                { "staff-training-api", "Api Scope" },
                                { "openid", "openid"}
                           }
                       }

                   }
               });

               c.AddSecurityRequirement(new OpenApiSecurityRequirement
               {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
                        },
                        new[] { "staff-training-api" }
                    }
               });
           });
        }

        public static void AddJwtAuthtentication(this IServiceCollection services, IConfiguration configuration)
        {
            var authorizationUrl = configuration.GetValue<string>("Identity:AuthorizationUrl");

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddJwtBearer(IdentityServerAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.Authority = authorizationUrl;
                    options.TokenValidationParameters.ValidateAudience = false;
                });
        }
    }
}

using System.Security.Claims;
using System.Security.Principal;
using Euvic.StaffTraining.Identity;
using Euvic.StaffTraining.WebAPI.Extensions;
using Euvic.StaffTraining.WebAPI.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Euvic.StaffTraining.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IPrincipal, ClaimsPrincipal>(x => x.GetRequiredService<IHttpContextAccessor>().HttpContext.User);
            services.AddStaffTraining(Configuration);
            services.AddIdentityModule(Configuration);

            services.AddControllers();
            services.AddSwagger(Configuration);

            services.AddMvcCore(config =>
            {
                config.Filters.Add<ExceptionFilter>();
                config.Filters.Add<ValidationExceptionFilter>();
            });

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
                {
                    c.OAuthClientId("staff-training-web");
                    c.OAuthAppName("Euvic - Identity Server");
                    c.OAuthUsePkce();
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Euvic.StaffTraining.WebAPI v1");
                });

            app.MigrateStaffTraining();

            app.UseHttpsRedirection();
            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

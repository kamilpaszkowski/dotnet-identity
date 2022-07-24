using Euvic.StaffTraining.Identity.Abstractions;
using Euvic.StaffTraining.Identity.Infrastructure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Euvic.StaffTraining.Identity
{
    public static class ModuleExtensions
    {
        public static void AddIdentityModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IIdentityProvider, IdentityProvider>(x => x.GetRequiredService<IdentityProvider>());
            services.AddHttpClient<IdentityProvider>(x => x.BaseAddress = new Uri(configuration["Identity:AuthorizationUrl"]));
        }
    }
}

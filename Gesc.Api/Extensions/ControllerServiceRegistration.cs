using Gesc.Api.Services.Contrats;
using Gesc.Api.Services;
using Gesc.Api.Services;
using Gesc.Api.Services.Contrats;

namespace Gesc.Api.Extensions
{
    public static class ControllerServiceRegistration
    {
        public static IServiceCollection ConfigureControllerServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceDeDepartement, ServiceDeDepartement>();
            services.AddScoped<IServiceDeFiliere, ServiceDeFiliere>();
            services.AddScoped<IServiceDeCycle, ServiceDeCycle>();
            services.AddScoped<IServiceDeFiliereCycle, ServiceDeFiliereCycle>();
            services.AddScoped<IServiceDeNiveau, ServiceDeNiveau>();
            services.AddScoped<IServiceDecole, ServiceDecole>();

            return services;
        }
    }
}

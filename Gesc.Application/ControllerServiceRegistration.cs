using Gesc.Api.Services;
using Gesc.Features.Services.Contrats;
using Microsoft.Extensions.DependencyInjection;

namespace Gesc.Application
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

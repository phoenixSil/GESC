using Gesc.Api.Repertoires;
using Gesc.Api.Repertoires.Contrats;
using Gesc.Api.Datas;
using Gesc.Api.Repertoires;
using Gesc.Api.Repertoires.Contrats;
using Microsoft.EntityFrameworkCore;

namespace Gesc.Api.Extensions
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IPointDaccess, PointDaccess>();

            services.AddScoped<IRepertoireDecole, RepertoireDecole>();
            services.AddScoped<IRepertoireDeDepartement, RepertoireDeDepartement>();
            services.AddScoped<IRepertoireDeFiliere, RepertoireDeFiliere>();
            services.AddScoped<IRepertoireDeCycle, RepertoireDeCycle>();
            services.AddScoped<IRepertoireDeFiliereCycle, RepertoireDeFiliereCycle>();
            services.AddScoped<IRepertoireDeNiveau, RepertoireDeNiveau>();

            return services;
        }
    }
}

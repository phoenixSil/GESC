using Gesc.Data.Context;
using Gesc.Data.Repertoires;
using Gesc.Features.Contrats.Repertoires;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MsCommun.Extensions;
using MsCommun.Settings;

namespace Gesc.Data
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSqlServerDbConfiguration<SchoolConfigDbContext>(configuration);
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

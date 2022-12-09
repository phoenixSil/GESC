using Gesc.Api.GeneralExtensions;
using Gesc.Application;
using Gesc.Data;
using Gesc.Features.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gesc.InjectionDeDependance
{
    public static  class Registration
    {
        public static IServiceCollection AjoutDeToutesLesExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigurePersistenceServices(configuration);
            services.ConfigureControllerServices();
            services.ConfigureApplicationServices();
            services.AjoutterCoucheDesProxies(configuration); 

            return services;
        }
    }
}

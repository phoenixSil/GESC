using Polly;
using Polly.Timeout;
using Gesc.Features.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Gesc.Features.Proxies.GdcProxys;
using Gesc.Features.Proxies.GieProxys;
using Microsoft.Extensions.Configuration;

namespace Gesc.Features.Extensions
{
    public static class ConfigureServiceProxyExtension
    {
        public static IServiceCollection AjoutterCoucheDesProxies(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureGdcProxyExtensions(configuration);
            services.ConfigureGieProxyExtensions(configuration);

            return services;
        }
    }
}

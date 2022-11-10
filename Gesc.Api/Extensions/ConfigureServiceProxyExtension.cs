using Gesc.Api.Proxies.Contrats;
using Gesc.Api.Proxies.GieProxys;
using Polly;
using Polly.Timeout;

namespace Gesc.Api.Extensions
{
    public static class ConfigureServiceProxyExtension
    {
        public static IServiceCollection AjoutterCoucheDesProxies(this IServiceCollection services, IConfiguration configuration)
        {
            // services.ConfigureGdcProxyExtensions(configuration);
            services.ConfigureGieProxyExtensions(configuration);

            return services;
        }
    }
}

﻿namespace Gesc.Api.Extensions
{
    public static class ConfigureServiceProxyExtension
    {
        public static IServiceCollection AjoutterCoucheDesProxies(this IServiceCollection services, IConfiguration configuration)
        {
            // services.ConfigureGdcProxyExtensions(configuration);
            // services.ConfigureGieProxyExtensions(configuration);

            return services;
        }
    }
}

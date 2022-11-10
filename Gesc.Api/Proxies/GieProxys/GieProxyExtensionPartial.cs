using Gesc.Api.Proxies.Contrats;
using Polly.Timeout;
using Polly;

namespace Gesc.Api.Proxies.GieProxys
{
    public static class GieProxyExtensionPartial
    {
        public static IServiceCollection ConfigureGieProxyExtensions(this IServiceCollection service, IConfiguration configuration)
        {
            Random jitterer = new();

            service.Configure<GieProxyOptions>(configuration.GetSection(GieProxyOptions.Path));
            var gieOptions = configuration.GetSection(GieProxyOptions.Path).Get<GieProxyOptions>();

            Console.WriteLine($"{gieOptions.BaseAdress}/api/");

            service.AddHttpClient<IGieProxy, GieProxy>(options =>
            {
                options.BaseAddress = new Uri($"{gieOptions.BaseAdress}/api/");
            })
            .AddTransientHttpErrorPolicy(
                bder => bder.Or<TimeoutRejectedException>().WaitAndRetryAsync(
                    5,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                        + TimeSpan.FromMilliseconds(jitterer.Next(0, 1000)),
                onRetry: (outcome, timespan, retryAttemp) =>
                {
                    var serviceProvider = service.BuildServiceProvider();
                    serviceProvider.GetService<ILogger<GieProxy>>()?
                        .LogWarning($"Delaying for {timespan.TotalSeconds} seconds, then making retry {retryAttemp}");
                }
            ));
            return service;
        }
    }
}

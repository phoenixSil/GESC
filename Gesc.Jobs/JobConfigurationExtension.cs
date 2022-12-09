using Hangfire.MemoryStorage.Database;
using Hangfire;
using Hangfire.MemoryStorage;

namespace Gesc.Features.Extensions
{
    public static class JobConfigurationExtension
    {
        public const string CronParDefaut = "0 0 * * *";
    }
}

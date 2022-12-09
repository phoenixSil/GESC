using Gesc.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Gesc.Data
{
    public static class PrepDbExtension
    {
        public static void PrepPopulation(this IApplicationBuilder app, bool isProd)
        {
            using var scoped = app.ApplicationServices.CreateAsyncScope();
            SeedData(scoped.ServiceProvider.GetService<SchoolConfigDbContext>(), isProd);
        }

        private static void SeedData(SchoolConfigDbContext context, bool isProd)
        {
            Console.WriteLine($"on est dans lenvironement si : {isProd}");
            
            if (isProd is true)
            {
                Console.WriteLine("Triying to apply migrations ....");
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" --> couldnt run Migration : {ex.Message}");
                }
            }
        }
    }
}

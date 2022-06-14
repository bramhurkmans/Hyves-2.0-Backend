 using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using KrabbelService.Models;

namespace KrabbelService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }
        }

        private static void SeedData(AppDbContext context, bool isProd)
        {
            if(isProd) {
                Console.WriteLine("Migrating database...");
                try {
                    context.Database.Migrate();
                } catch (Exception e) {
                    Console.WriteLine($"Migration failed... {e.Message}");
                }
                
            }
        }
    }
}
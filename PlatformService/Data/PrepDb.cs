using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data
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
                
            } else {
                if(!context.Platforms.Any())
                {
                    Console.WriteLine("Seeding data...");

                    context.Platforms.AddRange(
                        new Platform() { Name=".NET Core", Publisher="Bram Hurkmans", Cost="Free" },
                        new Platform() { Name="Facebook", Publisher="The Zucc", Cost="Free" },
                        new Platform() { Name="Hyves", Publisher="Geen idee", Cost="Free" }
                    );

                    context.SaveChanges();
                } 
                else
                {
                    Console.WriteLine("Already filled with data!");
                }
            }
        }
    }
}
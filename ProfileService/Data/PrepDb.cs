using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProfileService.Models;

namespace ProfileService.Data
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
                if(!context.Users.Any())
                {
                    Console.WriteLine("Seeding data...");

                    // context.Users.AddRange(
                    //     new User() { Name=".NET Core", Publisher="Bram Hurkmans", Cost="Free" },
                    //     new User() { Name="Facebook", Publisher="The Zucc", Cost="Free" },
                    //     new User() { Name="Hyves", Publisher="Geen idee", Cost="Free" }
                    // );

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
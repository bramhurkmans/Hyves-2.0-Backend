using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using UserService.AsyncDataServices;
using UserService.Data;
using UserService.Logic;

namespace UserService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt => 
                opt.UseSqlServer(Configuration.GetConnectionString("DbConn")));

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddHealthChecks();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = bool.Parse(Configuration["Authentication:RequireHttpsMetadata"]);
                options.Authority = Configuration["Authentication:Authority"];
                options.IncludeErrorDetails = bool.Parse(Configuration["Authentication:IncludeErrorDetails"]);
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = bool.Parse(Configuration["Authentication:ValidateAudience"]),
                    ValidAudience = Configuration["Authentication:ValidAudience"],
                    ValidateIssuerSigningKey = bool.Parse(Configuration["Authentication:ValidateIssuerSigningKey"]),
                    ValidateIssuer = bool.Parse(Configuration["Authentication:ValidateIssuer"]),
                    ValidIssuer = Configuration["Authentication:ValidIssuer"],
                    ValidateLifetime = bool.Parse(Configuration["Authentication:ValidateLifetime"])

                };
            });

            services.AddTransient<IClaimsTransformation, ClaimsTransformer>();

            services.AddScoped<IUserLogic, UserLogic>();
            
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IFriendshipRepo, FriendshipRepo>();

            services.AddSingleton<IMessageBusClient, MessageBusClient>();
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UserService", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserService v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            PrepDb.PrepPopulation(app, env.IsProduction());
        }
    }
}

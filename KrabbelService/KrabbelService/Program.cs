using KrabbelService.AsyncDataServices;
using KrabbelService.Data;
using KrabbelService.EventProcessing;
using KrabbelService.Logic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using ProfileService.AsyncDataServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsApi",
                policy =>
                {
                    policy.WithOrigins("http://localhost:8080", "https://staging.hyves.social", "https://hyves.social")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                });
});

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("CorsApi",
//        builder => builder.WithOrigins("http://localhost:8080", "https://staging.hyves.social", "https://hyves.social")
//            .AllowAnyHeader()
//            .AllowAnyMethod());
//});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("MongoConnection"));

builder.Services.AddSingleton<MongoContext>();

builder.Services.AddHostedService<MessageBusSubscriber>();

builder.Services.AddSingleton<IEventProcessor, EventProcessor>();

builder.Services.AddHealthChecks();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = bool.Parse(builder.Configuration["Authentication:RequireHttpsMetadata"]);
    options.Authority = builder.Configuration["Authentication:Authority"];
    options.IncludeErrorDetails = bool.Parse(builder.Configuration["Authentication:IncludeErrorDetails"]);
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = bool.Parse(builder.Configuration["Authentication:ValidateAudience"]),
        ValidAudience = builder.Configuration["Authentication:ValidAudience"],
        ValidateIssuerSigningKey = bool.Parse(builder.Configuration["Authentication:ValidateIssuerSigningKey"]),
        ValidateIssuer = bool.Parse(builder.Configuration["Authentication:ValidateIssuer"]),
        ValidIssuer = builder.Configuration["Authentication:ValidIssuer"],
        ValidateLifetime = bool.Parse(builder.Configuration["Authentication:ValidateLifetime"])

    };
});

builder.Services.AddTransient<IClaimsTransformation, ClaimsTransformer>();

builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IKrabbelRepo, KrabbelRepo>();

builder.Services.AddScoped<IKrabbelLogic, KrabbelLogic>();

builder.Services.AddSingleton<IMessageBusClient, MessageBusClient>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("CorsApi");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

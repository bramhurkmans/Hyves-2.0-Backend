using Microsoft.AspNetCore.Authentication;
using ProfileService.AsyncDataServices;
using ProfileService.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ProfileService.EventProcessing;
using Microsoft.EntityFrameworkCore;
using ProfileService.Logic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt => 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConn")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

builder.Services.AddScoped<IUserLogic, UserLogic>();
builder.Services.AddScoped<IHobbyLogic, HobbyLogic>();
builder.Services.AddScoped<ISongLogic, SongLogic>();
builder.Services.AddScoped<IThemeLogic, ThemeLogic>();

builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IProfileRepo, ProfileRepo>();
builder.Services.AddScoped<IHobbyRepo, HobbyRepo>();
builder.Services.AddScoped<ISongRepo, SongRepo>();
builder.Services.AddScoped<IThemeRepo, ThemeRepo>();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

PrepDb.PrepPopulation(app, app.Environment.IsProduction());

app.Run();

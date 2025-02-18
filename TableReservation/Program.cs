using Core.Config;
using Core.Interfaces;
using Data;
using Infrastructure;
using Infrastructure.AutoMapProfile;
using Infrastructure.Repo;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace TableReservation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x =>
            {
                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Scheme = "Bearer",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                x.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference()
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });

            builder.Services.AddAutoMapper(config =>
            {
                config.AddProfile(new ReservationProfile());
            });

            //Setup db
            builder.Services.AddDbContext<DataContext>(options =>
            {
                if (bool.Parse(builder.Configuration["GeneralSettings:UseInMemoryDb"]))
                {
                    options.UseInMemoryDatabase("TableService");
                }
                else
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                }
            });

            var sharedKey = builder.Configuration["Security:SharedSecret"];

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy(JwtBearerDefaults.AuthenticationScheme,
                    new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build());
            });

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = builder.Configuration["Security:Issuer"],
                    ValidAudience = builder.Configuration["Security:Audiance"],
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey= true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(sharedKey))
                };
            });

            InitializeDependencyInjection(builder.Services, builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (bool.Parse(builder.Configuration["SwaggerSettings:EnableSwagger"]))
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //
            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseCors(x =>
            x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()
            );

            app.MapControllers();

            app.Run();
        }

        public static List<string> injectableTypeNames = new List<string>() { "IInjectable", "IScoped", "ISingleton", "ITransient" };

        public static void InitializeDependencyInjection(IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<SwaggerSettings>
                (configuration.GetSection("SwaggerSettings"));

            services.Configure<Security>(configuration.GetSection("Security"));

            //Transient items create a new instance everytime you ask for one
            //services.AddTransient(typeof(ITestService), typeof(TestService));

            //Scoped is kind of like Transient but instead of everytime you get a new one
            //You get a new one per web request
            //services.AddScoped(typeof(ITableRepo), typeof(TableRepo)); 

            //Singleton is created once and then almost treated like a static class as it is never inialized again
            //services.AddScoped(typeof(ITableService), typeof(TableService));
            //services.AddScoped(typeof(ITableRepo), typeof(TableRepo));

            foreach(var type in typeof(LookupObject).Assembly.GetTypes().Where(t => typeof(IInjectable).IsAssignableFrom(t)))
            {
                var interfaceType = type.GetInterfaces().First(x => injectableTypeNames.Contains(x.Name) == false);
                if (interfaceType == null)
                    continue;

                if(typeof(ISingleton).IsAssignableFrom(type))
                {
                    services.AddSingleton(interfaceType, type);
                }
                else if(typeof(IScoped).IsAssignableFrom(type))
                {
                    services.AddScoped(interfaceType, type);
                }
                else if (typeof(ITransient).IsAssignableFrom(type))
                {
                    services.AddTransient(interfaceType, type);
                }
            }
        }
    }
}
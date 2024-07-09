using Core.Config;
using Core.Interfaces;
using Infrastructure.Repo;
using Infrastructure.Services;

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
            builder.Services.AddSwaggerGen();            

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


            app.MapControllers();

            app.Run();
        }

        public static void InitializeDependencyInjection(IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<SwaggerSettings>
                (configuration.GetSection("SwaggerSettings"));

            //Transient items create a new instance everytime you ask for one
            services.AddTransient(typeof(ITestService), typeof(TestService));

            //Scoped is kind of like Transient but instead of everytime you get a new one
            //You get a new one per web request
            //services.AddScoped(typeof(ITableRepo), typeof(TableRepo)); 

            //Singleton is created once and then almost treated like a static class as it is never inialized again
            services.AddSingleton(typeof(ITableService), typeof(TableService));
            services.AddSingleton(typeof(ITableRepo), typeof(TableRepo));
        }
    }
}
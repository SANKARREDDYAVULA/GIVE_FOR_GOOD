using GiveForGood.Web.Service.DBConfiguration;
using GiveForGood.Web.Service.Interfaces;
using GiveForGood.Web.Service.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace GiveForGood.Web.Service
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        public Startup(IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
            }));

            services.AddScoped<IRoleService, RoleService>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Give For Good",
                    Description = "SMALL INITIATIVE TO HELP THE NEEDY AND GIVE HOPE TO THE HOPELESS.",
                    TermsOfService = new Uri("https://www.giveforgood.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Give For Good",
                        Email="giveforgood.2024@gmail.com",
                        Url=new Uri("https://www.giveforgood.com")
                    },
                    License=new OpenApiLicense
                    {
                        Name="Give For Good License",
                        Url=new Uri("https://www.giveforgood.com/license")
                    }
                });
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Give For Good Global API Services V1");
            });
        }
    }
}

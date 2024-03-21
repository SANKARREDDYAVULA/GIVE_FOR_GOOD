using Microsoft.AspNetCore.Builder;
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
                        Email="sankarreddy.net@yahoo.com",
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
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Give For Good Global API Services V1");
            });
        }
    }
}

using Microsoft.AspNetCore.Builder;

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
            services.AddSwaggerGen();
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

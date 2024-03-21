using Microsoft.AspNetCore.Builder;

namespace GiveForGood.Web.UI
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

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Weather.Data;

// .netcore3
namespace Weather
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DbWeather>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews(mvc => { mvc.EnableEndpointRouting = false; });
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseMvcWithDefaultRoute();
        }
    }
}

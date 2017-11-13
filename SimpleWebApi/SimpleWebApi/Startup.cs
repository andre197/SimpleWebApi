namespace SimpleWebApi
{
    using Controllers;
    using Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;

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
            var controllersAssembly = Assembly.Load(typeof(HomeController).Assembly.FullName);

            services.AddDbContext<FitnessApiDbContext>(opt => opt.UseInMemoryDatabase("FitnessApiDb"));
            services.AddMvc().AddApplicationPart(controllersAssembly).AddControllersAsServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(route =>
            {
                route.MapRoute
                    (
                        "usual_route",
                        "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}

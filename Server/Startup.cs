using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Server.Extensions;
using Shared.Helpers;

namespace Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // ======================================= //
            // IServiceCollection extensions & config
            // ======================================= //
            services
                .SetDependencies()
                .SetEntityFramework(Configuration)
                .SetControllers()
                .AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // ======================================= //
                //          Seed some test data
                // ======================================= //
                DataScaffold.Initialize(app);

                app.UseDeveloperExceptionPage();
                app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
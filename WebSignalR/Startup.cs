using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebSignalR
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            /// Utilisation de SignalR
            services.AddSignalR();

            // Construction d'un singleton de type IDAO en créant une DAO
            services.AddSingleton<IDAO>(new DAO());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Redirection vers le Hub 'HubData'
            // version netCore2.2
            //app.UseSignalR(routes => routes.MapHub<HubData>("/HubData"));
            //app.UseEndpoints(endpoints => endpoints.MapHub<HubData>("/HubData"));

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<HubData>("/HubData");
            });
        }
    }
}

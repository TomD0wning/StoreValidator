using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreValidator.Data;
using StoreValidator.Services;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using FluentValidation;
using StoreValidator.Models;
using Microsoft.Extensions.Logging;

namespace StoreValidator
{
    public class Startup
    {

        private IConfiguration _configuration;


        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<StoreValidatorDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("StoreValidationDocker")));
            //services.AddSingleton<IStoreData, InMemStore>(); //For using in mem data
            services.AddScoped<IStoreData, SqlStoreData>();
           

            services.AddMvc().AddFluentValidation();
            services.AddTransient<IValidator<Store>, StoreDataValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
        
            app.UseStaticFiles();

            app.UseMvc(RouteConfig);

            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync($"Page not Found");
            });
        }

            //Create custom routing
            private void RouteConfig(IRouteBuilder routeBuilder)
            {
                    routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");

            }
        }
    
}

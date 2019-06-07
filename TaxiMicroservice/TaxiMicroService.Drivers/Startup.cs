using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using TaxiMicroService.Drivers.Repository;
using TaxiMicroService.Drivers.Repository.Interfaces;
using TaxiMicroService.Drivers.Services;


namespace TaxiMicroService.Drivers
{
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
            services.AddDbContext<DatabaseContext>(context => { context.UseInMemoryDatabase("TaxiMicroService"); });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IDriverService, DriverService>();

            services.AddAutoMapper();
            services.Configure<DevelopmentVariables>(Configuration.GetSection("DevelopmentVariables"));



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Taxi Auth Microservice", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rambase Shipment API");
            });


            app.UseMvc();
        }
    }
}

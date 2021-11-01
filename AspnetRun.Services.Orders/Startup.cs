using AspnetRun.Services.Orders.Core.Configuration;
using AspnetRun.Services.Orders.Core.Interfaces;
using AspnetRun.Services.Orders.Core.Repositories;
using AspnetRun.Services.Orders.Core.Repositories.Base;
using AspnetRun.Services.Orders.Infrastructure.Data;
using AspnetRun.Services.Orders.Infrastructure.Logging;
using AspnetRun.Services.Orders.Infrastructure.Repository;
using AspnetRun.Services.Orders.Interfaces;
using AspnetRun.Services.Orders.Repository.Base;
using AspnetRun.Services.Orders.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Services.Orders
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
            ConfigureAspnetRunServices(services);

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AspnetRun.Services.Orders", Version = "v1" });
            });
        }

        private void ConfigureAspnetRunServices(IServiceCollection services)
        {
            // Add Core Layer
            services.Configure<AspnetRunSettings>(Configuration);

            // Add Infrastructure Layer
            ConfigureDatabases(services);

            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IOrderRepository, OrderRepository>();

            // Add Application Layer
            services.AddScoped<IOrderService, OrderService>();

            // Add Web Layer
            services.AddAutoMapper(typeof(Startup)); // Add AutoMapper

            // Add Miscellaneous
            services.AddHttpContextAccessor();
        }

        private void ConfigureDatabases(IServiceCollection services)
        {
            // use in-memory database
            services.AddDbContext<AspnetRunContext>(c =>
                c.UseInMemoryDatabase("AspnetRunConnection"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();                
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AspnetRun.Services.Orders v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

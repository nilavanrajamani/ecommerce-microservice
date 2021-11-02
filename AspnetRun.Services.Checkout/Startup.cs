using AspnetRun.Services.Basket.Application.Interfaces;
using AspnetRun.Services.Basket.Application.Services;
using AspnetRun.Services.Basket.Core.Configuration;
using AspnetRun.Services.Basket.Core.Interfaces;
using AspnetRun.Services.Basket.Core.Repositories;
using AspnetRun.Services.Basket.Core.Repositories.Base;
using AspnetRun.Services.Basket.Infrastructure.Logging;
using AspnetRun.Services.Basket.Infrastructure.Repository;
using AspnetRun.Services.Basket.Infrastructure.Repository.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using AutoMapper;
using AspnetRun.Services.Basket.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AspnetRun.Services.Basket
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AspnetRun.Services.Basket", Version = "v1" });
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
            services.AddScoped<ICartRepository, CartRepository>();            

            // Add Application Layer            
            services.AddScoped<ICartService, CartService>();            

            // Add Web Layer
            services.AddAutoMapper(typeof(Startup)); // Add AutoMapper            

            // Add Miscellaneous
            services.AddHttpContextAccessor();            
        }

        public void ConfigureDatabases(IServiceCollection services)
        {
            // use in-memory database
            services.AddDbContext<AspnetRunContext>(c =>
                c.UseInMemoryDatabase("AspnetRunConnection"));

            //// use real database
            //services.AddDbContext<AspnetRunContext>(c =>
            //    c.UseSqlServer(Configuration.GetConnectionString("AspnetRunConnection"), x => x.MigrationsAssembly("AspnetRun.Web")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AspnetRun.Services.Basket v1"));
            }

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

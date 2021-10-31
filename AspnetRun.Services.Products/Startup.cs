using AspnetRun.Services.Products.Core.Configuration;
using AspnetRun.Services.Products.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AspnetRun.Services.Products.Core.Interfaces;
using AspnetRun.Services.Products.Infrastructure.Logging;
using AspnetRun.Services.Products.Core.Repositories.Base;
using AspnetRun.Services.Products.Infrastructure.Repository.Base;
using AspnetRun.Services.Products.Core.Repositories;
using AspnetRun.Services.Products.Infrastructure.Repository;
using AspnetRun.Services.Products.Application.Services;
using AspnetRun.Services.Products.Application.Interfaces;
using AutoMapper;
using Microsoft.OpenApi.Models;

namespace AspnetRun.Services.Products
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
            // aspnetrun dependencies
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Products API", Version = "v1" });
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
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();            
            services.AddScoped<IWishlistRepository, WishlistRepository>();
            services.AddScoped<ICompareRepository, CompareRepository>();            

            // Add Application Layer
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();            
            services.AddScoped<IWishlistService, WishListService>();
            services.AddScoped<ICompareService, CompareService>();            

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
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AspnetRun.Services.Products v1"));

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

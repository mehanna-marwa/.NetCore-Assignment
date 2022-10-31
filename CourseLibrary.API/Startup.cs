using Products.API.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Products.API.Interfaces;
using Products.API.Services;
using AutoMapper;
using System;
using Products.API.Profiles;

namespace Products.API
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
            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(c => c.AddProfile<CategoryMappingProfile>(), typeof(Startup));

            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<ICategoriesService, CategoriesService>();

            services.AddAutoMapper(c => c.AddProfile<Profiles.CategoryMappingProfile>(), typeof(CategoriesService));

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Profiles.CategoryMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            

            services.AddDbContext<ProductDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MainDatabase"));
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Swagger for Products API",
                    Version = "v2",
                    Description = "Just to check URLs",
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v2/swagger.json", "PlaceInfo Services"));
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using StoreInventoryManagement.Domain.Interfaces;
using StoreInventoryManagement.Domain.ModelMappers;
using StoreInventoryManagement.Infrastructure;
using StoreInventoryManagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]

namespace StoreInventoryManagementWebApiRest
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StoreInventoryManagement.Api", Version = "v1" });
            });

            services.Configure<RpgItemStoreRepositorySettings>(
            Configuration.GetSection(nameof(RpgItemStoreRepositorySettings)));

            services.AddSingleton<IRpgItemStoreRepositorySettings>(sp =>
            sp.GetRequiredService<IOptions<RpgItemStoreRepositorySettings>>().Value);

            services.AddScoped<IRpgItemStoreRepository, RpgItemStoreRepository>();

            services.AddScoped<IRpgItemStoreService, RpgItemStoreService>();

            services.AddScoped<IRpgInventoryItemJsonMapper, RpgInventoryItemJsonMapper>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StoreInventoryManagement.Api v1"));
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

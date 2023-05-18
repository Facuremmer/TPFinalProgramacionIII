using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
using TPFinalProgIII.Models;
using TPFinalProgIII.Services;
using TPFinalProgIII.Services.Interfaces;

namespace TPFinalProgIII
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
            services.AddCors();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TPFinalIII", Version = "v1" });
            });

            //Agrego el context para poder usar la cadena de conexion del json.
            services.AddDbContext<StoreContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase")));

            services.AddTransient<IProductServices, ProductServices>();
            services.AddTransient<IAdressServices, AdressServices>();
            services.AddTransient<ICustomerServices, CustomerServices>();
            services.AddTransient<IPersonServices, PersonServices>();
            services.AddTransient<IProductTypeServices, ProductTypeServices>();
            services.AddTransient<IProviderServices, ProviderServices>();
            services.AddTransient<IPurchaseServices, PurchaseServices>();
            services.AddTransient<IPurchaseDetailServices, PurchaseDetailServices>(); 
            services.AddTransient<ISaleServices, SaleServices>();
            services.AddTransient<ISaleDetailServices, SaleDetailServices>();
            services.AddTransient<IShippingPurchaseServices, ShippingPurchaseServices>();
            services.AddTransient<IShippingSaleServices, ShippingSaleServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        
        //VER COMO ARREGLAR PARA PODER USAR SWAGGER, DE ULTIMA FIJARME EN EL PROYECTO QUE ARRANCAMOS EL AÑO PASADO.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
            {
                options.WithOrigins("http://localhost:4200");
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TPFinalProgIII v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

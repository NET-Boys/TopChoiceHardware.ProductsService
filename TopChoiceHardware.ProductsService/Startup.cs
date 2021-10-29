using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TopChoiceHardware.Products.AccessData;
using TopChoiceHardware.Products.AccessData.Commands;
using TopChoiceHardware.Products.Application.Services;
using TopChoiceHardware.Products.Domain.Commands;

namespace TopChoiceHardware.ProductsService
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TopChoiceHardware.ProductsService", Version = "v1" });
            });
            //CORS, Permite cualquier origen
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options
                                                            .AllowAnyOrigin()
                                                            .AllowAnyMethod()
                                                            .AllowAnyHeader());
            });
            var connectionString = Configuration.GetSection("ConnectionString").Value;
            services.AddDbContext<ProductosContext>(options => options.UseSqlServer(connectionString));
            services.AddTransient<IGenericRepository, GenericRepository>();
            services.AddTransient<IProductoService, ProductoService>();
            services.AddTransient<ICategoriaService, CategoriaService>();
            services.AddTransient<IProveedorService, ProveedorService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TopChoiceHardware.ProductsService v1"));
            }
            //CORS, Permite cualquier origen
            app.UseCors(options => options.AllowAnyOrigin()
                                          .AllowAnyHeader()
                                          .AllowAnyHeader());

            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

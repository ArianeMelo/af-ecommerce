using AF.ECommerce.Domain.Validadores.Classe;
using AF.ECommerce.Domain.Validadores.Interface;
using AF.ECommerce.IoC.Dependency;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace AF.ECommerce.API
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
            services
                .AddControllers()
                .AddNewtonsoftJson();
            InjecaoDeDependencia.RegistrarInjecaoDependencia(services);

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo()
                { 
                    Title = "Cadastro de produtos e fornecedores API", 
                    Description = "Desenvolvido",
                    Contact = new OpenApiContact()                    {
                        Name = "Ariane", 
                        Email ="ariane.a"
                    },
                    License = new OpenApiLicense()
                    {
                        Name = "MIT",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    }
                    
                });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            var value = Environment.GetEnvironmentVariable("NOME");
            Console.WriteLine($"Eis o ambiente {value}");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(swagger =>
            {

                swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}

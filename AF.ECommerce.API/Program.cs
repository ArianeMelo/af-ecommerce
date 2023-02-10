using AF.ECommerce.API.Workers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static AF.ECommerce.API.Workers.AlteraStatusPedidoParaProcessandoWorkercs;

namespace AF.ECommerce.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
             .ConfigureServices(configurar =>
             {
                 configurar.AddHostedService<AlteraStatusPedidoParaProcessandoWorker>();
                 configurar.AddHostedService<AlteraStatusPedidoParaEntregueWorker>();
                 configurar.AddHostedService<EnvioEmailSeEstoqueBaixoWorker>();

             });
    }
}

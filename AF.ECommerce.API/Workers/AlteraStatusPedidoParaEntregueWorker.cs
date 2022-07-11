using AF.ECommerce.Domain.Enum;
using AF.ECommerce.Domain.Interfaces.Application;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AF.ECommerce.API.Workers
{
    public class AlteraStatusPedidoParaEntregueWorker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<AlteraStatusPedidoParaEntregueWorker> _logger;


        public AlteraStatusPedidoParaEntregueWorker(
            ILogger<AlteraStatusPedidoParaEntregueWorker> logger,
             IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected async override Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var pedidoApplication = scope.ServiceProvider.GetRequiredService<IPedidoApplication>();

                    _logger.LogInformation("Executando processo para alterar Status para Entregue...");

                    var obterPedidos = pedidoApplication.ObterTodos().Result.ToList();

                    foreach (var pedido in obterPedidos)
                    {
                        if (pedido.Status == Status.EmProcessamento)
                        {
                            pedido.AlterarStatusParaEntregue();

                            await pedidoApplication.Alterar(pedido);
                        }

                        else
                            break;

                    }

                }
                _logger.LogInformation("Terminando a execução. Status alterado para Entregue...");
                await Task.Delay(1200); //120000
            }

        }
    }
}

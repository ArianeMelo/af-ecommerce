using AF.ECommerce.Domain.Enum;
using AF.ECommerce.Domain.Interfaces.Application;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AF.ECommerce.API.Workers
{
    public class AlteraStatusPedidoParaProcessandoWorkercs
    {
        public class AlteraStatusPedidoParaProcessandoWorker : BackgroundService
        {
            private readonly IServiceProvider _serviceProvider;
            private readonly ILogger<AlteraStatusPedidoParaProcessandoWorker> _logger;


            public AlteraStatusPedidoParaProcessandoWorker(
                ILogger<AlteraStatusPedidoParaProcessandoWorker> logger,
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

                        _logger.LogInformation("Executando troca de Status para Processando..");

                        var obterPedidos = pedidoApplication.ObterTodos().Result.ToList();

                        foreach (var pedido in obterPedidos)
                        {
                            if (pedido.Status == Status.EmAnalise)
                            {
                                pedido.AlterarStatusParaProcessando();

                                await pedidoApplication.Alterar(pedido);
                            }

                            else
                                break;

                        }

                    }
                    _logger.LogInformation("Fim da execução.  Status alterado para Processando ...");
                    await Task.Delay(120000); //120000
                }

            }
        }
    }
}

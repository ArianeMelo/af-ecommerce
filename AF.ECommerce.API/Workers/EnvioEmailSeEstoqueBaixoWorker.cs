using AF.ECommerce.Domain.Entities;
using AF.ECommerce.Domain.Interfaces.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace AF.ECommerce.API.Workers
{
    public class EnvioEmailSeEstoqueBaixoWorker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<EnvioEmailSeEstoqueBaixoWorker> _logger;


        public EnvioEmailSeEstoqueBaixoWorker(
            ILogger<EnvioEmailSeEstoqueBaixoWorker> logger,
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
                    var produtoApplication = scope.ServiceProvider.GetRequiredService<IProdutoApplication>();

                    _logger.LogInformation("Executando verificação do Estoque...");

                    var obterProdutos = produtoApplication.ObterTodos().Result.ToList();

                    ConfiguracaoEmail configuracaoEmail = new ConfiguracaoEmail();

                    foreach (var produto in obterProdutos)
                    {
                        if (produto.Estoque < 3)
                        {
                            configuracaoEmail.EnvioEmail("ariane.admquirino@gmail.com", produto);
                        }

                    }
                }
                _logger.LogInformation("Termino verificação do Estoque ...");
                await Task.Delay(1200); //120000
            }

        }
    }
}

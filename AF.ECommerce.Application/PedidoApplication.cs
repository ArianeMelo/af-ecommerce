using AF.ECommerce.Domain.Entities;
using AF.ECommerce.Domain.Interfaces.Application;
using AF.ECommerce.Domain.Interfaces.Repository;
using AF.ECommerce.Repository.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ValidationResult = FluentValidation.Results.ValidationResult;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace AF.ECommerce.Application
{
    public class PedidoApplication : IPedidoApplication
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoItemRepository _pedidoItemRepository;
        private readonly ILogger<PedidoApplication> _logger;
        private ValidationResult _validationResult;
        private readonly IUnityOfWork _unityOfWork;

        public PedidoApplication(
            IPedidoRepository pedidoRepository,
            IProdutoRepository produtoRepository,
            IPedidoItemRepository pedidoItemRepository,
            ILogger<PedidoApplication> logger,  
            IUnityOfWork unityOfWork)

        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
            _pedidoItemRepository = pedidoItemRepository;
            _logger = logger; 
            _validationResult = new ValidationResult();
            _unityOfWork = unityOfWork;
        }

        public async Task<Pedido> ObterPorId(Guid id)
        {
            var pedido = await _pedidoRepository.ObterPorId(id);
            if (pedido == null)
            {
                _validationResult.Errors.Add(new ValidationFailure() { ErrorMessage = $"Pedido não localizado" });

            }
            return (pedido);
        }

        public async Task<IEnumerable<Pedido>> ObterTodos()
        {
            return await _pedidoRepository.ObterTodos();
        }

        public async Task<bool> AdicionarPedido(Pedido pedido)
        {
            try
            {       
                List<Produto> listaProdutoAInserir = new List<Produto>();

                foreach (var item in pedido.Itens)               {
                   

                    var produto = await _produtoRepository.ObterPorId(item.ProdutoId);
                    if (produto == null)
                        return false;

                    var possoDebitar = produto.VerificarSePodeDebitarEstoque(item.Quantidade);

                    int QUANTIDADE_PERMITIDA_POR_VENDA = 11;


                    if (possoDebitar && item.Quantidade < QUANTIDADE_PERMITIDA_POR_VENDA)  //true se puder debitar 
                        listaProdutoAInserir.Add(produto);

                    else
                        return false;
                }

                _unityOfWork.IniciarTransacao();
                _pedidoRepository.AtribuirTransacao(_unityOfWork);
                _pedidoItemRepository.AtribuirTransacao(_unityOfWork);
                _produtoRepository.AtribuirTransacao(_unityOfWork);

                await _pedidoRepository.Adicionar(pedido);

                var logPedido = JsonConvert.SerializeObject(pedido, Formatting.Indented);
                _logger.LogInformation($"Adicionando pedido : {logPedido}.");

                foreach (var item in pedido.Itens)
                {
                    var pedidoItem = new PedidoItem(item.PedidoId, item.ProdutoId, item.Quantidade, item.Valor, item.Desconto)
                    {
                        Id = item.Id
                    };

                    await _pedidoItemRepository.Adicionar(pedidoItem);

                    var logItensPedido = JsonConvert.SerializeObject(pedidoItem, Formatting.Indented);
                    _logger.LogInformation($"Adicionando itens do pedido : {logItensPedido}.");


                    var produto = listaProdutoAInserir.FirstOrDefault(prod => prod.Id == item.ProdutoId);
                    produto.DebitarEstoque(item.Quantidade);
                    await _produtoRepository.Alterar(produto);

                    var logProduto = JsonConvert.SerializeObject(produto, Formatting.Indented);
                    _logger.LogInformation($"Alterando estoque do produto : {logProduto}.");
                }

                _unityOfWork.CommittarTransacao();

                _logger.LogInformation("Commit Realizado");

               
            }
            catch (Exception)
            {
                _unityOfWork.RollbackTransacao();
                _logger.LogInformation("Rollback Realizado");
                throw;
            }

            return true;
        }

        public async Task Alterar(Pedido pedido)
        {
            await _pedidoRepository.Alterar(pedido);
        }

        public async Task Excluir(Pedido pedido)
        {
            await _pedidoRepository.Excluir(pedido);
        }
    }
}

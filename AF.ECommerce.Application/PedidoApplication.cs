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

namespace AF.ECommerce.Application
{
    public class PedidoApplication : IPedidoApplication
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoItemRepository _pedidoItemRepository;
        private readonly ILogger<PedidoApplication> _logger;
        private ValidationResult _validationResult;

        public PedidoApplication(
            IPedidoRepository pedidoRepository,
            IProdutoRepository produtoRepository,
            IPedidoItemRepository pedidoItemRepository,
            ILogger<PedidoApplication> logger)

        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
            _pedidoItemRepository = pedidoItemRepository;
            _logger = logger; 
            _validationResult = new ValidationResult();
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
            List<Produto> listaProdutoAInserir = new List<Produto>();           

            foreach (var item in pedido.Itens)
            {
                var produto = await _produtoRepository.ObterPorId(item.ProdutoId);
                if (produto == null)
                    return false;

                var possoDebitar = produto.VerificarSePodeDebitarEstoque(item.Quantidade);

                  int QUANTIDADE_PERMITIDA_POR_VENDA = 11;
                

                if (possoDebitar && item.Quantidade < QUANTIDADE_PERMITIDA_POR_VENDA) //true se puder debitar 
                    listaProdutoAInserir.Add(produto);

                else
                    return false;
               
            }

            await _pedidoRepository.Adicionar(pedido);

            foreach (var item in pedido.Itens)
            {
                var pedidoItem = new PedidoItem(item.PedidoId, item.ProdutoId, item.Quantidade, item.Valor, item.Desconto)
                {
                    Id = item.Id
                };

                await _pedidoItemRepository.Adicionar(pedidoItem);

                
                var produto = listaProdutoAInserir.FirstOrDefault(prod => prod.Id == item.ProdutoId);
                produto.DebitarEstoque(item.Quantidade);
                await _produtoRepository.Alterar(produto);

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

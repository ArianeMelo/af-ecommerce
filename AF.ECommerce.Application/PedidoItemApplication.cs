using AF.ECommerce.Domain.Entities;
using AF.ECommerce.Domain.Interfaces.Application;
using AF.ECommerce.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AF.ECommerce.Application
{
    public class PedidoItemApplication : IPedidoItemApplication
    {
       
        private readonly IPedidoItemRepository _pedidoItemRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;

        public PedidoItemApplication(
            IPedidoItemRepository pedidoItemRepository,
            IPedidoRepository pedidoRepository,
            Domain.Interfaces.Repository.IProdutoRepository produtoRepository)
        {
            _pedidoItemRepository = pedidoItemRepository;    
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
        }

        
        public async Task<PedidoItem> ObterPorId(Guid id)
        {
         
            return await _pedidoItemRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<PedidoItem>> ObterTodos()
        {

            return await _pedidoItemRepository.ObterTodos();
        }
              

        public async Task Adicionar(PedidoItem pedidoItem)
        {

            await _pedidoItemRepository.Adicionar(pedidoItem);
        }


        public async Task Alterar(PedidoItem pedidoItem)
        {
            await _pedidoItemRepository.Alterar(pedidoItem);
        }

        public async Task Excluir(PedidoItem pedidoItem)
        {
            await _pedidoItemRepository.Excluir(pedidoItem);
        }
    }
}

using AF.ECommerce.Domain.Entities;
using AF.ECommerce.Domain.Interfaces.Application;
using AF.ECommerce.Domain.Interfaces.Repository;
using AF.ECommerce.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AF.ECommerce.Application
{
    public class PedidoApplication : IPedidoApplication
    {
        private readonly IPedidoRepository _pedidoRepository;
       

       public PedidoApplication(IPedidoRepository pedidoRepository)
       {
            _pedidoRepository = pedidoRepository;
         
       }

        public async Task<Pedido> ObterPorId(Guid id)
        {         
            return await _pedidoRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<Pedido>> ObterTodos()
        {
            return await _pedidoRepository.ObterTodos();
        }

        public async Task Adicionar(Pedido pedido)
        {
            await _pedidoRepository.Adicionar(pedido);
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

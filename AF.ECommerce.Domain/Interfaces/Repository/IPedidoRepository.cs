using AF.ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AF.ECommerce.Domain.Interfaces.Repository
{
    public interface IPedidoRepository
    {
        Task<Pedido> ObterPorId(Guid id);
        Task<IEnumerable<Pedido>> ObterTodos();
        Task<bool> AdicionarPedido(Pedido pedido);
        Task AdicionarPedidoItem(PedidoItem pedidoItem);
        Task Alterar(Pedido pedido);
        Task Excluir(Pedido pedido);
    }
}

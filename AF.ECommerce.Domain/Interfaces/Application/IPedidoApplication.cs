using AF.ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AF.ECommerce.Domain.Interfaces.Application
{
    public interface IPedidoApplication
    {
        Task<Pedido> ObterPorId(Guid id);
        Task<IEnumerable<Pedido>> ObterTodos();
        Task Adicionar(Pedido pedido);
        Task Alterar(Pedido pedido);
        Task Excluir(Pedido pedido);
    }
}

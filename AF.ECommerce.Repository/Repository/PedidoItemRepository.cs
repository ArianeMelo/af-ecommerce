using AF.ECommerce.Domain.Entities;
using AF.ECommerce.Domain.Interfaces.Repository;
using AF.ECommerce.Repository.Repository.Base;
using Dommel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AF.ECommerce.Repository.Repository
{
    public class PedidoItemRepository : BaseRepository<PedidoItem>,  IPedidoItemRepository
    {
       
        public PedidoItemRepository(IUnityOfWork unitOfWork)
            : base(unitOfWork)
        {}

        public override async  Task<IEnumerable<PedidoItem>> ObterTodos()
        {
            return await base.ObterTodos();
        }

        public override async Task<PedidoItem> ObterPorId(Guid id)
        {
            return await base.ObterPorId(id);
        }

        public async Task AdicionarPedidoItem(PedidoItem pedidoItem)
        {
            await base.Adicionar(pedidoItem);
        }

        public  async Task<IEnumerable<PedidoItem>> ObterPorPedidoId(Expression<Func<PedidoItem, bool>> where)
        {
            return await base.Buscar(where);
        }


        public override async Task Alterar(PedidoItem pedidoItem)
        {
            await base.Alterar(pedidoItem);
        }

        public override async Task Excluir(PedidoItem pedidoItem)
        {
            await base.Excluir(pedidoItem);
        }
    }
}

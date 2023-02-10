using AF.ECommerce.Domain.Entities;
using AF.ECommerce.Domain.Interfaces.Repository;
using AF.ECommerce.Repository.Queries;
using AF.ECommerce.Repository.Repository.Base;
using Dapper;
using Dommel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AF.ECommerce.Repository.Repository
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(IUnityOfWork unitOfWork)
            : base(unitOfWork)
        { }

        public async Task<IEnumerable<Pedido>> ObterTodos()
        {
            using (SqlConnection db = new SqlConnection(UnityOfWork.ConnectionString))
            {
                string querySql = PedidoQuery.ObterTodosOsPedidos;

                var pedidos = new List<Pedido>();

                await db.QueryAsync<Pedido, PedidoItem, Pedido>(querySql,
                    (pedido, item) =>
                    {
                        var pedidoEncontrado = pedidos.FirstOrDefault(p => p.Id.Equals(pedido.Id));

                        if (pedidoEncontrado != null)
                            pedidoEncontrado.Itens.Add(item);
                        else
                        {
                            pedido.Itens.Add(item);
                            pedidos.Add(pedido);
                        }

                        return pedido;
                    },
                    splitOn: "ID_ITEM_PEDIDO");

                return pedidos;
            }
        }

        public async Task<Pedido> ObterPorId(Guid id)
        {
            using (SqlConnection db = new SqlConnection(UnityOfWork.ConnectionString))
            {
                string querySql = PedidoQuery.ObterPedidoPorId;

                var pedidoRetorno = new Pedido();

                await db.QueryAsync<Pedido, PedidoItem, Pedido>(querySql,
                    (pedido, item) =>
                    {
                        if (pedidoRetorno.Id.Equals(pedido.Id))
                            pedidoRetorno.Itens.Add(item);
                        else
                        {
                            pedidoRetorno = pedido;
                            pedidoRetorno.Itens.Add(item);
                        }

                        return pedido;
                    },
                    param: new { id },
                    splitOn: "ID_ITEM_PEDIDO");

                return pedidoRetorno;
            }
        }
        public override async Task Adicionar(Pedido pedido)
        {
            await base.Adicionar(pedido);
        }

        public override async Task Alterar(Pedido pedido)
        {
            await base.Alterar(pedido);
        }

        public override async Task Excluir(Pedido pedido)
        {
            await base.Excluir(pedido);
        }
    }

}


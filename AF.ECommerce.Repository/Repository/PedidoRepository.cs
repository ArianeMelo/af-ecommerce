using AF.ECommerce.Domain.Entities;
using AF.ECommerce.Domain.Interfaces.Repository;
using Dapper;
using Dommel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.ECommerce.Repository.Repository
{
    public class PedidoRepository : IPedidoRepository
    {

        private readonly IConfiguration _configuration;
        private readonly IPedidoItemRepository _pedidoItemRepository;
        private readonly string _connection;

        public PedidoRepository(IConfiguration configuration,
            IPedidoItemRepository pedidoItemRepository)
        {
            _pedidoItemRepository = pedidoItemRepository;
            _configuration = configuration;
            _connection = _configuration.GetConnectionString("DefaultString");
        }

        public async Task<Pedido> ObterPorId(Guid id)
        {
            using (SqlConnection dbConnection = new SqlConnection(_connection))
            {
                var queryPedido = @"SELECT P.ID, P.CLIENTEID, " +
                                    "P.DATACADASTRO, P.TIPOFRETE, P.STATUS, P.VALOR, " +
                                     "P.OBSERVACAO, PI.ID, PI.PEDIDO_ID, PI.PRODUTO_ID, " +
                                      " PI.QUANTIDADE, PI.VALOR, PI.DESCONTO " +
                               "FROM PEDIDOS AS P " +
                               "JOIN PEDIDOS_ITEM AS PI " +
                                     "ON P.ID = PI.PEDIDO_ID " +
                                "WHERE P.ID = @Id ";


                var itensPedido = _pedidoItemRepository.ObterPorPedidoId(pedido => pedido.PedidoId == id).Result.ToList();


                return dbConnection.Query<Pedido, PedidoItem, Pedido>(queryPedido,
                    map: (pedido, pedidoItem) =>
                    {

                        pedido.Itens = itensPedido;

                        return pedido;
                    },
                    param: new { id },
                    splitOn: "id").FirstOrDefault();



            }
        }



        public async Task<IEnumerable<Pedido>> ObterTodos()
        {
            using (SqlConnection dbConnection = new SqlConnection(_connection))
            {

                var queryPedido = @"SELECT P.ID, P.CLIENTEID, " +
                                         "P.DATACADASTRO, P.TIPOFRETE, P.STATUS, P.VALOR, " +
                                         "P.OBSERVACAO, PI.ID, PI.PEDIDO_ID AS PedidoId, PI.PRODUTO_ID AS ProdutoId, " +
                                     "PI.QUANTIDADE, PI.VALOR, PI.DESCONTO " +
                                   "FROM PEDIDOS AS P " +
                                   "INNER JOIN PEDIDOS_ITEM AS PI " +
                                          "ON P.ID = PI.PEDIDO_ID";

                var pedidos = new List<Pedido>();

               await dbConnection.QueryAsync<Pedido, PedidoItem, Pedido>(queryPedido,
                    (pedido, pedidoItem) =>
                    {
                        if (pedidos.Any(p => p.Id == pedido.Id))
                        {
                            var pedidoExistente = pedidos.FirstOrDefault(p => p.Id == pedido.Id);
                            pedidoExistente.Itens.Add(pedidoItem);
                        }
                        else
                        {
                            pedido.Itens.Add(pedidoItem);
                            pedidos.Add(pedido);
                        }
                        return pedido;
                    },
                    splitOn: "Id,Id");

                return pedidos;
            }
        }
        public async Task<bool> AdicionarPedido(Pedido pedido)
        {
            using (SqlConnection dbConnection = new SqlConnection(_connection))
            {
                await dbConnection.InsertAsync(pedido);

                return true;
            }
        }

        public async Task AdicionarPedidoItem(PedidoItem pedidoItem)
        {
            using (SqlConnection dbConnection = new SqlConnection(_connection))
            {
                await dbConnection.InsertAsync(pedidoItem);
            }
        }

        public async Task Alterar(Pedido pedido)
        {
            using (SqlConnection dbConnection = new SqlConnection(_connection))
            {
                await dbConnection.UpdateAsync(pedido);
            }
        }

        public async Task Excluir(Pedido pedido)
        {
            using (SqlConnection dbConnection = new SqlConnection(_connection))
            {
                await dbConnection.DeleteAsync(pedido);
            }
        }
    }
}

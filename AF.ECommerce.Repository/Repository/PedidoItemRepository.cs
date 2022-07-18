using AF.ECommerce.Domain.Entities;
using AF.ECommerce.Domain.Interfaces.Repository;
using Dommel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AF.ECommerce.Repository.Repository
{
    public class PedidoItemRepository : IPedidoItemRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connection;
        public PedidoItemRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = _configuration.GetConnectionString("DefaultString");
        }

        public async Task<IEnumerable<PedidoItem>> ObterTodos()
        {
            using (SqlConnection dbConnection = new SqlConnection(_connection))
            {
                return await dbConnection.GetAllAsync<PedidoItem>();
            }
        }

        public async Task<PedidoItem> ObterPorId(Guid id)
        {
            using (SqlConnection dbConnection = new SqlConnection(_connection))
            {
                return await dbConnection.GetAsync<PedidoItem>(id);
            }
        }

        public async Task<IEnumerable<PedidoItem>> ObterPorPedidoId(Expression<Func<PedidoItem, bool>> where)
        {
            using (SqlConnection dbConnection = new SqlConnection(_connection))
            {
                return await dbConnection.SelectAsync<PedidoItem>(where);
            }
        }


        public async Task Alterar(PedidoItem pedidoItem)
        {
            using (SqlConnection dbConnection = new SqlConnection(_connection))
            {
                await dbConnection.UpdateAsync(pedidoItem);
            }
        }

        public async Task Excluir(PedidoItem pedidoItem)
        {
            using (SqlConnection dbConnection = new SqlConnection(_connection))
            {
                await dbConnection.DeleteAsync(pedidoItem);
            }
        }
    }
}

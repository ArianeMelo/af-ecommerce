using AF.ECommerce.Domain.Entities;
using AF.ECommerce.Domain.Interfaces.Repository;
using Dommel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace AF.ECommerce.Repository.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private string _connectionString = @"Data Source=felipe-pc\SQLEXPRESS;Initial Catalog=AF_ECommerce;User ID=sa;Password=119696";
        public async Task<Pedido> ObterPorId(Guid id)
        {
            using (SqlConnection dbConnection = new SqlConnection(_connectionString))
            {
                return await dbConnection.GetAsync<Pedido>(id); 
            }
        }

        public async Task<IEnumerable<Pedido>> ObterTodos()
        {
            using (SqlConnection dbConnection = new SqlConnection(_connectionString))
            {
                return await dbConnection.GetAllAsync<Pedido>();
            }
        }
        public async Task Adicionar(Pedido pedido)
        {
            using (SqlConnection dbConnection = new SqlConnection(_connectionString))
            {
                await dbConnection.InsertAsync(pedido);
            }
        }

        public async Task  Alterar(Pedido pedido)
        {
            using (SqlConnection dbConnection = new SqlConnection(_connectionString))
            {
                await dbConnection.UpdateAsync(pedido);
            }
        }

        public async Task Excluir(Pedido pedido)
        {
            using (SqlConnection dbConnection = new SqlConnection(_connectionString))
            {
                await dbConnection.DeleteAsync(pedido);
            }
        }
    }
}

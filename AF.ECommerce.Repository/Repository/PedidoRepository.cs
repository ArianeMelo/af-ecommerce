using AF.ECommerce.Domain.Entities;
using AF.ECommerce.Domain.Interfaces.Repository;
using Dommel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace AF.ECommerce.Repository.Repository
{
    public class PedidoRepository : IPedidoRepository
    {

        private readonly IConfiguration _configuration;
        private readonly string _connection;

        public PedidoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = _configuration.GetConnectionString("DefaultString");
        }
        
        public async Task<Pedido> ObterPorId(Guid id)
        {
            using (SqlConnection dbConnection = new SqlConnection(_connection))
            {
                return await dbConnection.GetAsync<Pedido>(id); 
            }
        }

        public async Task<IEnumerable<Pedido>> ObterTodos()
        {
            using (SqlConnection dbConnection = new SqlConnection(_connection))
            {
                return await dbConnection.GetAllAsync<Pedido>();
            }
        }
        public async Task Adicionar(Pedido pedido)
        {
            using (SqlConnection dbConnection = new SqlConnection(_connection))
            {
                await dbConnection.InsertAsync(pedido);
            }
        }

        public async Task  Alterar(Pedido pedido)
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

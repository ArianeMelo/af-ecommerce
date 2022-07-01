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
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connection;

        public ProdutoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = _configuration.GetConnectionString("DefaultString");
        }

        public async Task<Produto> ObterPorId(Guid id)
        {
            using(SqlConnection dbConnection = new SqlConnection(_connection))
            {
                return await dbConnection.GetAsync<Produto>(id);
            }
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            using (SqlConnection dbConnection = new SqlConnection(_connection))
            {
                return await dbConnection.GetAllAsync<Produto>();
            }
        }

        public async Task Adicionar(Produto produto)
        {
            using(SqlConnection dbConnection = new SqlConnection(_connection))
            {
                await dbConnection.InsertAsync(produto);
            } 
        }

        public async Task Alterar(Produto produto)
        {
            using(SqlConnection dbConnection = new SqlConnection(_connection))
            {
                await dbConnection.UpdateAsync(produto);
            }
        }

        public async Task Excluir(Produto produto)
        {
            using (SqlConnection dbConnection = new SqlConnection(_connection))
            {
                await dbConnection.DeleteAsync(produto);
            }
        }
    }
}

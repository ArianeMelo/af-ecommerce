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
    public class ClienteRepository : IClienteRepository
    {
       
        private readonly IConfiguration _configuration;
        private readonly string _connection;

        public ClienteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = _configuration.GetConnectionString("DefaultString");
        }

        public async Task<Cliente> ObterPorId(Guid id)
        {
            using (SqlConnection dbConnection = new SqlConnection(_connection))
            {
                 return await dbConnection.GetAsync<Cliente>(id);
            }
        }
        public async Task<IEnumerable<Cliente>> ObterPorCpf(Expression<Func<Cliente, bool>> where)
        {
            using (SqlConnection dbConnection = new SqlConnection(_connection))
            {
                return await dbConnection.SelectAsync<Cliente>(where);
            }
        }

        public async Task<IEnumerable<Cliente>> ObterTodos()
        {
            using (SqlConnection dbConnection = new SqlConnection(_connection))
            {
                return await dbConnection.GetAllAsync<Cliente>(); 
            }
        }
        public async Task<bool> Adicionar(Cliente cliente)
        {
           using(SqlConnection dbConnection = new SqlConnection(_connection))
           {
                var cli = await dbConnection.InsertAsync(cliente);

                return true;
           }

        }

        public async Task Alterar(Cliente cliente)
        {
            using (SqlConnection dbConnection = new SqlConnection(_connection))
            {
                await dbConnection.UpdateAsync(cliente);
            }
        }

        public async Task Excluir(Cliente cliente)
        {
            using (SqlConnection dbConnection = new SqlConnection(_connection))
            {
                await dbConnection.DeleteAsync(cliente);
            }
        }

       
    }
}

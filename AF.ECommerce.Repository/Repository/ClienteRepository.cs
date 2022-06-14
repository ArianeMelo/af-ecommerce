using AF.ECommerce.Domain.Entities;
using AF.ECommerce.Domain.Interfaces.Repository;
using Dommel;
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
        private string connectionString = @"Data Source=felipe-pc\SQLEXPRESS;Initial Catalog=AF_ECommerce;User ID=sa;Password=119696";
        
        public async Task<Cliente> ObterPorId(Guid id)
        {
            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                 return await dbConnection.GetAsync<Cliente>(id);
            }
        }
        public async Task<IEnumerable<Cliente>> ObterPorCpf(Expression<Func<Cliente, bool>> where)
        {
            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                return await dbConnection.SelectAsync<Cliente>(where);
            }
        }

        public async Task<IEnumerable<Cliente>> ObterTodos()
        {
            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                return await dbConnection.GetAllAsync<Cliente>(); 
            }
        }
        public async Task Adicionar(Cliente cliente)
        {
           using(SqlConnection dbConnection = new SqlConnection(connectionString))
           {
                await dbConnection.InsertAsync(cliente);
           }

        }

        public async Task Atualizar(Cliente cliente)
        {
            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                await dbConnection.UpdateAsync(cliente);
            }
        }

        public async Task Excluir(Cliente cliente)
        {
            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                await dbConnection.DeleteAsync(cliente);
            }
        }

       
    }
}

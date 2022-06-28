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
    public class CategoriaRepository : ICategoriaRepository
    {
        private string connectionString = @"Data Source=felipe-pc\SQLEXPRESS;Initial Catalog=AF_ECommerce;User ID=sa;Password=119696";

        public async Task<Categoria> ObterPorId(Guid id)
        {
            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                return await dbConnection.GetAsync<Categoria>(id);
            }
        }

        public async Task<IEnumerable<Categoria>> ObterPorDescricao(Expression<Func<Categoria, bool>> where)
        {
            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                return await dbConnection.SelectAsync(where);
            }
        }

        public async Task<IEnumerable<Categoria>> ObterTodos()
        {
            using (SqlConnection dbConnetion = new SqlConnection(connectionString))
            {
                return await dbConnetion.GetAllAsync<Categoria>();
            }
        }

        public async Task Adicionar(Categoria categoria)
        {
            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                await dbConnection.InsertAsync(categoria);
            }
        }

        public async Task Alterar(Categoria categoria)
        {
            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                await dbConnection.UpdateAsync(categoria);
            }
        }

        public async Task Excluir(Categoria categoria)
        {
            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                await dbConnection.DeleteAsync(categoria);
            }
        }
    }
}

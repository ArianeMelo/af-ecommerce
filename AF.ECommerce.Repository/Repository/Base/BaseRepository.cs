using AF.ECommerce.Domain.Entities;
using AF.ECommerce.Domain.Interfaces.Repository;
using Dapper;
using Dommel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AF.ECommerce.Repository.Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        protected IUnityOfWork UnityOfWork;
        public BaseRepository(IUnityOfWork unitOfWork)
        {
            UnityOfWork = unitOfWork;
        }

        public void AtribuirTransacao(IUnityOfWork unityOfWork) => UnityOfWork = unityOfWork;

        public virtual async Task<IEnumerable<T>> ObterTodos()
        {
            return await UnityOfWork.Connection.GetAllAsync<T>();
        }

        public virtual async Task Adicionar(T entity)
        {
            await UnityOfWork.Connection.InsertAsync(entity, UnityOfWork.Transaction);
        }

        public virtual async Task Alterar(T entity)
        {
            await UnityOfWork.Connection.UpdateAsync(entity, UnityOfWork.Transaction);
        }

        public virtual async Task Excluir(T entity)
        {
            await UnityOfWork.Connection.DeleteAsync(entity, UnityOfWork.Transaction);
        }

        public virtual async Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> where)
        {
            return await UnityOfWork.Connection.SelectAsync<T>(where);
        }

        public virtual async Task<T> ObterPorId(Guid id)
        {
            return await UnityOfWork.Connection.GetAsync<T>(id);
        }

        //Os Métodos abaixo são de exemplos e não estão na interface 

        protected async Task<IEnumerable<T>> ObterTodosComQuerySql(string sql)
        {
            return await UnityOfWork.Connection.QueryAsync<T>(sql, UnityOfWork.Transaction);
        }

        protected async Task InserirLista(List<T> entity)
        {
            await UnityOfWork.Connection.InsertAsync(entity, UnityOfWork.Transaction);
        }
        public virtual async Task AlterarLista(List<T> entity)
        {
            await UnityOfWork.Connection.UpdateAsync(entity, UnityOfWork.Transaction);
        }

        public virtual async Task DeletarLista(List<T> entity)
        {
            await UnityOfWork.Connection.DeleteAsync(entity, UnityOfWork.Transaction);
        }

        protected async Task AdicionarComDynamiCParameters(string sql, List<DynamicParameters> dynamicParameters)
        {
            try
            {
                await UnityOfWork.Connection.ExecuteAsync(sql, dynamicParameters, UnityOfWork.Transaction, TimeSpan.FromSeconds(30).Seconds, CommandType.Text);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
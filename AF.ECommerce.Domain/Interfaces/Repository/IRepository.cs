using AF.ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AF.ECommerce.Domain.Interfaces.Repository
{
    public interface IRepository<T> where T : Entity
    {
        Task<IEnumerable<T>> ObterTodos();
        Task<T> ObterPorId(Guid id);
        Task Adicionar(T entity);
        Task Alterar(T entity);
        Task Excluir(T entity);
        Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> where);
        void AtribuirTransacao(IUnityOfWork unityOfWork);
    }
}

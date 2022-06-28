using AF.ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AF.ECommerce.Domain.Interfaces.Repository
{
    public interface ICategoriaRepository
    {
        Task<Categoria> ObterPorId(Guid id);
        Task<IEnumerable<Categoria>> ObterPorDescricao(Expression<Func<Categoria, bool>> where);
        Task<IEnumerable<Categoria>> ObterTodos();
        Task Adicionar(Categoria categoria);
        Task Alterar(Categoria categoria);
        Task Excluir(Categoria categoria);
    }
}

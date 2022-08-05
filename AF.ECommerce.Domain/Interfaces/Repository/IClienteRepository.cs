using AF.ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AF.ECommerce.Domain.Interfaces.Repository
{
    public interface IClienteRepository
    {
        Task<Cliente> ObterPorId(Guid id);
        Task<IEnumerable<Cliente>> ObterPorCpf(Expression<Func<Cliente, bool>> where);
        Task<IEnumerable<Cliente>> ObterTodos();
        Task<bool> Adicionar(Cliente cliente);
        Task Alterar(Cliente cliente);
        Task Excluir(Cliente cliente);

    }
}

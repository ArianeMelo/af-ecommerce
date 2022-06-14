using AF.ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AF.ECommerce.Domain.Interfaces.Application
{
    public interface IClienteApplication
    {
        Task<Cliente> ObterPorId(Guid id);
        Task<IEnumerable<Cliente>> ObterPorCpf(Expression<Func<Cliente, bool>> where);
        Task<IEnumerable<Cliente>> ObterTodos();
        Task Adicionar(Cliente cliente);
        Task Atualizar(Cliente cliente);
        Task Excluir(Cliente cliente);
       
    }
}

using AF.ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AF.ECommerce.Domain.Interfaces.Application
{
    public interface IProdutoApplication
    {
        Task<Produto> ObterPorId(Guid id);
        Task<IEnumerable<Produto>> ObterTodos();
        Task Adicionar(Produto produto);
        Task Alterar(Produto produto);
        Task Excluir(Produto produto);
    }
}

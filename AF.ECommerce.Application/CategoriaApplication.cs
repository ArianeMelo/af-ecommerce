using AF.ECommerce.Domain.Entities;
using AF.ECommerce.Domain.Interfaces.Application;
using AF.ECommerce.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AF.ECommerce.Application
{
    public class CategoriaApplication : ICategoriaApplication
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaApplication(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<Categoria> ObterPorId(Guid id)
        {
            return await _categoriaRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<Categoria>> ObterPorDescricao(Expression<Func<Categoria, bool>> where)
        {
            return await _categoriaRepository.ObterPorDescricao(where);
        }

        public async Task<IEnumerable<Categoria>> ObterTodos()
        {
            return await _categoriaRepository.ObterTodos();
        }

        public async Task Adicionar(Categoria categoria)
        {
            await _categoriaRepository.Adicionar(categoria);
        }

        public async Task Alterar(Categoria categoria)
        {
            await _categoriaRepository.Alterar(categoria);
        }

        public async Task Excluir(Categoria categoria)
        {
            await _categoriaRepository.Excluir(categoria);
        }
    }
}

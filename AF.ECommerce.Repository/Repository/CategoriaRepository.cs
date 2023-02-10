using AF.ECommerce.Domain.Entities;
using AF.ECommerce.Domain.Interfaces.Repository;
using AF.ECommerce.Repository.Repository.Base;
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
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {

        public CategoriaRepository(IUnityOfWork unitOfWork)
            : base(unitOfWork)
        { }

        public override async Task<Categoria> ObterPorId(Guid id)
        {
            return await base.ObterPorId(id);
        }

        public override async Task<IEnumerable<Categoria>> ObterTodos()
        {
            return await base.ObterTodos();
        }
        public override async Task Adicionar(Categoria categoria)
        {
            await base.Adicionar(categoria);
        }

        public override async Task Alterar(Categoria categoria)
        {
            await base.Alterar(categoria);
        }

        public override async Task Excluir(Categoria categoria)
        {
            await base.Excluir(categoria);
        }
        public async Task<IEnumerable<Categoria>> ObterPorDescricao(Expression<Func<Categoria, bool>> where)
        {
            return await base.Buscar(where);
        }
    }
}

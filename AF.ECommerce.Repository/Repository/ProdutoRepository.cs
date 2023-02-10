using AF.ECommerce.Domain.Entities;
using AF.ECommerce.Domain.Interfaces.Repository;
using AF.ECommerce.Repository.Repository.Base;
using Dommel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace AF.ECommerce.Repository.Repository
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(IUnityOfWork unitOfWork)
             : base(unitOfWork)
        { }
        public async Task<Produto> ObterPorId(Guid id)
        {
            return await base.ObterPorId(id);
        }

        public override async Task<IEnumerable<Produto>> ObterTodos()
        {
            return await base.ObterTodos();
        }

        public override async Task Adicionar(Produto produto)
        {
            await base.Adicionar(produto);
        }

        public override async Task Alterar(Produto produto)
        {
            await base.Alterar(produto);
        }

        public override async Task Excluir(Produto produto)
        {
            await base.Excluir(produto);
        }
    }
}

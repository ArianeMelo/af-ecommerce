using AF.ECommerce.Domain.Entities;
using AF.ECommerce.Domain.Interfaces.Repository;
using AF.ECommerce.Repository.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AF.ECommerce.Repository.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(IUnityOfWork unitOfWork)
            : base(unitOfWork)
        { }

        public override async Task<Cliente> ObterPorId(Guid id)
        {
            return await base.ObterPorId(id);
        }

        public override async Task<IEnumerable<Cliente>> ObterTodos()
        {
            return await base.ObterTodos();
        }

        //public async Task<bool> Adicionar(Cliente cliente)
        //{
        //    await base.Adicionar(cliente);
        //    return true;
        //}

        public override async Task Adicionar(Cliente cliente)
        {
            await base.Adicionar(cliente);
        }

        public override async Task Alterar(Cliente cliente)
        {
            await base.Alterar(cliente);
        }

        public override async Task Excluir(Cliente cliente)
        {
            await base.Excluir(cliente);
        }

        public override async Task<IEnumerable<Cliente>> Buscar(Expression<Func<Cliente, bool>> where)
        {
            return await base.Buscar(where);
        }
    }
}

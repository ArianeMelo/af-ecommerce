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
    public class ClienteApplication : IClienteApplication
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteApplication(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> ObterPorId(Guid id)
        {
            return await _clienteRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<Cliente>> ObterPorCpf(Expression<Func<Cliente, bool>> where)
        {
            return await _clienteRepository.ObterPorCpf(where);
        }

        public async Task<IEnumerable<Cliente>> ObterTodos()
        {
            return await _clienteRepository.ObterTodos();
        }

        public async Task Adicionar(Cliente cliente)
        {
            await _clienteRepository.Adicionar(cliente);
        }

        public async Task Alterar(Cliente cliente)
        {
            await _clienteRepository.Alterar(cliente); 
        }

        public async Task Excluir(Cliente cliente)
        {
            await _clienteRepository.Excluir(cliente);
        }
    }
}

using AF.ECommerce.Domain.Entities;
using AF.ECommerce.Domain.Interfaces.Application;
using AF.ECommerce.Domain.Interfaces.Repository;
using AF.ECommerce.Domain.Validadores.Interface;
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
        private readonly ICep _cep;
        private readonly ICpf _cpf;

        public ClienteApplication(IClienteRepository clienteRepository, ICep cep, ICpf cpf)
        {
            _clienteRepository = clienteRepository;
            _cep = cep;
            _cpf = cpf;
        }

        public async Task<Cliente> ObterPorId(Guid id)
        {
            return await _clienteRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<Cliente>> ObterPorCpf(Expression<Func<Cliente, bool>> where)
        {
            return await _clienteRepository.Buscar(where);
        }
         
        public async Task<IEnumerable<Cliente>> ObterTodos()
        {
            return await _clienteRepository.ObterTodos();
        }

         public async Task<bool> Adicionar(Cliente cliente)
         {

            var cpfvalido = _cpf.ValidarCpf(cliente.Cpf);
            if (!cpfvalido)
                return false;


            var cepValido = await _cep.ValidarCep(cliente.Cep);
            if (cepValido.Cep == null)
                return false;

            await _clienteRepository.Adicionar(cliente);

            return true;
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

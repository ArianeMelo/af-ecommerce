using AF.ECommerce.API.ViewModel;
using AF.ECommerce.Domain.Entities;
using AF.ECommerce.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AF.ECommerce.API.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteApplication _clienteApplication;

        public ClienteController(IClienteApplication clienteApplication)
        {
            _clienteApplication = clienteApplication;
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {      

            Cliente cliente = await _clienteApplication.ObterPorId(id); 

            if (cliente == null)
                return NotFound(MensagemErro.erroClienteNaoCadastrado);

            return Ok(cliente);
           
        }

        [HttpGet("{cpf}")]
        public async Task<IActionResult> ObterPorCpf(string cpf)
        {
            IEnumerable<Cliente> clientes = await _clienteApplication.ObterPorCpf(
                cli => cli.Cpf == cpf);

            Cliente cliente = clientes.FirstOrDefault();

            if (cliente == null)
                return NotFound(MensagemErro.erroClienteNaoCadastrado);

            return Ok(cliente);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return Ok(await _clienteApplication.ObterTodos());
        }
        
        [HttpPost]
        public async Task<IActionResult> Adicionar(ClientePostViewModel clientePostViewModel)
        {
            try
            {
                IEnumerable<Cliente> clientes = await _clienteApplication.ObterPorCpf(
               cli => cli.Cpf == clientePostViewModel.Cpf);

                Cliente cliente = clientes.FirstOrDefault();

                if (cliente != null)
                    return BadRequest(MensagemErro.erroClienteNaoCadastrado);

                if (string.IsNullOrWhiteSpace(clientePostViewModel.Telefone) || string.IsNullOrWhiteSpace(clientePostViewModel.Endereco) || string.IsNullOrWhiteSpace(clientePostViewModel.Cidade) ||
                    string.IsNullOrWhiteSpace(clientePostViewModel.Estado) || string.IsNullOrWhiteSpace(clientePostViewModel.Cep))
                return BadRequest(MensagemErro.erroStringVazio);

                if (clientePostViewModel.Numero < 1)
                    return BadRequest(MensagemErro.erroNumeroInvalido);


                cliente = new Cliente
                {
                    Nome = clientePostViewModel.Nome,
                    Cpf = clientePostViewModel.Cpf,
                    Rg = clientePostViewModel.Rg,
                    Telefone = clientePostViewModel.Telefone,
                    Endereco = clientePostViewModel.Endereco,
                    Numero = clientePostViewModel.Numero,
                    Cidade = clientePostViewModel.Cidade,
                    Estado = clientePostViewModel.Estado,
                    Cep = clientePostViewModel.Cep
                };

                await _clienteApplication.Adicionar(cliente);

                return Ok(cliente.Id);
              
            }
            catch (Exception)
            {
                throw;
            }        
            

        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Alterar(Guid id, [FromBody] ClientePutViewModel clientePutViewModel)
        {
            try
            {
                Cliente cliente = await _clienteApplication.ObterPorId(id);

                if (cliente == null)
                    return BadRequest(MensagemErro.erroClienteNaoCadastrado);              
                                              
                if(string.IsNullOrWhiteSpace(clientePutViewModel.Telefone) || string.IsNullOrWhiteSpace(clientePutViewModel.Endereco) || string.IsNullOrWhiteSpace(clientePutViewModel.Cidade) ||
                    string.IsNullOrWhiteSpace(clientePutViewModel.Estado) || string.IsNullOrWhiteSpace(clientePutViewModel.Cep))
                return BadRequest(MensagemErro.erroStringVazio);

                if(clientePutViewModel.Numero < 1)
                    return BadRequest(MensagemErro.erroNumeroInvalido);


                cliente.Endereco = clientePutViewModel.Endereco;
                cliente.Numero = clientePutViewModel.Numero;
                cliente.Cidade = clientePutViewModel.Cidade;
                cliente.Estado = clientePutViewModel.Estado;
                cliente.Cep = clientePutViewModel.Cep;

                await _clienteApplication.Alterar(cliente);

                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            try
            {
                Cliente cliente = await _clienteApplication.ObterPorId(id);

                if (cliente == null)
                    return BadRequest(MensagemErro.erroClienteNaoCadastrado);

                cliente.Id = id;

                await _clienteApplication.Excluir(cliente);


                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

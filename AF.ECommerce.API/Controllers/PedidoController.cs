using AF.ECommerce.API.Factory;
using AF.ECommerce.API.ViewModel;
using AF.ECommerce.Domain.Entities;
using AF.ECommerce.Domain.Enum;
using AF.ECommerce.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AF.ECommerce.API.Controllers
{
    [Route("api/pedidos")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoApplication _pedidoApplication;
        private readonly IClienteApplication _clienteApplication;
        private readonly IProdutoApplication _produtoApplication;
        private readonly IPedidoItemApplication _pedidoItemApplication;

        public PedidoController(
            IPedidoApplication pedidoApplication,
            IClienteApplication clienteApplication,
            IProdutoApplication produtoApplication,
            IPedidoItemApplication pedidoItemApplication)
        {
            _pedidoApplication = pedidoApplication;
            _clienteApplication = clienteApplication;
            _produtoApplication = produtoApplication;
            _pedidoItemApplication = pedidoItemApplication;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var pedido = await _pedidoApplication.ObterPorId(id);
            if (pedido == null)
                return NotFound(MensagemErro.erroPedidoNaoCadastrado);

            return Ok(pedido);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return Ok(await _pedidoApplication.ObterTodos());
        }

        [HttpPost("{criar}")]
        public async Task<IActionResult> Adicionar(PedidoPostViewModel pedidoPostViewModel)
        {

            if (!pedidoPostViewModel.EstiverValido())
                return BadRequest(pedidoPostViewModel.ValidationResult.Errors.Select(erro => erro.ErrorMessage));

            var cliente = await _clienteApplication.ObterPorId(pedidoPostViewModel.ClienteId);
            if (cliente == null)
                return NotFound(MensagemErro.erroClienteNaoCadastrado);

          // var pedido = PedidoViewModelToPedidoFactory.Criar(pedidoPostViewModel);

            var pedido = new Pedido(pedidoPostViewModel.ClienteId, pedidoPostViewModel.TipoFrete, pedidoPostViewModel.Observacao);

            pedidoPostViewModel.Itens.ForEach(item =>
            {
                var pedidoItem = new PedidoItem(pedido.Id, item.ProdutoId, item.Quantidade, item.Valor, item.Desconto);

                pedido.AdicionarItem(pedidoItem);
            });
                     
            var estoqueSuficente = await _pedidoApplication.AdicionarPedido(pedido);
            if (!estoqueSuficente)
                return BadRequest("Produto Indisponível");

            return Ok(pedido);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Alterar(Guid id,[FromBody] PedidoPutViewModel pedidoPutViewModel)
        {                  

            if (!pedidoPutViewModel.EstiverValido())            
                return BadRequest(pedidoPutViewModel.ValidationResult.Errors.Select(erro => erro.ErrorMessage));
           

            var cliente = await _clienteApplication.ObterPorId(pedidoPutViewModel.ClienteId);
            if (cliente == null)
                return NotFound(MensagemErro.erroClienteNaoCadastrado);

            var pedido = await _pedidoApplication.ObterPorId(id);
            if (pedido == null)
                return NotFound(MensagemErro.erroPedidoNaoCadastrado);

            pedido.Id = id; 
            pedido.ClienteId = pedidoPutViewModel.ClienteId;
            pedido.Valor = pedidoPutViewModel.Valor;
            pedido.Observacao = pedidoPutViewModel.Observacao;              

            await _pedidoApplication.Alterar(pedido);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var pedido = await _pedidoApplication.ObterPorId(id);

            if (pedido == null)
                return BadRequest(MensagemErro.erroPedidoNaoCadastrado);

            pedido.Id = id;

            await _pedidoApplication.Excluir(pedido);

            return NoContent();

        }
    }
}

using AF.ECommerce.API.ViewModel;
using AF.ECommerce.Domain.Entities;
using AF.ECommerce.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AF.ECommerce.API.Controllers
{
    [Route("api/itens-pedido")]
    [ApiController]
    public class PedidoItemController : ControllerBase
    {
        private readonly IPedidoItemApplication _pedidoItemApplication;
        private readonly IPedidoApplication _pedidoApplication;
        private readonly IProdutoApplication _produtoApplication;

        public PedidoItemController(
            IPedidoItemApplication pedidoItemApplication,
            IPedidoApplication pedidoApplication,
            IProdutoApplication produtoApplication)
        {
            _pedidoItemApplication = pedidoItemApplication;
            _pedidoApplication = pedidoApplication;
            _produtoApplication = produtoApplication;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var pedidoItem = await _pedidoItemApplication.ObterPorId(id);
            if (pedidoItem == null)
                return NotFound(MensagemErro.erroPedidoNaoCadastrado);

            return Ok(await _pedidoItemApplication.ObterPorId(id));
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return Ok(await _pedidoItemApplication.ObterTodos());
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(PedidoItemPostViewModel pedidoItemPostViewModel)
        {
            if (!pedidoItemPostViewModel.EstiverValido())           
                return BadRequest(pedidoItemPostViewModel.ValidationResult.Errors.Select(erro => erro.ErrorMessage));

            var produto = await _produtoApplication.ObterPorId(pedidoItemPostViewModel.ProdutoId);
            if (produto == null)
                return NotFound(MensagemErro.erroProdutoNaoCadastrado);


            var pedido = await _pedidoApplication.ObterPorId(pedidoItemPostViewModel.PedidoId);
            if (pedido == null)
                return NotFound(MensagemErro.erroPedidoNaoCadastrado);  
              

            var pedidoItem = new PedidoItem()
            {
                PedidoId = pedidoItemPostViewModel.PedidoId,
                ProdutoId = pedidoItemPostViewModel.ProdutoId,
                Quantidade = pedidoItemPostViewModel.Quantidade,
                Valor = pedidoItemPostViewModel.Valor,
                Desconto = pedidoItemPostViewModel.Desconto
            };

            await _pedidoItemApplication.Adicionar(pedidoItem);

            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Alterar(Guid id, [FromBody] PedidoItemPutViewModel pedidoItemPutViewModel)
        {
            if (!pedidoItemPutViewModel.EstiverValido())
                 return BadRequest(pedidoItemPutViewModel.ValidationResult.Errors.Select(pedido => pedido.ErrorMessage));

            var produto = await _produtoApplication.ObterPorId(pedidoItemPutViewModel.ProdutoId);
            if (produto == null)
                return NotFound(MensagemErro.erroProdutoNaoCadastrado);

            var pedido = await _pedidoApplication.ObterPorId(pedidoItemPutViewModel.PedidoId);
            if (pedido == null)
                return NotFound(MensagemErro.erroPedidoNaoCadastrado);

            var pedidoItem = await _pedidoItemApplication.ObterPorId(id);
            if (pedidoItem == null)
                return NotFound(MensagemErro.erroPedidoItemNaoCadastrado);

            pedidoItem.Quantidade = pedidoItemPutViewModel.Quantidade;
            pedidoItem.Valor = pedidoItemPutViewModel.Valor;
            pedidoItem.Desconto = pedidoItemPutViewModel.Desconto;

            await _pedidoItemApplication.Alterar(pedidoItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var pedidoItem = await _pedidoItemApplication.ObterPorId(id);

            if (pedidoItem == null)
                return NotFound(MensagemErro.erroPedidoItemNaoCadastrado);

            pedidoItem.Id = id;

            await _pedidoItemApplication.Excluir(pedidoItem);

            return NoContent();
        }
    }
}

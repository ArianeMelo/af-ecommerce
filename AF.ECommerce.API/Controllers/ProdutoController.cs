using AF.ECommerce.API.ViewModel;
using AF.ECommerce.Domain.Entities;
using AF.ECommerce.Domain.Interfaces.Application;
using AF.ECommerce.Domain.Interfaces.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AF.ECommerce.API.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoApplication _produtoApplication;
        private readonly ICategoriaApplication _categoriaApplication;
        //private readonly IMapper _mapper;

        public ProdutoController(
            IProdutoApplication produtoApplication, 
            ICategoriaApplication categoriaApplication)
            //, IMapper mapper)
        {
            _produtoApplication = produtoApplication;
            _categoriaApplication = categoriaApplication;
            //_mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var produto = await _produtoApplication.ObterPorId(id);
            if (produto == null)
                return NotFound(MensagemErro.erroProdutoNaoCadastrado);

            return Ok(produto); 
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return Ok(await _produtoApplication.ObterTodos());

            //Mudar ProdutoPostViewModel para Get 
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(ProdutoPostViewModel produtoPostViewModel)
        {
            if (!produtoPostViewModel.EstiverValido())
                return BadRequest(produtoPostViewModel.ValidationResult.Errors.Select(produto => produto.ErrorMessage));
            
            var categoria = await _categoriaApplication.ObterPorId(produtoPostViewModel.CategoriaId);
            if (categoria == null)
                return NotFound(MensagemErro.erroCategoriaNaoCadastrada);

            var produto = new Produto()
            {
                CategoriaId = produtoPostViewModel.CategoriaId,
                Codigo = produtoPostViewModel.Codigo,
                Descricao = produtoPostViewModel.Descricao,
                Valor = produtoPostViewModel.Valor,
                TipoProduto = produtoPostViewModel.TipoProduto,
                Estoque = produtoPostViewModel.Estoque,
                Ativo = produtoPostViewModel.Ativo
            };

            await _produtoApplication.Adicionar(produto);

            return Ok(); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Alterar(Guid id, [FromBody] ProdutoPutViewModel produtoPutViewModel)
        {
            if (!produtoPutViewModel.EstiverValido())
                return BadRequest(produtoPutViewModel.ValidationResult.Errors.Select(produto => produto.ErrorMessage));

            var produto = await _produtoApplication.ObterPorId(id);
            if (produto == null)
                return NotFound(MensagemErro.erroProdutoNaoCadastrado);

            var categoria = await _categoriaApplication.ObterPorId(produtoPutViewModel.CategoriaId);
            if (categoria == null)
                return NotFound(MensagemErro.erroCategoriaNaoCadastrada);

            produto.Id = id;
            produto.CategoriaId = produtoPutViewModel.CategoriaId;
            produto.Codigo = produtoPutViewModel.Codigo;
            produto.Descricao = produtoPutViewModel.Descricao;
            produto.Estoque = produtoPutViewModel.Estoque;
            produto.TipoProduto = produtoPutViewModel.TipoProduto;
            produto.Valor = produtoPutViewModel.Valor;
            produto.Ativo = produtoPutViewModel.Ativo;

            await _produtoApplication.Alterar(produto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var produto = await _produtoApplication.ObterPorId(id);
            if (produto == null)
                return NotFound(MensagemErro.erroProdutoNaoCadastrado);

            produto.Id = id;

            await _produtoApplication.Excluir(produto);

            return NoContent();
        }
    }
}

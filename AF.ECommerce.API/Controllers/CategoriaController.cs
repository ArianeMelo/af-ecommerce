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
    [Route("api/categorias")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaApplication _categoriaApplication;

        public CategoriaController(ICategoriaApplication categoriaApplication)
        {
            _categoriaApplication = categoriaApplication;
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var categoria = await _categoriaApplication.ObterPorId(id);
            if (categoria == null)
                return BadRequest(MensagemErro.erroCategoriaNaoCadastrada);

            return Ok(categoria);
        }

        [HttpGet("{descricao}")]
        public async Task<IActionResult> ObterPorDescricao(string descricao)
        {
            IEnumerable<Categoria> categorias = await _categoriaApplication.ObterPorDescricao(
                cli => cli.Descricao == descricao);

            Categoria categoria = categorias.FirstOrDefault();

            if (categoria == null)
                return NotFound(MensagemErro.erroDescCategoriaNaoCadastrada);

            return Ok(categoria);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return Ok(await _categoriaApplication.ObterTodos());
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(CategoriaPostViewModel categotiaPostViewModel)
        {
            IEnumerable<Categoria> categorias = await _categoriaApplication.ObterPorDescricao(
               cli => cli.Descricao == categotiaPostViewModel.Descricao);

            Categoria categoria = categorias.FirstOrDefault();

            if (categoria != null)
                return NotFound(MensagemErro.erroDescCategoriaNaoCadastrada);

            categoria = new Categoria()
            {
                Descricao = categotiaPostViewModel.Descricao
            };

            await _categoriaApplication.Adicionar(categoria);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Alterar(Guid id , [FromBody] CategoriaPutViewModel categoriaPutViewModel)
        {
            Categoria categoria = await _categoriaApplication.ObterPorId(id);

            if (categoria == null)
                return BadRequest(MensagemErro.erroCategoriaNaoCadastrada);
                     
            categoria.Id = id;
            categoria.Descricao = categoriaPutViewModel.Descricao;

            await _categoriaApplication.Alterar(categoria);
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            Categoria categoria = await _categoriaApplication.ObterPorId(id);

            if (categoria == null)
                return BadRequest(MensagemErro.erroCategoriaNaoCadastrada);

            categoria.Id = id;

            await _categoriaApplication.Excluir(categoria);

            return NoContent();
        }
    }
}

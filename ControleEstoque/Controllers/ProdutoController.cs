using ControleEstoque.Domain.Dtos;
using ControleEstoque.Domain.Model;
using ControleEstoque.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ControleEstoque.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        /// <summary>
        /// Adiciona um novo produto
        /// </summary>
        /// <param name="produtoDto"></param>
        /// <returns>Dados do novo produto</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AdicionaProduto([FromBody] CreateProdutoDto produtoDto)
        {
            Produto produto = _produtoService.AdicionaProduto(produtoDto);
            if (produto != null) return Ok(produto);
            return NotFound();            
        }

        /// <summary>
        /// Consulta um produto por filtro
        /// </summary>
        /// <returns>Lista com dados dos produtos</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RecuperaProdutos(bool ativo = true, int skip = 0, int take = 10)
        {
            List<Produto> produtos = _produtoService.RecuperaProdutos(ativo, skip, take);
            if (produtos != null) return Ok(produtos);
            return NotFound();
        }

        /// <summary>
        /// Consulta produto por id
        /// </summary>
        /// <param name="id">Identificador do produto</param>
        /// <returns>Dados do produto</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RecuperaProdutoPorId(int id)
        {
            Produto produto = _produtoService.RecuperaProdutoPorId(id);
            if (produto != null) return Ok(produto);
            return NotFound("Produto não encontrado");
        }

        /// <summary>
        /// Atualiza dados do produto
        /// </summary>
        /// <returns>Dados atualizados do produto</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não atualizado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AtualizaProduto(int id, [FromBody] UpdateProdutoDto produtoDto)
        {
            Produto produto = _produtoService.AtualizaProduto(id, produtoDto);
            if (produto != null) return Ok(produto);
            return NotFound("O produto não foi atualizado.");
        }

        /// <summary>
        /// Atualiza um produto como inativo
        /// </summary>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeletaProduto(int id)
        {
            var result = _produtoService.DeletaProduto(id);

            if (result == false) return NotFound("Produto não encontrado");
            return Ok("Produto está inativo!");
        }
    }
}

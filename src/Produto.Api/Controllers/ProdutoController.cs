using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Produto.Aplicacao;
using Produto.Dominio.Entidades;
using Produto.Api.Models.Requisicao;
using Produto.Api.Models.Resposta;

namespace Produto.Api;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoAplicacao _produtoAplicacao;

    public ProdutoController(IProdutoAplicacao produtoAplicacao)
    {
        _produtoAplicacao = produtoAplicacao;
    }

    #region  Métodos Get

    [HttpGet]
    [Route("obter/{produtoId}")]
    public async Task<ActionResult> Obter([FromRoute] int produtoId)
    {
        try
        {
            var produtoDominio = await _produtoAplicacao.ObterProduto(produtoId);

            if (produtoDominio == null)
                return NotFound("Produto não encontrado. ");

            var resposta = new ProdutoResposta() // Transforma o Dominio em um DTO de resposta, usando classe ProdutoResposta
            {
                ProdutoId = produtoDominio.ProdutoId,
                Nome = produtoDominio.Nome,
                Preco = produtoDominio.Preco,
                Quantidade = produtoDominio.Quantidade
            };
            return Ok(resposta);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("Listar")]

    public async Task<ActionResult> Listar()
    {
        try
        {
            var listarProdutoDominio = await _produtoAplicacao.ListarProdutos();

            // MAPEAMENTO DE LISTA: Converti cada item da lista em um ProdutoResposta
            // Usie o .Select do LINQ para fazer isso de forma rápida e limpa
            var listarResposta = listarProdutoDominio.Select(produto => new ProdutoResposta()
            {
                ProdutoId = produto.ProdutoId,
                Nome = produto.Nome,
                Preco = produto.Preco,
                Quantidade = produto.Quantidade
            }).ToList();


            return Ok(listarResposta);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    #endregion


    #region  Método Post
    [HttpPost]
    [Route("Adicionar")]
    public async Task<ActionResult> Adicionar([FromBody] ProdutoCriar produtoCriar)
    {
        try
        {
            var produtoDominio = new Produtos()
            {
                Preco = produtoCriar.Preco,
                Quantidade = produtoCriar.Quantidade,
                Nome = produtoCriar.Nome,

            };

            var produtoId = _produtoAplicacao.AdicionarProduto(produtoDominio);
            return Ok(produtoId);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    #endregion



    #region  Método Put

    [HttpPut]
    [Route("Atualizar")]
    public async Task<ActionResult> Atualizar([FromBody] ProdutoAtualizar produtoAtualizar)
    {
        try
        {
            var produtoDominio = new Produtos()
            {
                ProdutoId = produtoAtualizar.ProdutoId,
                Preco = produtoAtualizar.Preco,
                Quantidade = produtoAtualizar.Quantidade,
                Nome = produtoAtualizar.Nome,
            };
            var produtoId = _produtoAplicacao.AtualizarProduto(produtoDominio);
            return Ok(produtoId);
        }

        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    #endregion


    #region  Método Delete

    [HttpDelete]
    [Route("Deletar/{id}")]

    public async Task<ActionResult> Deletar([FromRoute] int id)
    {
        try
        {
            var produtoDominio = await _produtoAplicacao.ObterProduto(id);

            await _produtoAplicacao.DeletarProduto(produtoDominio.ProdutoId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    #endregion
}
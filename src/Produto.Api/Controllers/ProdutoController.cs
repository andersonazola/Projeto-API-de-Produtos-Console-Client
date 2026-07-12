using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Produto.Aplicacao;
using Produto.Dominio.Entidades;
using Produto.Api.Models.Requisicao;

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

    [HttpGet]
    [Route("obter/{produtoId}")]
    public async Task<ActionResult> Obter([FromRoute] int produtoId)
    {
        try
        {
            var produtoDominio = await _produtoAplicacao.ObterProduto(produtoId);
            return Ok(produtoDominio);
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
            var produtoDominio =  await _produtoAplicacao.ListarProdutos();
            return Ok(produtoDominio);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


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

            var produtoId =  _produtoAplicacao.AdicionarProduto(produtoDominio);
            return Ok(produtoId);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("Atualizar")]
    public async Task<ActionResult> Atualizar([FromBody] ProdutoAtualizar produtoAtualizar)
    {
        try
        {
            var produtoDominio = new Produtos()
            {
                Preco = produtoAtualizar.Preco,
                Quantidade = produtoAtualizar.Quantidade,
                Nome = produtoAtualizar.Nome,
            };
            var produtoId =  _produtoAplicacao.AtualizarProduto(produtoDominio);
            return Ok(produtoId);
        }

        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


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


}
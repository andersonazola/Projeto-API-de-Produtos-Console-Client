using System.Collections;
using System;
using Produto.Dominio.Entidades;
using Produto.Dominio.Interfaces;


namespace Produto.Aplicacao;


public class ProdutoAplicacao : IProdutoAplicacao
{

    readonly IProdutoRepositorio _produtoRepositorio;

    public ProdutoAplicacao(IProdutoRepositorio produtoRepositorio)
    {
        _produtoRepositorio = produtoRepositorio;
    }


    public async Task AdicionarProduto(Produtos produto)
    {
        var prod = new Produtos(produto.Preco, produto.Nome, produto.Quantidade);

        await _produtoRepositorio.AdicionarProduto(prod);
    }

    public async Task AtualizarProduto(Produtos produto)
    {
        var prodDominio = await _produtoRepositorio.ObterProduto(produto.ProdutoId);

        if (prodDominio == null)
            throw new Exception("Produto não encontrado.");

        prodDominio.AtualizarDados(produto.Preco, produto.Quantidade, produto.Nome);

        await _produtoRepositorio.AtualizarProduto(prodDominio);
    }

    public async Task DeletarProduto(int id)
    {
        var produto = await ObterProduto(id);
        if (produto == null)
            throw new ArgumentException("Id não encontrado");
        await _produtoRepositorio.DeletarProduto(id);
    }

    public async Task<List<Produtos>> ListarProdutos()
    {
        return await _produtoRepositorio.ListarProdutos();
    }

    public async Task<Produtos> ObterProduto(int id)
    {

        var prodDominio = await _produtoRepositorio.ObterProduto(id);

        if (prodDominio == null)
            throw new Exception("Produto não encontrado.");

        return prodDominio;
    }
}



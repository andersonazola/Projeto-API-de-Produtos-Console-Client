using Produto.Dominio.Entidades;

namespace Produto.Aplicacao;

public interface IProdutoAplicacao
{
    Task AdicionarProduto(Produtos produto);
    Task AtualizarProduto(Produtos produto);
    Task DeletarProduto(int id);
    Task<Produtos> ObterProduto(int id);
    Task<List<Produtos>> ListarProdutos();
}
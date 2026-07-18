using Produto.Dominio.Entidades;

namespace Produto.Dominio.Interfaces;

public interface IProdutoRepositorio
{
    Task AdicionarProduto(Produtos produto);
    Task AtualizarProduto(Produtos produto);
    Task DeletarProduto(int id);
    Task<Produtos> ObterProduto(int id);
    Task<List<Produtos>> ListarProdutos();
}
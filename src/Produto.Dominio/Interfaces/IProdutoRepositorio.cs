using Dominio.Entidades;

namespace Dominio.Interfaces;

public interface IProdutoRepositoirio
{
    Task AdicionarProduto(Produto produto);
    Task AtualizarProduto(Produto produto);
    Task DeletarProduto(int id);
    Task<Produto> ObterProduto(int id);
    Task<List<Produto>> ListarProdutos();
}
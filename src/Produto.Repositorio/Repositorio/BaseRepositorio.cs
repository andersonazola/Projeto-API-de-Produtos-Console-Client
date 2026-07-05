using System.Data;
using Produto.Repositorio.Context;

public abstract class BaseRepositorio
{
    protected readonly ProdutoContext _contexto;

    protected BaseRepositorio(ProdutoContext contexto)
    {
        _contexto = contexto;
    }
}
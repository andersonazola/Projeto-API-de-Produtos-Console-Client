using Microsoft.EntityFrameworkCore;
using Produto.Dominio.Interfaces;
using Produto.Repositorio.Context;
using Produto.Dominio.Entidades;
using Dapper;
using System.Data;
using Microsoft.EntityFrameworkCore.Storage;


public class ProdutoRepositorio : BaseRepositorio, IProdutoRepositoirio
{
    private readonly IDbConnection _connection;
    public ProdutoRepositorio(ProdutoContext context) : base(context)
    {
        _connection = _contexto.Database.GetDbConnection();
    }

    public async Task AdicionarProduto(Produtos produto)
    {
        await _contexto.Produtos.AddAsync(produto);
        await _contexto.SaveChangesAsync();
    }

    public async Task AtualizarProduto(Produtos produto)
    {
        _contexto.Produtos.Update(produto);
        await _contexto.SaveChangesAsync();
    }

    public async Task DeletarProduto(int id)
    {
        var produto = await ObterProduto(id);
        if (produto == null)
            throw new ArgumentException("Id não encontrado");
        _contexto.Remove(produto);
        await _contexto.SaveChangesAsync();
    }

    public async Task<List<Produtos>> ListarProdutos()
    {
        // return await _contexto.Produtos.ToListAsync();

        const string sql = @"
        SELECT * 
        FROM Produtos";

        string stringDeConexao = _contexto.Database.GetDbConnection().ConnectionString;
        using var connection = new Microsoft.Data.Sqlite.SqliteConnection(stringDeConexao);
        var resultado =  await connection.QueryAsync<Produtos>(sql);
        return resultado.ToList(); // Transformei o resultado em List para atender ao retorno do método, pois consulta query multipla em dapper sempre retorna enumerable.
    }

    public async Task<Produtos?> ObterProduto(int id)
    {
        // return await _contexto.Produtos.Where(p => p.ProdutoId == id).FirstOrDefaultAsync();

        const string sql = @"
        SELECT * 
        FROM Produtos
        WHERE ProdutoId = @ProdutoID";

        string stringDeConexao = _contexto.Database.GetDbConnection().ConnectionString;
        using var connection = new Microsoft.Data.Sqlite.SqliteConnection(stringDeConexao);
        return await connection.QuerySingleOrDefaultAsync<Produtos>(sql, new { ProdutoId = id });
    }
}
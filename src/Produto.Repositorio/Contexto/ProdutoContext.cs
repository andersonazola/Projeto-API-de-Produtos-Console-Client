using Microsoft.EntityFrameworkCore;
using Produto.Dominio.Entidades;
using Produto.Repositorio.Mapeamentos;

namespace Produto.Repositorio.Context;

public class ProdutoContext : DbContext
{
    public DbSet<Produtos> Produtos { get; set; }

    public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProdutoConfig());
    }

}  
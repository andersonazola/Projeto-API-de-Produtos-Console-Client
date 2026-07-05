using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Produto.Dominio.Entidades;

namespace Produto.Repositorio.Mapeamentos;

public class ProdutoConfig : IEntityTypeConfiguration<Produtos>
{
    public void Configure(EntityTypeBuilder<Produtos> builder)
    {
        builder.ToTable("Produtos")
        .HasKey(p => p.ProdutoId);

        builder.Property(nameof(Produtos.ProdutoId)).HasColumnName("ProdutoId");
        builder.Property(nameof(Produtos.Nome)).HasColumnName("Nome")
        .HasMaxLength(100)
        .IsRequired();

        builder.Property(nameof(Produtos.Preco)).HasColumnName("Preco")
        .HasPrecision(18, 2)
        .IsRequired();

        builder.Property(nameof(Produtos.Quantidade)).HasColumnName("Quantidade")
        .IsRequired();
    }
}
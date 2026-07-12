namespace Produto.Dominio.Entidades;

public class Produtos
{
    public int ProdutoId { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; private set; }
    public int Quantidade { get; private set; }


    public Produtos(decimal preco, string nome, int quantidade)
    {
        Validar(preco, quantidade, nome);
        Nome = nome;
        Preco = preco;
        Quantidade = quantidade;

    }


    public void Validar(decimal preco, int quantidade, string nome)
    {

        if (preco < 0)
            throw new ArgumentException("Valor Inválido para Preco.");

        if (quantidade < 0)
            throw new ArgumentException("Quantidade inválida.");

        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Entrada inválida");

    }

    public void AtualizarDados(decimal preco, int quantidade, string nome)
    {
        Validar(preco, quantidade, nome);
        Nome = nome;
        Preco = preco;
        Quantidade = quantidade;



    }

}
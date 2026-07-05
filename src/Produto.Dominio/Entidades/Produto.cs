namespace Dominio.Entidades;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; private set; }
    public int Quantidade { get; private set; }


    public Produto(string nome, decimal preco, int quantidade)
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

}
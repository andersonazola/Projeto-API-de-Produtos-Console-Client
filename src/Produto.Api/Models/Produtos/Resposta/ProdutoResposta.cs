namespace Produto.Api.Models.Resposta;

public class ProdutoResposta
{
    public int ProdutoId { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }
}
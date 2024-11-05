namespace ArgosNetAPI.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string? Nome { get; set; } // Torna o Nome anulável
        public string? Descricao { get; set; } // Torna a Descricao anulável
        public decimal Preco { get; set; }
        public int QuantidadeEmEstoque { get; set; }
    }
}

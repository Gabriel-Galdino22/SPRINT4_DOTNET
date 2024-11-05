namespace ArgosNetAPI.ML
{
    public class ProductData
    {
        public float ProductId { get; set; }
        public float CategoryId { get; set; }
        public float Rating { get; set; } // Exemplo de dado de treinamento
    }

    public class ProductPrediction
    {
        public float Score { get; set; }
    }
}

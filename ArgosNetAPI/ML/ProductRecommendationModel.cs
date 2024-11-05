using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using System.Collections.Generic;
using System.Linq;
using ArgosNetAPI.ML; // Usando as definições de ProductData e ProductPrediction de ProductData.cs

namespace ArgosNetAPI.ML
{
    public class ProductRecommendationModel
    {
        private readonly MLContext _mlContext;
        private ITransformer _model;

        public ProductRecommendationModel()
        {
            _mlContext = new MLContext();
        }

        // Método para treinar o modelo com os dados fornecidos
        public void TrainModel(IEnumerable<ProductData> data)
        {
            // Agrupa os dados por ProductId e CategoryId, calculando a média de Rating para cada combinação
            var groupedData = data
                .GroupBy(d => new { d.ProductId, d.CategoryId })
                .Select(g => new ProductData
                {
                    ProductId = g.Key.ProductId,
                    CategoryId = g.Key.CategoryId,
                    Rating = g.Average(d => d.Rating) // Usa a média de Rating como valor
                }).ToList();

            // Carrega os dados agrupados para o treinamento
            var dataView = _mlContext.Data.LoadFromEnumerable(groupedData);

            // Configura o pipeline de treinamento usando fatoração de matriz
            var options = new MatrixFactorizationTrainer.Options
            {
                MatrixColumnIndexColumnName = nameof(ProductData.ProductId),
                MatrixRowIndexColumnName = nameof(ProductData.CategoryId),
                LabelColumnName = nameof(ProductData.Rating),
                NumberOfIterations = 20,
                ApproximationRank = 100
            };

            var pipeline = _mlContext.Recommendation().Trainers.MatrixFactorization(options);
            _model = pipeline.Fit(dataView);
        }

        // Método para prever a pontuação de recomendação entre dois itens
        public float Predict(int productId, int categoryId)
        {
            var predictionEngine = _mlContext.Model.CreatePredictionEngine<ProductData, ProductPrediction>(_model);

            var input = new ProductData
            {
                ProductId = productId,
                CategoryId = categoryId
            };

            return predictionEngine.Predict(input).Score;
        }
    }
}

using ArgosNetAPI.Models;
using ArgosNetAPI.Repositories;
using ArgosNetAPI.ML; // Certifique-se de importar o namespace do ML
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArgosNetAPI.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ProductRecommendationModel _recommendationModel;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
            _recommendationModel = new ProductRecommendationModel();

            // Dados de exemplo para treinamento (isso é temporário e pode ser ajustado com dados reais)
            var productData = new List<ProductData>
            {
                new ProductData { ProductId = 1, CategoryId = 1, Rating = 4 },
                new ProductData { ProductId = 2, CategoryId = 1, Rating = 5 },
                new ProductData { ProductId = 3, CategoryId = 2, Rating = 3 },
                new ProductData { ProductId = 4, CategoryId = 2, Rating = 4 },
            };
            _recommendationModel.TrainModel(productData);
        }

        public async Task<IEnumerable<Produto>> GetAllProdutosAsync()
        {
            return await _produtoRepository.GetAllAsync();
        }

        public async Task<Produto> GetProdutoByIdAsync(int id)
        {
            return await _produtoRepository.GetByIdAsync(id);
        }

        public async Task<Produto> CreateProdutoAsync(Produto produto)
        {
            await _produtoRepository.AddAsync(produto);
            return produto;
        }

        public async Task<Produto> UpdateProdutoAsync(int id, Produto produto)
        {
            var existingProduto = await _produtoRepository.GetByIdAsync(id);
            if (existingProduto == null)
            {
                return null;
            }

            // Atualiza as propriedades do produto existente
            existingProduto.Nome = produto.Nome;
            existingProduto.Descricao = produto.Descricao;
            existingProduto.Preco = produto.Preco;
            existingProduto.QuantidadeEmEstoque = produto.QuantidadeEmEstoque;

            await _produtoRepository.UpdateAsync(existingProduto);
            return existingProduto;
        }

        public async Task<bool> DeleteProdutoAsync(int id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            if (produto == null)
            {
                return false;
            }

            await _produtoRepository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<Produto>> GetRecommendedProductsAsync(int productId)
        {
            var produtos = await _produtoRepository.GetAllAsync();
            var recommendedProducts = new List<Produto>();

            foreach (var produto in produtos)
            {
                var score = _recommendationModel.Predict(productId, produto.Id);
                if (score > 3.5) // Filtra por uma pontuação mínima, ajuste conforme necessário
                {
                    recommendedProducts.Add(produto);
                }
            }

            return recommendedProducts;
        }
    }
}

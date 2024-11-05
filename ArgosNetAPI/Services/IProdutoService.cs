using ArgosNetAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArgosNetAPI.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> GetAllProdutosAsync();
        Task<Produto> GetProdutoByIdAsync(int id);
        Task<Produto> CreateProdutoAsync(Produto produto);
        Task<Produto> UpdateProdutoAsync(int id, Produto produto);
        Task<bool> DeleteProdutoAsync(int id);

        // Método para obter produtos recomendados
        Task<IEnumerable<Produto>> GetRecommendedProductsAsync(int productId);
    }
}

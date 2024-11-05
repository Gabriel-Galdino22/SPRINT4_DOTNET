using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ArgosNetAPI.Models;
using ArgosNetAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArgosNetAPI.Controllers
{
    [Authorize] // Exige autenticação JWT para acessar os endpoints
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        // GET: api/Produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            var produtos = await _produtoService.GetAllProdutosAsync();
            return Ok(produtos);
        }

        // GET: api/Produtos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await _produtoService.GetProdutoByIdAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        // POST: api/Produtos
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            var novoProduto = await _produtoService.CreateProdutoAsync(produto);
            return CreatedAtAction(nameof(GetProduto), new { id = novoProduto.Id }, novoProduto);
        }

        // PUT: api/Produtos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            var produtoAtualizado = await _produtoService.UpdateProdutoAsync(id, produto);

            if (produtoAtualizado == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Produtos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var sucesso = await _produtoService.DeleteProdutoAsync(id);

            if (!sucesso)
            {
                return NotFound();
            }

            return NoContent();
        }

        // GET: api/Produtos/recommend/{productId}
        [HttpGet("recommend/{productId}")]
        public async Task<ActionResult<IEnumerable<Produto>>> RecommendProducts(int productId)
        {
            var recommendedProducts = await _produtoService.GetRecommendedProductsAsync(productId);

            if (recommendedProducts == null || !recommendedProducts.Any())
            {
                return NotFound("No recommendations found for this product.");
            }

            return Ok(recommendedProducts);
        }
    }
}

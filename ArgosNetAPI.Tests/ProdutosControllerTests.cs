using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using ArgosNetAPI.Controllers;
using ArgosNetAPI.Models;
using ArgosNetAPI.Services;

namespace ArgosNetAPI.Tests
{
    public class ProdutosControllerTests
    {
        private readonly ProdutosController _controller;
        private readonly Mock<IProdutoService> _mockProdutoService;

        public ProdutosControllerTests()
        {
            _mockProdutoService = new Mock<IProdutoService>();
            _controller = new ProdutosController(_mockProdutoService.Object);
        }

        [Fact]
        public async Task GetProdutos_ReturnsAllProdutos()
        {
            // Arrange
            _mockProdutoService.Setup(service => service.GetAllProdutosAsync())
                .ReturnsAsync(new List<Produto> { new Produto { Nome = "Produto Teste" } });

            // Act
            var result = await _controller.GetProdutos();

            // Assert
            var produtos = Assert.IsType<OkObjectResult>(result.Result);
            Assert.NotNull(produtos.Value);
        }

        [Fact]
        public async Task GetProduto_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            _mockProdutoService.Setup(service => service.GetProdutoByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((Produto)null);

            // Act
            var result = await _controller.GetProduto(999);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}

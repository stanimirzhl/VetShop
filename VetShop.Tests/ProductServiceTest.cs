using Moq;
using NUnit.Framework;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using VetShop.Core.Interfaces;
using VetShop.Core.Models;
using VetShop.Infrastructure.Data.Common;
using VetShop.Infrastructure.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using VetShop.Core.Implementations;
using VetShop.Core;
using System.Linq.Expressions;

namespace VetShop.Tests
{
    [TestFixture]
    public class ProductServiceTests
    {
        private Mock<IRepository<Product>> _repositoryMock;
        private Mock<ILogger<ProductService>> _loggerMock;
        private Mock<ICommentService> _commentServiceMock;
        private Mock<IUserStore<ApplicationUser>> _userStoreMock;
        private Mock<UserManager<ApplicationUser>> _userManagerMock;
        private Mock<ISavedProductService> _savedProductServiceMock;
        private IProductService _productService;  // Add ProductService instance

        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<IRepository<Product>>();
            _loggerMock = new Mock<ILogger<ProductService>>();
            _commentServiceMock = new Mock<ICommentService>();
            _userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            _savedProductServiceMock = new Mock<ISavedProductService>();  // Mock SavedProductService

            // Mock UserManager<ApplicationUser>
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(
                _userStoreMock.Object,
                null,  // UserValidators
                null,  // PasswordValidators
                null,  // KeyNormalizer
                null,  // Errors
                null,  // Logger
                null,  // ClaimsFactory
                null,  // Options
                null); // UserConfirmation

            // Instantiate ProductService with mocked dependencies
            _productService = new ProductService(
                _repositoryMock.Object,
                _loggerMock.Object,
                _commentServiceMock.Object,
                _userManagerMock.Object,
                _savedProductServiceMock.Object
            );
        }

        // Test GetAllAsync
        [Test]
        public async Task GetAllAsync_ShouldReturnProducts_WhenProductsExist()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Id = 1, Title = "Product 1", Description = "Description 1", Price = 10, Quantity = 5, IsDeleted = false },
                new Product { Id = 2, Title = "Product 2", Description = "Description 2", Price = 20, Quantity = 10, IsDeleted = false }
            }.AsQueryable();

            _repositoryMock.Setup(r => r.All()).Returns(products);

            // Act
            var result = await _productService.GetAllAsync();

            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Product 1", result.First().Title);
        }

        [Test]
        public async Task GetDetailsByIdAsync_ShouldReturnProduct_WhenProductExists()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Title = "Product 1",
                Description = "Description 1",
                Price = 10,
                Quantity = 5,
                IsDeleted = false,
                Category = new Category { Name = "Category 1" },
                Brand = new Brand { BrandName = "Brand 1" }
            };

            var productList = new List<Product> { product };
            _repositoryMock.Setup(r => r.All()).Returns(productList.AsQueryable());

            // Act
            var result = await _productService.GetDetailsByIdAsync(1, 1, 10);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Product 1", result.Title);
            Assert.AreEqual("Category 1", result.CategoryName);
        }


        // Test AddAsync
        [Test]
        public async Task AddAsync_ShouldAddProduct_WhenValidProduct()
        {
            // Arrange
            var newProduct = new ProductServiceModel
            {
                Title = "New Product",
                Description = "New Product Description",
                Price = 50,
                ImageUrl = "image_url",
                CategoryId = 1,
                BrandId = 1,
                Quantity = 5
            };

            // Act
            await _productService.AddAsync(newProduct);

            // Assert
            _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Product>()), Times.Once);
        }

        [Test]
        public async Task GetDetailsByIdAsync_ShouldReturnProduct_WhenProductExists2()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Title = "Product 1",
                Description = "Description 1",
                Price = 10,
                Quantity = 5,
                IsDeleted = false,
                Category = new Category { Name = "Category 1" },
                Brand = new Brand { BrandName = "Brand 1" }
            };

            var productList = new List<Product> { product }.AsQueryable();

            // Mocking the repository to simulate async behavior
            _repositoryMock.Setup(r => r.All()).Returns(productList);


            // Act
            var result = await _productService.GetDetailsByIdAsync(1, 1, 10);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Product 1", result.Title);
            Assert.AreEqual("Category 1", result.CategoryName);
        }


        // Test DeleteAsync
        [Test]
        public async Task DeleteAsync_ShouldDeleteProduct_WhenProductExists()
        {
            // Arrange
            var product = new Product { Id = 1, Title = "Product to Delete", IsDeleted = false };

            await _productService.DeleteAsync(1);

            // Assert
            _repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
            Assert.IsTrue(product.IsDeleted);
        }

        // Test SaveProductAsync
        [Test]
        public async Task SaveProductAsync_ShouldAddSavedProduct_WhenProductExists()
        {
            // Arrange
            var userId = "user123";
            var productId = 1;

            var product = new Product { Id = 1, Title = "Product 1", Description = "Description", Price = 10 };

            _repositoryMock.Setup(r => r.GetByIdAsync(productId)).ReturnsAsync(product);

            // Act
            await _productService.SaveProductAsync(userId, productId);

            // Assert
            _savedProductServiceMock.Verify(s => s.AddSavedProduct(userId, productId), Times.Once);
        }

        // Test RemoveSavedProduct
        [Test]
        public async Task RemoveSavedProduct_ShouldRemoveSavedProduct_WhenProductExists()
        {
            // Arrange
            var userId = "user123";
            var productId = 1;

            var product = new Product { Id = 1, Title = "Product 1", Description = "Description", Price = 10 };

            _repositoryMock.Setup(r => r.GetByIdAsync(productId)).ReturnsAsync(product);

            // Act
            await _productService.RemoveSavedProduct(userId, productId);

            // Assert
            _savedProductServiceMock.Verify(s => s.RemoveSavedProduct(userId, productId), Times.Once);
        }
    }
}

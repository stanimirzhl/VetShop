using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetShop.Core;
using VetShop.Core.Implementations;
using VetShop.Core.Models;
using VetShop.Infrastructure.Data.Common;
using VetShop.Infrastructure.Data.Models;

namespace VetShop.Tests
{
    [TestFixture]
    public class BrandServiceTests
    {
        private Mock<IRepository<Brand>> mockRepo;
        private BrandService service;

        [SetUp]
        public void SetUp()
        {
            mockRepo = new Mock<IRepository<Brand>>();
            service = new BrandService(mockRepo.Object, Mock.Of<ILogger<BrandService>>()); // Provide a mock logger, but don't verify it
        }

        [Test]
        public async Task AddAsync_AddsBrandToRepository()
        {
            var newBrandModel = new BrandServiceModel { Name = "Test Brand", ImageUrl = "TestUrl" };

            mockRepo.Setup(r => r.AddAsync(It.IsAny<Brand>())).Returns(Task.CompletedTask);

            await service.AddAsync(newBrandModel);

            mockRepo.Verify(r => r.AddAsync(It.Is<Brand>(b => b.BrandName == "Test Brand" && b.ImageUrl == "TestUrl")), Times.Once);
        }

        [Test]
        public async Task GetAllAsync_ReturnsAllBrands()
        {
            var brands = new List<Brand>
            {
                new Brand { Id = 1, BrandName = "Brand 1", ImageUrl = "Url1" },
                new Brand { Id = 2, BrandName = "Brand 2", ImageUrl = "Url2" }
            };
            var result = await service.GetAllAsync();

            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.Any(b => b.Name == "Brand 1" && b.ImageUrl == "Url1"));
        }

        [Test]
        public async Task GetByIdAsync_ReturnsBrand_WhenBrandExists()
        {
            var brand = new Brand { Id = 1, BrandName = "Existing Brand", ImageUrl = "Url" };
            mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(brand);

            var result = await service.GetByIdAsync(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.Name, Is.EqualTo("Existing Brand"));
        }

        [Test]
        public void GetByIdAsync_ThrowsException_WhenBrandDoesNotExist()
        {
            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Brand)null);

            var ex = Assert.ThrowsAsync<NonExistentEntity>(async () => await service.GetByIdAsync(1));
            Assert.That(ex.Message, Is.EqualTo("Brand with ID 1 not found."));
        }

        [Test]
        public async Task DeleteAsync_DeletesBrand_WhenBrandExists()
        {
            var brand = new Brand { Id = 1, BrandName = "Brand to Delete" };
            mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(brand);
            mockRepo.Setup(r => r.DeleteAsync(1)).Returns(Task.CompletedTask);

            await service.DeleteAsync(1);

            mockRepo.Verify(r => r.DeleteAsync(1), Times.Once);
        }
    }
}

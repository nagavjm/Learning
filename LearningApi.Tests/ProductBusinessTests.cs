using LearningApi.Business;
using LearningApi.Models;
using LearningApi.Repositories;
using Xunit;

namespace LearningApi.Tests
{
    // ---------- A FAKE REPOSITORY ----------
    // Stands in for the real database so tests run instantly, with no SQL Server needed.
    // This is called a "test double" / "fake".
    public class FakeProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new();

        public List<Product> GetAll() => _products;

        public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public void Add(Product product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);
        }
    }

    // ---------- THE ACTUAL UNIT TESTS ----------
    // Each [Fact] is one independent test case.
    public class ProductBusinessTests
    {
        [Fact]
        public void AddProduct_WithValidData_AddsProduct()
        {
            // Arrange: set up the object under test with a fake repository.
            var repository = new FakeProductRepository();
            var business = new ProductBusiness(repository);

            // Act: call the method we're testing.
            var result = business.AddProduct("Keyboard", 500);

            // Assert: check the outcome is what we expect.
            Assert.Equal("Keyboard", result.Name);
            Assert.Equal(500, result.Price);
            Assert.Single(business.GetAllProducts());
        }

        [Fact]
        public void AddProduct_WithNegativePrice_ThrowsArgumentException()
        {
            var repository = new FakeProductRepository();
            var business = new ProductBusiness(repository);

            Assert.Throws<ArgumentException>(() => business.AddProduct("Mouse", -10));
        }

        [Fact]
        public void AddProduct_WithEmptyName_ThrowsArgumentException()
        {
            var repository = new FakeProductRepository();
            var business = new ProductBusiness(repository);

            Assert.Throws<ArgumentException>(() => business.AddProduct("   ", 100));
        }

        [Fact]
        public void GetProductById_WhenNotFound_ReturnsNull()
        {
            var repository = new FakeProductRepository();
            var business = new ProductBusiness(repository);

            var result = business.GetProductById(999);

            Assert.Null(result);
        }
    }
}

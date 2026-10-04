using LearningApi.Models;
using LearningApi.Repositories;

namespace LearningApi.Business
{
    // ---------- BUSINESS LAYER (implementation) ----------
    // Contains RULES/LOGIC. Does NOT know about HTTP or the database details.
    // It only talks to the repository (data layer).
    public class ProductBusiness : IProductBusiness
    {
        private readonly IProductRepository _repository;

        // Repository is "injected" rather than created here.
        public ProductBusiness(IProductRepository repository)
        {
            _repository = repository;
        }

        public List<Product> GetAllProducts() => _repository.GetAll();

        public Product? GetProductById(int id) => _repository.GetById(id);

        public Product AddProduct(string name, decimal price)
        {
            // Business rule example: price cannot be negative.
            if (price < 0)
                throw new ArgumentException("Price cannot be negative.");

            // Business rule example: name is required.
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.");

            var product = new Product { Name = name, Price = price };
            _repository.Add(product);
            return product;
        }
    }
}

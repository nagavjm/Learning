using LearningApi.Data;
using LearningApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningApi.Repositories
{
    // ---------- DATA LAYER (implementation) ----------
    // Talks to SQL Server via EF Core's AppDbContext.
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAll() => _context.Products.ToList();

        public Product? GetById(int id) =>
            _context.Products.FirstOrDefault(p => p.Id == id);

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
    }
}

using LearningApi.Models;

namespace LearningApi.Repositories
{
    // ---------- DATA LAYER (contract) ----------
    // Defines WHAT data operations are available (not how).
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product? GetById(int id);
        void Add(Product product);
    }
}

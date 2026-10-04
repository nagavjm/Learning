using LearningApi.Models;

namespace LearningApi.Business
{
    // ---------- BUSINESS LAYER (contract) ----------
    public interface IProductBusiness
    {
        List<Product> GetAllProducts();
        Product? GetProductById(int id);
        Product AddProduct(string name, decimal price);
    }
}

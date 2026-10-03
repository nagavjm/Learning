using LearningApi.Business;
using Microsoft.AspNetCore.Mvc;

namespace LearningApi.Controllers
{
    // ---------- API LAYER: Product endpoints (Controller style) ----------
    // Controller is thin: it just calls the business layer
    // and returns results. No business logic lives here.
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductBusiness _business;

        public ProductsController(IProductBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(_business.GetAllProducts());
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _business.GetProductById(id);

            if (product is null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct(ProductRequest request)
        {
            try
            {
                var product = _business.AddProduct(request.Name, request.Price);
                return Created($"/products/{product.Id}", product);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    // Simple request shape used by the POST /products endpoint.
    public record ProductRequest(string Name, decimal Price);
}

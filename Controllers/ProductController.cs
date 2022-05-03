using Microsoft.AspNetCore.Mvc;
using Session12.ProductManager.Model;

namespace Session12.ProductManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [Route("Products")]
        public IEnumerable<Product> GetProduct()
        {
            var ret= new[]{
                    new Product(1, "Phone", 100),
                    new Product(2, "Tablet", 200),
                    new Product(3, "Laptop", 300),
                };

            return ret;
        }
    }
}
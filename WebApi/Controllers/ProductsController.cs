using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapitaskup.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class ProductsController : ControllerBase
    {
        public ProductsController()
        {

        }
        // In-memory list of products to simulate a database
        private static List<Product> products = new List<Product>
        {
            new Product { ProductId = 1, ProductName = "Product 1", ProductCat = "Category 1" },
            new Product { ProductId = 2, ProductName = "Product 2", ProductCat = "Category 2" },
            new Product { ProductId = 3, ProductName = "Product 3", ProductCat = "Category 3" }
        };

        // Method to get a product by its ID
        [HttpGet("GetProductsById/{id}")]
        public IActionResult GetProductsById(int id)
        {
            // Find the product by ID
            var product = products.FirstOrDefault(p => p.ProductId == id);

            // If product is not found, return 404 Not Found
            if (product == null)
            {
                return NotFound(new { Message = "Product not found" });
            }

            // If product is found, return 200 OK with the product details
            return Ok(product);
        }
        // Method to get a product by its ID
        [HttpGet("GetProducts")]
        public IActionResult GetProducts()
        {
            // Find the product by ID
            var product = products.ToList();

            // If product is not found, return 404 Not Found
            if (product == null)
            {
                return NotFound(new { Message = "Product not found" });
            }

            // If product is found, return 200 OK with the product details
            return Ok(product);
        }
    }
}
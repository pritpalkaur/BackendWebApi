using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using WebApi.Models;
using WebApi.Business;
using WebApi.Business.Interface;
using WebApi.Exceptions.Service;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductBusiness _IProductBusiness;
        private readonly ILoggingService _ILoggingService;
        public ProductsController(IProductBusiness IProductBusiness, ILoggingService ILoggingService)
        {
            _IProductBusiness = IProductBusiness;
            _ILoggingService = ILoggingService; 
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
        public async Task<IActionResult> GetProducts()
        {
             int denominator = 0;
            try
            {
                if (denominator == 0)
                {

                    throw new DivideByZeroException("Denominator cannot be zero.");
                }
            }
            catch (Exception ex)
            {
                _ILoggingService.LogInformation(ex);
                 _ILoggingService.LogExceptionAsync(ex);
                //throw;
            }

            var products = await _IProductBusiness.GetProductsAsync();

            // If product is found, return 200 OK with the product details
            return Ok(products);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace GetProductDetails.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private static readonly Product[] Products =
        [
            new Product
            {
                Id = 1,
                Name = "Product 1",
                Price = 100
            },
            new Product
            {
                Id = 2,
                Name = "Product 2",
                Price = 200
            },
            new Product
            {
                Id = 3,
                Name = "Product 3",
                Price = 300
            }
        ];

        [HttpGet(Name = "GetProductById")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }

    internal class Product
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required int Price { get; set; }
    }
}

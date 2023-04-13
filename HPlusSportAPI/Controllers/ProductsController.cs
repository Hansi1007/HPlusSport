using HPlusSportAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//Asynchrone APIs

namespace HPlusSportAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly ILogger<ProductsController> _logger;
        private readonly ShopContext _shopContext;


        public ProductsController(ILogger<ProductsController> logger, ShopContext shopContext)
        {
            _logger = logger;
            _logger.LogInformation("Ctor: ProductsController");

            _shopContext = shopContext;
            _shopContext.Database.EnsureCreated();

        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _shopContext.Products.ToListAsync();
        }

        [HttpGet("{Id}")]             
        public async Task<ActionResult<Product>> GetProductById(int Id)
        {
            var product = await _shopContext.Products.FindAsync(Id);
            if(product == null)
            {
                return NotFound();  
            }
            return Ok(product);
        }


    }
}
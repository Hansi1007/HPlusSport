using HPlusSportAPI.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<Product> GetAllProducts()
        {
            return _shopContext.Products.ToList();
        }

        /*
        [HttpGet("{id}")]
        public Product GetProductById(int id)
        {
            Product product = _shopContext.Products.Find(id);
            if (product == null)
            {
                return new Product();
            }
            else
                return product;

        }
        */

        [HttpGet("{Id}")]             
        public ActionResult<Product> GetProductById(int Id)
        {
            var result = _shopContext.Products.Find(Id);
            if(result == null)
            {
                return NotFound();  
            }
            return result;
        }


    }
}
using Microsoft.AspNetCore.Mvc;

namespace HPlusSportAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
            _logger.LogInformation("Ctor: ProductsController");

        }
                
        [HttpGet]
        public string GetProdut()
        {
            return "OK.";
        }


   
    }
}
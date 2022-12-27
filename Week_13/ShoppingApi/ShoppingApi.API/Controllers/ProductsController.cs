using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingApi.Business.Abstract;

namespace ShoppingApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        //Projenizde Swagger var ise tüm action metotlarnızın Http Request türü yazılmalıdır. HttpGet , HttpPost vs.

        [HttpGet]
        public async  Task<IActionResult> GetProducts() 
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);    
        }
    }
}

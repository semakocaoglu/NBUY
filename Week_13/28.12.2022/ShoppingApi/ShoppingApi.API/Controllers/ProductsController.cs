using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingApi.API.Model;
using ShoppingApi.Business.Abstract;
using ShoppingApi.Core;
using ShoppingApi.Entity.Concrete;

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
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAllAsync();
            List<ProductDto> productDtos = new List<ProductDto>();
            foreach (var product in products)
            {
                productDtos.Add(new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    Url = product.Url
                });
            }
            return Ok(productDtos);
        }

        [HttpGet("{id}")]   
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if(product == null) { return NotFound(); }
            ProductDto productDto = new ProductDto
            {

                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Url = product.Url

            };
            return Ok(productDto);
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct (ProductDto productDto)
        {
            if(productDto == null) { return NotFound(); }
            Product product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                ImageUrl = productDto.ImageUrl,
                Url = Jobs.InitUrl(productDto.Name),
               
            };
            int[] categories = int[] {};
            await _productService.CreateAsync(product , productDto.Categories);
            //return Ok(product); //ilk başta böle yapmıştk
            productDto.Id = product.Id;
            productDto.Url = product
                .Url;
            return CreatedAtAction("GetProduct", new { id = product.Id }, productDto);
        }
    }
}

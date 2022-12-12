using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Business.Abstract;
using ShoppingApp.Core;
using ShoppingApp.Entity.Concrete;
using ShoppingApp.Web.Areas.Admin.Models.Dtos;
using System;
using System.Diagnostics.Eventing.Reader;

namespace ShoppingApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProductsWithCategories();
            var productListDto = products
                .Select(p => new ProductListDto
                {
                    Product = p
                }).ToList();
     
            return View(productListDto);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllAsync();
            var productAddDto = new ProductAddDto
            {
                Categories = categories
            };
            return View(productAddDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductAddDto productAddDto)
        {
            if(ModelState.IsValid)
            {
                var url = Jobs.InitUrl(productAddDto.Name);
                var product = new Product
                {
                    Name = productAddDto.Name,
                    Price= productAddDto.Price,
                    Description = productAddDto.Description,
                    Url = url,
                    IsApproved = productAddDto.IsApproved,
                    IsHome = productAddDto.IsHome,
                    ImageUrl = Jobs.UploadImage(productAddDto.ImageFile)//Burdan önce, Jobs'ta image upload etmek için kod yazıldı.

                };
                await _productService.CreateProductAsync(product, productAddDto.SelectedCategoryIds);
                return RedirectToAction("Index");
            }
            var categories = await _categoryService.GetAllAsync();
            productAddDto.Categories = categories;
            return View(productAddDto);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            var productWithProductCategories = await _productService.GetProductWithCategories(id);
            if (product == null)
            {
                return NotFound();
            }


            var productUpdateDto = new ProductUpdateDto
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                IsApproved = product.IsApproved,
                IsHome = product.IsHome,
                Categories =product.
               
                
               
            };

            productUpdateDto.Categories = categories;
            return View(productUpdateDto);
        }



        [HttpPost]
        public async Task<IActionResult> Edit(ProductUpdateDto productUpdateDto, int[] selectedCategoryIds)
        {
            if (ModelState.IsValid)
            {
                var product = await _productService.GetByIdAsync(productUpdateDto.Id);
                if (product == null)
                {
                    return NotFound();
                }
                product.Url = Jobs.InitUrl(productUpdateDto.Name);
                product.Name = productUpdateDto.Name;
                product.Description = productUpdateDto.Description;
                product.Price = productUpdateDto.Price;
                product.IsApproved = productUpdateDto.IsApproved;
                product.IsHome = productUpdateDto.IsHome;
                product.ImageUrl = Jobs.UploadImage(productUpdateDto.ImageFile);
                product.Url = url;

                await _productService.Update

                _productService.Update(product);
                return RedirectToAction("Index");

            }
            return View(productUpdateDto);
        }
    }
}

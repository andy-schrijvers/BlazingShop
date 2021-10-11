using BlazingShop.Server.Services;
using BlazingShop.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return Ok(await _productService.GetAllProductsAsync());
        }

        [HttpGet("category/{categoryUrl}")]
        public async Task<ActionResult<List<Product>>> GetProducts([FromRoute] string categoryUrl)
        {
            return Ok(await _productService.GetProductsByCategoryUrlAsync(categoryUrl));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Product>>> GetProducts([FromRoute] int id)
        {
            return Ok(await _productService.GetProductAsync(id));
        }

    }
}

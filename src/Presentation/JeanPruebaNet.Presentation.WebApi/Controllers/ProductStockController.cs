using JeanPruebaNet.Application.DataTransferObjects.ProductStock;
using JeanPruebaNet.Application.Services.ProductStockService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace JeanPruebaNet.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductStockController : ControllerBase
    {
        private readonly IProductStockService productStockService;
        public ProductStockController(IProductStockService productStockService)
        {
            this.productStockService = productStockService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductStockAsync()
        {
            var stocks = await productStockService.GetAllProductsStockWithProductAsync();
            return Ok(new { stocks });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductStockById(int id)
        {
            return Ok(await productStockService.GetProductStockByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductStockAsync([FromBody] ProductStockCreate productStockCreate)
        {
            return Ok(await productStockService.CreateProductStock(productStockCreate));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductStockAsync(int id, [FromBody] ProductStockCreate productStockCreate)
        {
            return Ok(await productStockService.UpdateProductStockAsync(id, productStockCreate));

        }

        [HttpGet("products")]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var products = await productStockService.GetAllProductsAsync();
            return Ok(new { products });
        }
        [HttpGet("products/{id}")]
        public async Task<IActionResult> GetProductByIdAsync(string id)
        {
            return Ok(await productStockService.GetProductByIdAsync(id));
        }
        [HttpPost("products")]
        public async Task<IActionResult> CreateProductAsync([FromBody] ProductCreate productCreate)
        {
            return Ok(await productStockService.CreateProductAsync(productCreate));
        }
        [HttpPut("products/{id}")]
        public async Task<IActionResult> UpdateProductAsync(string id, [FromBody] ProductCreate request)
        {
            return Ok(await productStockService.UpdateProductAsync(id, request));

        }
        [HttpGet("categories")]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var categories = await productStockService.GetSummaryByCategoryAsync();
            return Ok(new { categories });
        }
    }
}

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
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await productStockService.GetAllProductsStockAsync());
        }
        [HttpGet("productStockId")]
        public async Task<IActionResult> GetProductById(int productStockId)
        {
            return Ok(await productStockService.GetProductStockByIdAsync(productStockId));
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ProductStockCreate productStockCreate)
        {
            return Ok(await productStockService.CreateProductStock(productStockCreate));
        }

    }
}

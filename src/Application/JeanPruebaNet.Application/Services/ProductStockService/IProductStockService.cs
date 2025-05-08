

using JeanPruebaNet.Application.DataTransferObjects.ProductStock;

namespace JeanPruebaNet.Application.Services.ProductStockService
{
    public interface IProductStockService
    {
        Task<IEnumerable<ProductStockResponse>> GetAllProductsStockAsync();
        Task<ProductStockResponse> GetProductStockByIdAsync(int id);
        Task<ProductStockResponse> CreateProductStock(ProductStockCreate request);
        Task<ProductStockResponse> UpdateProductStockAsync(int id, ProductStockCreate request);
    }
}

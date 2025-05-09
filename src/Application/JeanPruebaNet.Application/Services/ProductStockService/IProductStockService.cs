

using JeanPruebaNet.Application.DataTransferObjects.ProductStock;

namespace JeanPruebaNet.Application.Services.ProductStockService
{
    public interface IProductStockService
    {
        Task<IEnumerable<ProductStockResponse>> GetAllProductsStockAsync();
        Task<IEnumerable<ProductStockResponse>> GetAllProductsStockWithProductAsync();
        Task<ProductStockResponse> GetProductStockByIdAsync(int id);
        Task<ProductStockResponse> CreateProductStock(ProductStockCreate request);
        Task<ProductStockResponse> UpdateProductStockAsync(int id, ProductStockCreate request);
        Task<IEnumerable<ProductResponse>> GetAllProductsAsync();
        Task<ProductResponse> GetProductByIdAsync(string id);
        Task<ProductResponse> CreateProductAsync(ProductCreate request);
        Task<ProductResponse> UpdateProductAsync(string id, ProductCreate request);
        Task<List<CategoryResponse>> GetSummaryByCategoryAsync();
    }
}

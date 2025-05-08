using JeanPruebaNet.Domain.Entities;


namespace JeanPruebaNet.Application.Common.Abstractions
{
    public interface IProductStockRepository
    {
        Task<ProductStock> GetByIdAsync(int id);
        Task<IEnumerable<ProductStock>> GetAllAsync();
        Task UpdateAsync(ProductStock product);
        Task CreateStock(ProductStock product);
    }
}

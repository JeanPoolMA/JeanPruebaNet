
using JeanPruebaNet.Application.Common.Abstractions;
using JeanPruebaNet.Domain.Entities;
using JeanPruebaNet.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace JeanPruebaNet.Infrastructure.Repositories
{
    public class ProductStockRepository : IProductStockRepository
    {
        private readonly WarehouseDbContext context;

        public ProductStockRepository(WarehouseDbContext context)
        {
            this.context = context;
        }

        public async Task<ProductStock> GetByIdAsync(int id)
        {
            return await context.ProductStocks
                .FirstAsync(ps => ps.Id == id);
        }

        public async Task<IEnumerable<ProductStock>> GetAllAsync()
        {
            return await context.ProductStocks
                .ToListAsync();
        }

        public async Task UpdateAsync(ProductStock productStock)
        {
            context.ProductStocks.Update(productStock);
            await context.SaveChangesAsync();
        }

        public async Task CreateStock(ProductStock productStock)
        {
            await context.ProductStocks.AddAsync(productStock);
            await context.SaveChangesAsync();
        }
    }
}

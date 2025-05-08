using Microsoft.EntityFrameworkCore;
using JeanPruebaNet.Domain.Entities;

namespace JeanPruebaNet.Infrastructure.Context
{
    public class WarehouseDbContext : DbContext
    {
        public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProductStock> ProductStocks { get; set; }
    
    }
}

using JeanPruebaNet.Application.Common.Abstractions;
using JeanPruebaNet.Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using JeanPruebaNet.Infrastructure.Repositories;

namespace JeanPruebaNet.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            WebApplicationBuilder builder
        )
        {
            services.AddScoped<IProductStockRepository, ProductStockRepository>();
            services.AddHttpClient();
            services.AddControllers();
            services.AddDbContext<WarehouseDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("WarehouseDbContext")));

            return services;
        }
    }
}

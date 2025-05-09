
using JeanPruebaNet.Application.Common.Profiles;
using JeanPruebaNet.Application.Services.ProductStockService;
using Microsoft.Extensions.DependencyInjection;

namespace JeanPruebaNet.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddScoped<IProductStockService, ProductStockService>();

         
            services.AddAutoMapper(typeof(ProductStockProfile));

            return services;
        }
    }
}

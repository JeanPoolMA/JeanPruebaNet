

using AutoMapper;
using JeanPruebaNet.Application.Common.Abstractions;
using JeanPruebaNet.Application.DataTransferObjects.ProductStock;
using JeanPruebaNet.Domain.Entities;

namespace JeanPruebaNet.Application.Services.ProductStockService
{
    public class ProductStockService : IProductStockService
    {
        private readonly IProductStockRepository productStockRepository;
        private readonly IMapper mapper;

        public ProductStockService(IProductStockRepository productStockRepository, IMapper mapper)
        {
            this.productStockRepository = productStockRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProductStockResponse>> GetAllProductsStockAsync()
        {
            IEnumerable<ProductStock> products = await productStockRepository.GetAllAsync();

            return mapper.Map<IEnumerable<ProductStockResponse>>(products);
        }

        public async Task<ProductStockResponse> GetProductStockByIdAsync(int id)
        {
            ProductStock productStock = await productStockRepository.GetByIdAsync(id);

            return mapper.Map<ProductStockResponse>(productStock);
        }
        public async Task<ProductStockResponse> CreateProductStock(ProductStockCreate request)
        {
            ProductStock productStock = mapper.Map<ProductStock>(request);

            await productStockRepository.CreateStock(productStock);

            return await GetProductStockByIdAsync(productStock.Id);
        }
        public async Task<ProductStockResponse> UpdateProductStockAsync(int id, ProductStockCreate request)
        {
            ProductStock existingStock = await productStockRepository.GetByIdAsync(id);

            if (existingStock == null)
                throw new KeyNotFoundException("Stock not found");

            mapper.Map(request, existingStock);
            await productStockRepository.UpdateAsync(existingStock);
            return await GetProductStockByIdAsync(existingStock.Id);

        }
    }
}

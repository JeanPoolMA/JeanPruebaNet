

using System.Net.Http;
using System.Net.Http.Json;
using AutoMapper;
using JeanPruebaNet.Application.Common.Abstractions;
using JeanPruebaNet.Application.Common.Utils;
using JeanPruebaNet.Application.DataTransferObjects.ProductStock;
using JeanPruebaNet.Domain.Entities;

namespace JeanPruebaNet.Application.Services.ProductStockService
{
    public class ProductStockService : IProductStockService
    {
        private readonly IProductStockRepository productStockRepository;
        private readonly IMapper mapper;
        private readonly HttpClient httpClient;


        public ProductStockService(IProductStockRepository productStockRepository, IMapper mapper, HttpClient httpClient)
        {
            this.productStockRepository = productStockRepository;
            this.mapper = mapper;
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductStockResponse>> GetAllProductsStockAsync()
        {
            IEnumerable<ProductStock> products = await productStockRepository.GetAllAsync();

            return mapper.Map<IEnumerable<ProductStockResponse>>(products);
        }

        public async Task<IEnumerable<ProductStockResponse>> GetAllProductsStockWithProductAsync()
        {
            var productStocks = await productStockRepository.GetAllAsync();
            var products = await GetAllProductsAsync();

            return ProductUtils.JoinWithProducts(productStocks, products);
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

        public async Task<IEnumerable<ProductResponse>> GetAllProductsAsync()
        {
            var productResponse = await httpClient.GetAsync("product");
            var products = await productResponse.Content.ReadFromJsonAsync<List<ProductResponse>>()
                            ?? new List<ProductResponse>();

            var quantityTuples = await productStockRepository.GetProductWithQuantityAsync();

            var combinedProducts = ProductUtils.MapQuantitiesToProducts(products, quantityTuples);

            return combinedProducts;
        }


        public async Task<ProductResponse> GetProductByIdAsync(string id)
        {
            var response = await httpClient.GetAsync($"product/{id}");

            if (!response.IsSuccessStatusCode)
                throw new Exception($"No se pudo obtener el producto con ID {id}");

            return await response.Content.ReadFromJsonAsync<ProductResponse>()
                   ?? throw new Exception("No existe el producto");
        }

 

        public async Task<ProductResponse> CreateProductAsync(ProductCreate request)
        {
            var httpResponse = await httpClient.PostAsJsonAsync("product", request);

            var productResponse = await httpResponse.Content.ReadFromJsonAsync<ProductResponse>()
                                 ?? throw new Exception("Error");

            if(request.Quantity.HasValue && request.Quantity != 0)
            {
                var productStock = new ProductStockCreate
                {
                    ProductId = productResponse.Id,
                    Quantity = request.Quantity ?? 0
                };

                var productStockEntity = mapper.Map<ProductStock>(productStock);
                await productStockRepository.CreateStock(productStockEntity);

            }

            return await GetProductByIdAsync(productResponse.Id);

        }

        public async Task<ProductResponse> UpdateProductAsync(string id, ProductCreate request)
        {
            var response = await httpClient.PutAsJsonAsync($"product/{id}", request);

            return await response.Content.ReadFromJsonAsync<ProductResponse>()
                   ?? throw new Exception("No existe el producto");
        }

        public async Task<List<CategoryResponse>> GetSummaryByCategoryAsync()
        {
            var productStocks = await productStockRepository.GetAllAsync();
            var products = await httpClient.GetFromJsonAsync<List<ProductResponse>>("product");

            return ProductUtils.GroupByCategory(productStocks, products);
        }

    }
}

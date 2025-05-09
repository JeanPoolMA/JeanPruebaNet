using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JeanPruebaNet.Application.DataTransferObjects.ProductStock;
using JeanPruebaNet.Domain.Entities;

namespace JeanPruebaNet.Application.Common.Utils
{
    public class ProductUtils
    {
        public static List<CategoryResponse> GroupByCategory(
            IEnumerable<ProductStock> productStocks,
            IEnumerable<ProductResponse> products)
        {
            return products
               .GroupJoin(
                   productStocks,
                   product => product.Id.ToString(),  
                   stock => stock.ProductId,
                   (product, stocks) => new { product.CategoryName, Stocks = stocks }
               )
               .GroupBy(group => group.CategoryName)  
               .Select(group => new CategoryResponse
               {
                   CategoryName = group.Key,  
                   TotalQuantity = group
                       .SelectMany(g => g.Stocks)  
                       .Sum(stock => stock.Quantity)  
               })
               .OrderBy(x => x.CategoryName) 
               .ToList();
        }
        public static List<ProductStockResponse> JoinWithProducts(
            IEnumerable<ProductStock> productStocks,
            IEnumerable<ProductResponse> products)
        {
            return productStocks
                .Join(
                    products,
                    stock => stock.ProductId,
                    product => product.Id,
                    (stock, product) => new ProductStockResponse
                    {
                        Id = stock.Id,
                        ProductId = stock.ProductId,
                        Quantity = stock.Quantity,
                        Name = product.Name
                    }
                )
                .OrderBy(x => x.Name)
                .ToList();
        }

        public static IEnumerable<ProductResponse> MapQuantitiesToProducts(
            IEnumerable<ProductResponse> products,
            IEnumerable<(string ProductId, int Quantity)> quantities)
        {
            var quantityMap = quantities.ToDictionary(t => t.ProductId, t => t.Quantity);

            foreach (var product in products)
            {
                product.Quantity = quantityMap.TryGetValue(product.Id, out int qty) ? qty : 0;
            }

            return products.OrderBy(product => product.Name);
        }
    }
}

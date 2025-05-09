using AutoMapper;
using JeanPruebaNet.Application.DataTransferObjects.ProductStock;
using JeanPruebaNet.Domain.Entities;
using Microsoft.Win32;


namespace JeanPruebaNet.Application.Common.Profiles
{
    public class ProductStockProfile : Profile
    {
        public ProductStockProfile()
        {
            CreateMap<ProductStock, ProductStockResponse>();
            CreateMap<ProductStockCreate, ProductStock>();
        }
          
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeanPruebaNet.Application.DataTransferObjects.ProductStock
{
    public class ProductStockResponse
    {
        public string ProductId { get; set; } = string.Empty;
        public int quantity { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeanPruebaNet.Application.DataTransferObjects.ProductStock
{
    public class ProductStockCreate
    {
        public string ProductId { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}

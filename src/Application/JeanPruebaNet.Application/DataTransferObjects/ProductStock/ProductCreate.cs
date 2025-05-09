using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeanPruebaNet.Application.DataTransferObjects.ProductStock
{
    public class ProductCreate
    {
        public string Name { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public int? Quantity { get; set; }
    }
}

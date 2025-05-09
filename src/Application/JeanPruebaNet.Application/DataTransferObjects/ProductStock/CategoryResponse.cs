using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeanPruebaNet.Application.DataTransferObjects.ProductStock
{
    public class CategoryResponse
    {
        public string CategoryName { get; set; } = string.Empty;
        public int TotalQuantity { get; set; }
    }
}

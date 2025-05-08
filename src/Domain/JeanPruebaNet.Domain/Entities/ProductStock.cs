using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeanPruebaNet.Domain.Entities
{
    public class ProductStock
    {
        public int Id { get; set; }
        public string ProductId { get; set; } = string.Empty;
        public int quantity { get; set; }
    }
}

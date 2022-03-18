using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Purchase.System.DTO
{
    public class ProductListDTO
    {
        public int pk_ProductId { get; set; }
        public string ProductType { get; set; }
        public string ProductName { get; set; }
        public double OriginalPrice { get; set; }
        public double SellingUpToPrice { get; set; }
        public double Quantity { get; set; }
    }
}
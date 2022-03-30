using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Purchase.System.Common
{
    public class ProductMst
    {
        [Key]
        public int pk_ProductId { get; set; }
        [Display(Name = "Product Type")]
        public int fk_producttypeid { get; set; }
        public string ProductName { get; set; }
        public double OriginalPrice { get; set; }
        public double SellingUpToPrice { get; set; }
        public double Quantity { get; set; }

        public string UserName { get; set; }
    }
}
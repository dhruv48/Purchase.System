using Purchase.System.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Purchase.System.DTO
{
    public class ProductMasterDTO
    {
        public List<ProductTypeMst> ProductMasList { get; set; }

        public ProductMst ProductMst { get; set; }
    }
}
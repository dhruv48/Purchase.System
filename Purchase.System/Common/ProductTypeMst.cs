using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Purchase.System.Common
{
    public class ProductTypeMst
    {

        [Key]
        public int pk_propertyId { get; set; }
        public string Description { get; set; }
    }
}
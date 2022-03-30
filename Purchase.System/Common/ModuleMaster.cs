using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Purchase.System.Common
{
    public class ModuleMaster
    {
        [Key]
        public int pk_moduleId { get; set; }
        public string ModuleName { get; set; }
        public string ModuleDescription { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string Area { get; set; }
        public string ImgUrl { get; set; }
        public int IsActive { get; set; }
    }
}
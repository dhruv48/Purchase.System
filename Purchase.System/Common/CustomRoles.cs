using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Purchase.System.Common
{
    public static class CustomRoles
    {
        public const string Admin = "Admin";
        public const string Gs = "GeneralStore";
        public const string Cloth = "ClothStore";
        public const string Adm_Gs = Admin + "," + Gs;
        public const string Adm_Cs = Admin + "," + Cloth;

    }
}
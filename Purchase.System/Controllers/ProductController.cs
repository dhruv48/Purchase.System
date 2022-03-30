using Purchase.System.Common;
using Purchase.System.DTO;
using Purchase.System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Purchase.System.Controllers
{
    //[Authorize(Roles = CustomRoles.Admin, CustomRoles.Adm_Cs, CustomRoles.Adm_Gs)]
    public class ProductController : Controller
    {
        ApplicationDbContext applicationDbContext;
        public ProductController()
        {
            applicationDbContext = new ApplicationDbContext();
        }
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddUpdateProduct()
        {

            var productTypeList = new ProductMasterDTO
            {
                ProductMasList = applicationDbContext.ProductTypes.ToList()
            };
            return View(productTypeList);
        }

        [HttpPost]
        public ActionResult AddUpdateProduct(ProductMasterDTO productMasterDTO)
        {
            if (productMasterDTO.ProductMst.pk_ProductId == 0)
            {
                productMasterDTO.ProductMst.UserName = User.Identity.Name;
                applicationDbContext.ProductMainMasters.Add(productMasterDTO.ProductMst);
                applicationDbContext.SaveChanges();

            }
            else
            {

                var dataInDb = applicationDbContext.ProductMainMasters.FirstOrDefault(x => x.pk_ProductId == productMasterDTO.ProductMst.pk_ProductId);

                dataInDb.fk_producttypeid = productMasterDTO.ProductMst.fk_producttypeid;
                dataInDb.ProductName = productMasterDTO.ProductMst.ProductName;
                dataInDb.SellingUpToPrice = productMasterDTO.ProductMst.SellingUpToPrice;
                dataInDb.Quantity = productMasterDTO.ProductMst.Quantity;
                dataInDb.OriginalPrice = productMasterDTO.ProductMst.OriginalPrice;
                applicationDbContext.SaveChanges();

            }

            return RedirectToAction("ProductList");
        }

        public ActionResult ProductList()
        {
            IEnumerable<ProductListDTO> productLists;
            if (User.IsInRole(CustomRoles.Admin))
            {

                productLists = from x in applicationDbContext.ProductMainMasters
                               join y in applicationDbContext.ProductTypes on x.fk_producttypeid equals y.pk_propertyId
                               select new ProductListDTO
                               {
                                   pk_ProductId = x.pk_ProductId,
                                   ProductName = x.ProductName,
                                   SellingUpToPrice = x.SellingUpToPrice,
                                   Quantity = x.Quantity,
                                   OriginalPrice = x.OriginalPrice,
                                   ProductType = y.Description

                               };
            }
            else
            {
                productLists = from x in applicationDbContext.ProductMainMasters
                               join y in applicationDbContext.ProductTypes on x.fk_producttypeid equals y.pk_propertyId
                               where x.UserName == User.Identity.Name
                               select new ProductListDTO
                               {
                                   pk_ProductId = x.pk_ProductId,
                                   ProductName = x.ProductName,
                                   SellingUpToPrice = x.SellingUpToPrice,
                                   Quantity = x.Quantity,
                                   OriginalPrice = x.OriginalPrice,
                                   ProductType = y.Description

                               };

            }

            return View(productLists);
        }

        public ActionResult Edit(int id)
        {

            var EditData = new ProductMasterDTO
            {
                ProductMst = applicationDbContext.ProductMainMasters.FirstOrDefault(x => x.pk_ProductId == id)
            };
            return View("AddUpdateProduct", EditData);
        }

        public ActionResult Delete(int id)
        {
            var data = applicationDbContext.ProductMainMasters.FirstOrDefault(x => x.pk_ProductId == id);
            applicationDbContext.ProductMainMasters.Remove(data);
            applicationDbContext.SaveChanges();
            return RedirectToAction("ProductList");
        }
    }
}
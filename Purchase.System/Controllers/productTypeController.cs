using Purchase.System.Common;
using Purchase.System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Purchase.System.Controllers
{
    public class ProductTypeController : Controller
    {
        ApplicationDbContext _db;
        public ProductTypeController()
        {
            _db = new ApplicationDbContext();
        }
        // GET: ProductType
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }


        [HttpPost]
        public ActionResult Create(ProductTypeMst productTypeMst)
        {

            _db.ProductTypes.Add(productTypeMst);
            _db.SaveChanges();
            return View();
        }

        public ActionResult ProductTypeList()
        {
            var prodList = _db.ProductTypes.ToList();
            return View(prodList);

        }

        public ActionResult Edit(int id)
        {
            var productType = _db.ProductTypes.FirstOrDefault(x => x.pk_propertyId == id);
            return View("Create", productType);
        }
    }
}
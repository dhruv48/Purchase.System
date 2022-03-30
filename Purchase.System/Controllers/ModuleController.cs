using Purchase.System.Common;
using Purchase.System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Purchase.System.Controllers
{
    public class ModuleController : Controller
    {
        ApplicationDbContext _applicationDbContext;
        public ModuleController()
        {
            _applicationDbContext = new ApplicationDbContext();
        }
        // GET: Module
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateModule()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateModule(ModuleMaster moduleMaster )
        {
            _applicationDbContext.ModuleMaster.Add(moduleMaster);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("ModuleList");
        }


        public ActionResult ModuleList()
        {
           
            return View(_applicationDbContext.ModuleMaster.ToList());
        }
    }

}
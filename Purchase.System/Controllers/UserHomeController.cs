using Purchase.System.Common;
using Purchase.System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Purchase.System.Controllers
{
    public class UserHomeController : Controller
    {
        ApplicationDbContext _applicationDbContext;
        public UserHomeController()
        {
            _applicationDbContext = new ApplicationDbContext();
        }
        // GET: UserHome
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DisplayModule ()
        {
            List<ModuleMaster> ModuleList;
            if(User.IsInRole(CustomRoles.Admin))
            {
                ModuleList = _applicationDbContext.ModuleMaster.Where(x => x.IsActive == 1).ToList();
            }
            else if (User.IsInRole(CustomRoles.Cloth))
            {
                ModuleList = _applicationDbContext.ModuleMaster.Where(x => x.IsActive == 1 && x.pk_moduleId == 1).ToList();
            }
            else
            {
                ModuleList = _applicationDbContext.ModuleMaster.Where(x => x.IsActive == 1 && x.pk_moduleId == 3).ToList();
            }
            return View(ModuleList);
        }
    }
}
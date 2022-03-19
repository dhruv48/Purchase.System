using Purchase.System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Purchase.System.Controllers
{
    public class RoleController : Controller
    {

        ApplicationDbContext applicationDbContext = new ApplicationDbContext();
        public RoleController()
        {
                
        }
        // GET: Role
        public ActionResult RoleList()
        {
            var roleList = applicationDbContext.Roles.ToList();
            return View(roleList);
        }

        
        [HttpGet]
        public ActionResult CreateRole()
        {
            var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            return View(role);
        }

        //Create Role
        [HttpPost]
        public ActionResult CreateRole(Microsoft.AspNet.Identity.EntityFramework.IdentityRole identityRole)
        {
            applicationDbContext.Roles.Add(identityRole);
            applicationDbContext.SaveChanges();
            return RedirectToAction("RoleList");
        }
    }
}
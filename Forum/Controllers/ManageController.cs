using Forum.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    public class ManageController : Controller
    {
        private Entities db = new Entities();
        // GET: Manage
        public ActionResult Index()
        {
            dynamic myModel = new ExpandoObject();
            myModel.RoleList = (from u in db.Roles
                             join f in db.UserRoles
                             on u.roleId equals f.roleid
                             join c in db.UserRegistrations
                             on f.userid equals c.userId
                             where u.roleName.ToString().Contains("Site_")
                             select new {
                                        UserId = c.userId,
                                        RoleName = u.roleName,
                                        UserName = c.userName
                             }).ToList();
            return View(myModel);
        }
    }
}
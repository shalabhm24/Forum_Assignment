using Forum.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        // GET: UserRegistrations/Create
        public ActionResult Edit(int?id)
        {
            ViewBag.roleID = new SelectList(db.Roles, "roleId", "roleName");
            return View();
        }

        // POST: UserRegistrations/Edit
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userId,roleId,logId")] UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.statusId = new SelectList(db.Roles, "roleId", "roleName", userRole.userid);
            return View(userRole);
        }
    }
}
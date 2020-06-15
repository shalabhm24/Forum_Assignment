using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Forum.Models;

namespace Forum.Controllers
{
    public class UserRegistrationsController : Controller
    {
        private Entities db = new Entities();

        // GET: UserRegistrations
        public ActionResult Index()
        {
            var userRegistrations = db.UserRegistrations.Include(u => u.UserStatu);
            return View(userRegistrations.ToList());
        }

        // GET: UserRegistrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRegistration userRegistration = db.UserRegistrations.Find(id);
            if (userRegistration == null)
            {
                return HttpNotFound();
            }
            return View(userRegistration);
        }

        // GET: UserRegistrations/Create
        public ActionResult Create()
        {
            ViewBag.statusId = new SelectList(db.UserStatus, "statusId", "statusName");
            return View();
        }

        // POST: UserRegistrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userId,Name,contactNo,emailId,statusId,userName,password")] UserRegistration userRegistration)
        {
            if (ModelState.IsValid)
            {
                db.UserRegistrations.Add(userRegistration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.statusId = new SelectList(db.UserStatus, "statusId", "statusName", userRegistration.statusId);
            return View(userRegistration);
        }

        // GET: UserRegistrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRegistration userRegistration = db.UserRegistrations.Find(id);
            if (userRegistration == null)
            {
                return HttpNotFound();
            }
            ViewBag.statusId = new SelectList(db.UserStatus, "statusId", "statusName", userRegistration.statusId);
            return View(userRegistration);
        }

        // POST: UserRegistrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userId,Name,contactNo,emailId,statusId,userName,password")] UserRegistration userRegistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userRegistration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.statusId = new SelectList(db.UserStatus, "statusId", "statusName", userRegistration.statusId);
            return View(userRegistration);
        }

        //// GET: UserRegistrations/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    UserRegistration userRegistration = db.UserRegistrations.Find(id);
        //    if (userRegistration == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(userRegistration);
        //}

        //// POST: UserRegistrations/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    UserRegistration userRegistration = db.UserRegistrations.Find(id);
        //    db.UserRegistrations.Remove(userRegistration);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BucketList.Models;

namespace BucketList.Controllers
{
    public class ShoppingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Shoppings
        public ActionResult Index()
        {
            var shoppings = db.Shoppings.Include(s => s.ShoppingsType);
            return View(shoppings.ToList());
        }

        // GET: Shoppings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shopping shopping = db.Shoppings.Find(id);
            if (shopping == null)
            {
                return HttpNotFound();
            }
            return View(shopping);
        }

        // GET: Shoppings/Create
        public ActionResult Create()
        {
            ViewBag.ShoppingTypeID = new SelectList(db.ShoppingTypes, "ShoppingTypeId", "ShoppingsType");
            return View();
        }

        // POST: Shoppings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShoppingId,Title,Description,Location,Link,ShoppingTypeID")] Shopping shopping)
        {
            if (ModelState.IsValid)
            {
                db.Shoppings.Add(shopping);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ShoppingTypeID = new SelectList(db.ShoppingTypes, "ShoppingTypeId", "ShoppingsType", shopping.ShoppingTypeID);
            return View(shopping);
        }

        // GET: Shoppings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shopping shopping = db.Shoppings.Find(id);
            if (shopping == null)
            {
                return HttpNotFound();
            }
            ViewBag.ShoppingTypeID = new SelectList(db.ShoppingTypes, "ShoppingTypeId", "ShoppingsType", shopping.ShoppingTypeID);
            return View(shopping);
        }

        // POST: Shoppings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShoppingId,Title,Description,Location,Link,ShoppingTypeID")] Shopping shopping)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shopping).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ShoppingTypeID = new SelectList(db.ShoppingTypes, "ShoppingTypeId", "ShoppingsType", shopping.ShoppingTypeID);
            return View(shopping);
        }

        // GET: Shoppings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shopping shopping = db.Shoppings.Find(id);
            if (shopping == null)
            {
                return HttpNotFound();
            }
            return View(shopping);
        }

        // POST: Shoppings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shopping shopping = db.Shoppings.Find(id);
            db.Shoppings.Remove(shopping);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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

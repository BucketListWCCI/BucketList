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
    public class museumsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: museums
        public ActionResult Index()
        {
            return View(db.museums.ToList());
        }

        // GET: museums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            museum museum = db.museums.Find(id);
            if (museum == null)
            {
                return HttpNotFound();
            }
            return View(museum);
        }

        // GET: museums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: museums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MuseumId,Title,Description,MuseumType,Link,Location,MuseumIsComplete")] museum museum)
        {
            if (ModelState.IsValid)
            {
                db.museums.Add(museum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(museum);
        }

        // GET: museums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            museum museum = db.museums.Find(id);
            if (museum == null)
            {
                return HttpNotFound();
            }
            return View(museum);
        }

        // POST: museums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MuseumId,Title,Description,MuseumType,Link,Location,MuseumIsComplete")] museum museum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(museum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(museum);
        }

        // GET: museums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            museum museum = db.museums.Find(id);
            if (museum == null)
            {
                return HttpNotFound();
            }
            return View(museum);
        }

        // POST: museums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            museum museum = db.museums.Find(id);
            db.museums.Remove(museum);
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

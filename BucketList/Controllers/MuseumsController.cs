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
    public class MuseumsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Museums
        public ActionResult Index()
        {
            var museums = db.museums.Include(m => m.MuseumsType);
            return View(museums.ToList());
        }

        // GET: Museums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Museum museum = db.museums.Find(id);
            if (museum == null)
            {
                return HttpNotFound();
            }
            return View(museum);

          //  public saveToList()
             {

             }


        }



        // GET: Museums/Create
        public ActionResult Create()
        {
            ViewBag.MuseumTypeId = new SelectList(db.MuseumTypes, "MuseumTypeId", "MuseumsType");
            return View();
        }

        // POST: Museums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MuseumId,Title,Description,Link,Location,MuseumTypeId")] Museum museum)
        {
            if (ModelState.IsValid)
            {
                db.museums.Add(museum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MuseumTypeId = new SelectList(db.MuseumTypes, "MuseumTypeId", "MuseumsType", museum.MuseumTypeId);
            return View(museum);
        }

        // GET: Museums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Museum museum = db.museums.Find(id);
            if (museum == null)
            {
                return HttpNotFound();
            }
            ViewBag.MuseumTypeId = new SelectList(db.MuseumTypes, "MuseumTypeId", "MuseumsType", museum.MuseumTypeId);
            return View(museum);
        }

        // POST: Museums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MuseumId,Title,Description,Link,Location,MuseumTypeId")] Museum museum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(museum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MuseumTypeId = new SelectList(db.MuseumTypes, "MuseumTypeId", "MuseumsType", museum.MuseumTypeId);
            return View(museum);
        }

        // GET: Museums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Museum museum = db.museums.Find(id);
            if (museum == null)
            {
                return HttpNotFound();
            }
            return View(museum);
        }

        // POST: Museums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Museum museum = db.museums.Find(id);
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

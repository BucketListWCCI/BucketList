using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BucketList.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BucketList.Controllers
{
    public class UserListsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Follow(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (Request.IsAuthenticated)
            {

                UserList userList = db.UserLists.Find(id);
                if (userList == null)
                {
                    return HttpNotFound();
                }
                UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                ApplicationUser currentUser = UserManager.FindById(User.Identity.GetUserId());
                ApplicationUser authorUser = userList.UserName;
                if (currentUser.Following.Contains(authorUser))
                {
                    ViewBag.content = "You are already following this user";
                }
                else
                {
                    currentUser.Following.Add(authorUser);
                    ViewBag.content = "You are now following this user";
                    db.SaveChanges();
                }
            }
            return View();
        }







        // GET: UserLists
        public ActionResult Index()
        {
            var userLists = db.UserLists.Include(u => u.ListCategories);
            return View(userLists.ToList());
        }

        // GET: UserLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserList userList = db.UserLists.Find(id);
            if (userList == null)
            {
                return HttpNotFound();
            }
            return View(userList);
        }

        // GET: UserLists/Create
        public ActionResult Create()
        {
            ViewBag.ListCategoryId = new SelectList(db.ListCategories, "ListCategoryId", "ListCategories");
            return View();
        }

        // POST: UserLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ListId,Title,Description,ItemCategory,Link,Location,UserIsComplete,ApplicationUserId,ListCategoryId")] UserList userList)
        {
            if (ModelState.IsValid)
            {
                db.UserLists.Add(userList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ListCategoryId = new SelectList(db.ListCategories, "ListCategoryId", "ListCategories", userList.ListCategoryId);
            return View(userList);
        }

        // GET: UserLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserList userList = db.UserLists.Find(id);
            if (userList == null)
            {
                return HttpNotFound();
            }
            ViewBag.ListCategoryId = new SelectList(db.ListCategories, "ListCategoryId", "ListCategories", userList.ListCategoryId);
            return View(userList);
        }

        // POST: UserLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ListId,Title,Description,ItemCategory,Link,Location,UserIsComplete,ApplicationUserId,ListCategoryId")] UserList userList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ListCategoryId = new SelectList(db.ListCategories, "ListCategoryId", "ListCategories", userList.ListCategoryId);
            return View(userList);
        }

        // GET: UserLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserList userList = db.UserLists.Find(id);
            if (userList == null)
            {
                return HttpNotFound();
            }
            return View(userList);
        }

        // POST: UserLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserList userList = db.UserLists.Find(id);
            db.UserLists.Remove(userList);
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

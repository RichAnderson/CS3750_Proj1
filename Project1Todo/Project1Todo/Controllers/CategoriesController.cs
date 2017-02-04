using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project1Todo.Mappings;
using Project1Todo.Models;
using Project1Todo.Helpers;

namespace Project1Todo.Controllers
{
    public class CategoriesController : Controller
    {
        private CMSContext db = new CMSContext();

        // GET: Categories
        public ActionResult Index()
        {
            return View(db.Category.ToList());
        }


        // Build Item table from partial view _ItemTable
        public ActionResult BuildCategoriesTable(int? id)
        {            
            return PartialView("_CategoryTable", db.Category.ToList());
        }


        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Category.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Category.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // ***********************    IMPORTANT    ******************************//
        // create a form using ajax (Take the post and matches the type with model binding)
        // want to add functionality to update completed date completed = true
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AJAXCreate([Bind(Include = "CategoryId,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                var cat = db.Category.FirstOrDefault(n => n.CategoryName == category.CategoryName);
                if(cat == null)
                {
                    db.Category.Add(category);
                    db.SaveChanges();

                    if (Session[SettingsKeys.tempCategoriesList] == null)
                    {
                        var catList = new List<int>();
                        catList.Add(category.CategoryId);
                        Session.Add(SettingsKeys.tempCategoriesList, catList);
                    }
                    else
                    {
                        var catList = Session[SettingsKeys.tempCategoriesList] as List<int>;
                        catList.Add(category.CategoryId);
                        Session.Add(SettingsKeys.tempCategoriesList, catList);
                    }
                }
                else
                {
                    if (Session[SettingsKeys.tempCategoriesList] == null)
                    {
                        var catList = new List<int>();
                        catList.Add(cat.CategoryId);
                        Session.Add(SettingsKeys.tempCategoriesList, catList);
                    }
                    else
                    {
                        var catList = Session[SettingsKeys.tempCategoriesList] as List<int>;
                        catList.Add(cat.CategoryId);
                        Session.Add(SettingsKeys.tempCategoriesList, catList);
                    }
                }
                
            }
            return PartialView("_CategoryTable", db.Category.ToList());
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Category.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Category.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Category.Find(id);
            db.Category.Remove(category);
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

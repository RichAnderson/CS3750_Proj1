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
    public class ListsController : Controller
    {
        private CMSContext db = new CMSContext();

        // GET: Lists
        public ActionResult Index()
        {
            return View(db.List.ToList());
        }



        // GET: Lists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List list = db.List.Find(id);
            if (list == null)
            {
                return HttpNotFound();
            }
            return View(list);
        }

        // GET: Lists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ListId,ListName")] List list)
        {
            if (ModelState.IsValid)
            {                
                db.List.Add(list);
                db.SaveChanges();

                if (Session[SettingsKeys.tempItemsList] != null)
                {
                    var itemsList = Session[SettingsKeys.tempItemsList] as List<int>;
                    foreach (int i in itemsList)
                    {
                        var item = db.Item.Find(i);
                        //set each created items ListId to current lists ID
                        item.ListId = list.ListId;
                        db.Entry(item).State = EntityState.Modified;
                        //add each created item to this Lists collection<Item>
                        list.Items.Add(item);
                        db.Entry(list).State = EntityState.Modified;

                        db.SaveChanges();
                    }
                    Session[SettingsKeys.tempItemsList] = null;  //delete session tempItemsList
                }

                if (Session[SettingsKeys.tempCategoriesList] != null)
                {
                    var catList = Session[SettingsKeys.tempCategoriesList] as List<int>;
                    foreach (int i in catList)
                    {
                        var cat = db.Category.Find(i);
                        var c = db.Category.FirstOrDefault(n => n.CategoryName == cat.CategoryName);

                        // Add this list to all created categories collection<List>
                        cat.Lists.Add(list);
                        db.Entry(cat).State = EntityState.Modified;

                        // Add all created categories to this lists collection<Category>
                        list.Categories.Add(cat);
                        db.Entry(list).State = EntityState.Modified;

                        db.SaveChanges();
                    }
                    Session[SettingsKeys.tempCategoriesList] = null;   //delete session tempCategoriesList
                }


                return RedirectToAction("Index");
            }

            return View(list);
        }

        // GET: Lists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List list = db.List.Find(id);
            if (list == null)
            {
                return HttpNotFound();
            }
            return View(list);
        }

        // POST: Lists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ListId,ListName")] List list)
        {
            if (ModelState.IsValid)
            {
                db.Entry(list).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(list);
        }

        // GET: Lists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List list = db.List.Find(id);
            if (list == null)
            {
                return HttpNotFound();
            }
            return View(list);
        }

        // POST: Lists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            List list = db.List.Find(id);
            db.List.Remove(list);
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

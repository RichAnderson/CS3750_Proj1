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

namespace Project1Todo.Controllers
{
    public class ItemsController : Controller
    {
        private CMSContext db = new CMSContext();

        // GET: Items
        public ActionResult Index()
        {
            // return PartialView("_ItemTable", Json(db.Item.ToList(), JsonRequestBehavior.AllowGet));
            return View(db.Item.ToList());
        }

        // Build Item table from partial view _ItemTable
        public ActionResult BuildItemsTable()
        {
            //return PartialView("_ItemTable", Json(db.Item.ToList(), JsonRequestBehavior.AllowGet));
            return PartialView("_ItemTable", db.Item.ToList());
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Item.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemId,ItemName,Complete,CompletionDate")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Item.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(item);
        }

        // ***********************    IMPORTANT    ******************************//
        // create a form using ajax (Take the post and matches the type with model binding)
        // want to add functionality to update completed date completed = true
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AJAXCreate([Bind(Include = "ItemId,ItemName")] Item item)
        {
            if (ModelState.IsValid)
            {
                item.Complete = false;
                item.CompletionDate = null;
                db.Item.Add(item);
                db.SaveChanges();
            }

            //return PartialView("_ItemTable", Json(db.Item.ToList(), JsonRequestBehavior.AllowGet));
            return PartialView("_ItemTable", db.Item.ToList());
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Item.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemId,ItemName,Complete,CompletionDate")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // ***********************    IMPORTANT    ******************************//
        // edit a form using ajax
        [HttpPost]
        public ActionResult AJAXEdit(int? id, bool value)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Item.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            else
            {
                item.Complete = value;
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
            }
            return PartialView("_ItemTable", db.Item.ToList());
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Item.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Item.Find(id);
            db.Item.Remove(item);
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

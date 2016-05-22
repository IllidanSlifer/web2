using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrudEjemplo.Models;

namespace CrudEjemplo.Controllers
{
    public class crudsController : Controller
    {
        private CRUDEntities db = new CRUDEntities();

        // GET: cruds
        public ActionResult Index()
        {
            return View(db.crud.ToList());
        }

        // GET: cruds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            crud crud = db.crud.Find(id);
            if (crud == null)
            {
                return HttpNotFound();
            }
            return View(crud);
        }

        // GET: cruds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cruds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,mobile,email")] crud crud)
        {
            if (ModelState.IsValid)
            {
                db.crud.Add(crud);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(crud);
        }

        // GET: cruds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            crud crud = db.crud.Find(id);
            if (crud == null)
            {
                return HttpNotFound();
            }
            return View(crud);
        }

        // POST: cruds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,mobile,email")] crud crud)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crud).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(crud);
        }

        // GET: cruds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            crud crud = db.crud.Find(id);
            if (crud == null)
            {
                return HttpNotFound();
            }
            return View(crud);
        }

        // POST: cruds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            crud crud = db.crud.Find(id);
            db.crud.Remove(crud);
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

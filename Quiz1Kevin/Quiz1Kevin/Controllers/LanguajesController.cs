using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Quiz1Kevin.Models;

namespace Quiz1Kevin.Controllers
{
    public class LanguajesController : Controller
    {
        private quiz1Entities1 db = new quiz1Entities1();

        // GET: Languajes
        public ActionResult Index()
        {
            return View(db.Languajes.ToList());
        }

        // GET: Languajes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Languajes languajes = db.Languajes.Find(id);
            if (languajes == null)
            {
                return HttpNotFound();
            }
            return View(languajes);
        }

        // GET: Languajes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Languajes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] Languajes languajes)
        {
            if (ModelState.IsValid)
            {
                db.Languajes.Add(languajes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(languajes);
        }

        // GET: Languajes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Languajes languajes = db.Languajes.Find(id);
            if (languajes == null)
            {
                return HttpNotFound();
            }
            return View(languajes);
        }

        // POST: Languajes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name")] Languajes languajes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(languajes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(languajes);
        }

        // GET: Languajes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Languajes languajes = db.Languajes.Find(id);
            if (languajes == null)
            {
                return HttpNotFound();
            }
            return View(languajes);
        }

        // POST: Languajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Languajes languajes = db.Languajes.Find(id);
            db.Languajes.Remove(languajes);
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

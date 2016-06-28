using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Quiz1Kevin.Models;

namespace Quiz1Kevin.Controllers
{
    public class DegreesController : Controller
    {
        private quiz1Entities db = new quiz1Entities();

        // GET: Degrees
        public async Task<ActionResult> Index()
        {
            return View(await db.Degree.ToListAsync());
        }

        // GET: Degrees/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Degree degree = await db.Degree.FindAsync(id);
            if (degree == null)
            {
                return HttpNotFound();
            }
            return View(degree);
        }

        // GET: Degrees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Degrees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,Year,University")] Degree degree)
        {
            if (ModelState.IsValid)
            {
                db.Degree.Add(degree);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(degree);
        }

        // GET: Degrees/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Degree degree = await db.Degree.FindAsync(id);
            if (degree == null)
            {
                return HttpNotFound();
            }
            return View(degree);
        }

        // POST: Degrees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Name,Year,University")] Degree degree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(degree).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(degree);
        }

        // GET: Degrees/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Degree degree = await db.Degree.FindAsync(id);
            if (degree == null)
            {
                return HttpNotFound();
            }
            return View(degree);
        }

        // POST: Degrees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Degree degree = await db.Degree.FindAsync(id);
            db.Degree.Remove(degree);
            await db.SaveChangesAsync();
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

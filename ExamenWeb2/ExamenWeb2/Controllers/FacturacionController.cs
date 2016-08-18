using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamenWeb2.Models;

namespace ExamenWeb2.Controllers
{
    public class FacturacionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Facturacion
        public ActionResult Index()
        {
            var facturaciones = db.Facturaciones.Include(f => f.Cliente).Include(f => f.Inventario);
            return View(facturaciones.ToList());
        }

        // GET: Facturacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facturacion facturacion = db.Facturaciones.Find(id);
            if (facturacion == null)
            {
                return HttpNotFound();
            }
            return View(facturacion);
        }

        // GET: Facturacion/Create
        public ActionResult Create()
        {
            ViewBag.ClienteID = new SelectList(db.Clientes, "Id", "Cedula");
            ViewBag.InventarioID = new SelectList(db.Inventarios, "Id", "Cantidad");
            return View();
        }

        // POST: Facturacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MontoTotal,SubTotal,Detalle,ClienteID,ProductosID,InventarioID")] Facturacion facturacion)
        {
            if (ModelState.IsValid)
            {
                db.Facturaciones.Add(facturacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteID = new SelectList(db.Clientes, "Id", "Cedula", facturacion.ClienteID);
            ViewBag.InventarioID = new SelectList(db.Inventarios, "Id", "Cantidad", facturacion.InventarioID);
            return View(facturacion);
        }



        // POST: Facturacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
   


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

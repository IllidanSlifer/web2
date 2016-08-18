using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ExamenWeb2.Models;

namespace ExamenWeb2.Controllers
{
    public class FacturacionsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Facturacions
        public IQueryable<Facturacion> GetFacturaciones()
        {
            return db.Facturaciones;
        }

        // GET: api/Facturacions/5
        [ResponseType(typeof(Facturacion))]
        public IHttpActionResult GetFacturacion(int id)
        {
            Facturacion facturacion = db.Facturaciones.Find(id);
            if (facturacion == null)
            {
                return NotFound();
            }

            return Ok(facturacion);
        }

        // PUT: api/Facturacions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFacturacion(int id, Facturacion facturacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != facturacion.Id)
            {
                return BadRequest();
            }

            db.Entry(facturacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturacionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Facturacions
        [ResponseType(typeof(Facturacion))]
        public IHttpActionResult PostFacturacion(Facturacion facturacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Facturaciones.Add(facturacion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = facturacion.Id }, facturacion);
        }

        // DELETE: api/Facturacions/5
        [ResponseType(typeof(Facturacion))]
        public IHttpActionResult DeleteFacturacion(int id)
        {
            Facturacion facturacion = db.Facturaciones.Find(id);
            if (facturacion == null)
            {
                return NotFound();
            }

            db.Facturaciones.Remove(facturacion);
            db.SaveChanges();

            return Ok(facturacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FacturacionExists(int id)
        {
            return db.Facturaciones.Count(e => e.Id == id) > 0;
        }
    }
}
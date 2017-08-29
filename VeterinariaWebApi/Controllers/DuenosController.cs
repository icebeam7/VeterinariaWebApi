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
using Veterinaria.Modelos;
using VeterinariaWebApi.Models;

namespace VeterinariaWebApi.Controllers
{
    public class DuenosController : ApiController
    {
        private VeterinariaWebApiContext db = new VeterinariaWebApiContext();

        // GET: api/Duenos
        public IQueryable<Dueno> GetDuenoes()
        {
            var data = db.Duenoes;
            db.Configuration.LazyLoadingEnabled = false;
            return data;
        }

        // GET: api/Duenos/5
        [ResponseType(typeof(Dueno))]
        public IHttpActionResult GetDueno(int id)
        {
            Dueno dueno = db.Duenoes.Find(id);
            if (dueno == null)
            {
                return NotFound();
            }

            return Ok(dueno);
        }

        // PUT: api/Duenos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDueno(int id, Dueno dueno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dueno.Id)
            {
                return BadRequest();
            }

            db.Entry(dueno).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DuenoExists(id))
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

        // POST: api/Duenos
        [ResponseType(typeof(Dueno))]
        public IHttpActionResult PostDueno(Dueno dueno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Duenoes.Add(dueno);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dueno.Id }, dueno);
        }

        // DELETE: api/Duenos/5
        [ResponseType(typeof(Dueno))]
        public IHttpActionResult DeleteDueno(int id)
        {
            Dueno dueno = db.Duenoes.Find(id);
            if (dueno == null)
            {
                return NotFound();
            }

            db.Duenoes.Remove(dueno);
            db.SaveChanges();

            return Ok(dueno);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DuenoExists(int id)
        {
            return db.Duenoes.Count(e => e.Id == id) > 0;
        }
    }
}
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
    public class CartillasController : ApiController
    {
        private VeterinariaWebApiContext db = new VeterinariaWebApiContext();

        // GET: api/Cartillas
        public IQueryable<Cartilla> GetCartillas()
        {
            var data = db.Cartillas.OrderBy(x => x.Nombre);
            db.Configuration.LazyLoadingEnabled = false;
            return data;
        }

        // GET: api/Cartillas/5
        [ResponseType(typeof(Cartilla))]
        public IHttpActionResult GetCartilla(int id)
        {
            Cartilla cartilla = db.Cartillas.Find(id);
            if (cartilla == null)
            {
                return NotFound();
            }

            return Ok(cartilla);
        }

        // PUT: api/Cartillas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCartilla(int id, Cartilla cartilla)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cartilla.Id)
            {
                return BadRequest();
            }

            db.Entry(cartilla).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartillaExists(id))
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

        // POST: api/Cartillas
        [ResponseType(typeof(Cartilla))]
        public IHttpActionResult PostCartilla(Cartilla cartilla)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cartillas.Add(cartilla);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cartilla.Id }, cartilla);
        }

        // DELETE: api/Cartillas/5
        [ResponseType(typeof(Cartilla))]
        public IHttpActionResult DeleteCartilla(int id)
        {
            Cartilla cartilla = db.Cartillas.Find(id);
            if (cartilla == null)
            {
                return NotFound();
            }

            db.Cartillas.Remove(cartilla);
            db.SaveChanges();

            return Ok(cartilla);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CartillaExists(int id)
        {
            return db.Cartillas.Count(e => e.Id == id) > 0;
        }
    }
}
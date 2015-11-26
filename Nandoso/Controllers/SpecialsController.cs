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
using Nandoso.Models;
using Special.Models;
using System.Xml.Linq;

namespace Nandoso.Controllers
{
    public class SpecialsController : ApiController
    {
        private NandosoContext db = new NandosoContext();

        // GET: api/Specials
        public IQueryable<Specials> GetSpecials()
        {
            return db.Special;
        }

        // GET: api/Specials/5
        [ResponseType(typeof(Specials))]
        public IHttpActionResult GetSpecial(int id)
        {
            Specials special = db.Special.Find(id);
            if (special == null)
            {
                return NotFound();
            }

            return Ok(special);
        }

        // PUT: api/Specials/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSpecial(int id, Specials special)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != special.ID)
            {
                return BadRequest();
            }

            db.Entry(special).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialExists(id))
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

        // POST: api/Specials
        [ResponseType(typeof(Specials))]
        public IHttpActionResult PostSpecial(Specials Special)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Special.Add(Special);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = Special.ID }, Special);
        }

        // DELETE: api/Specials/5
        [ResponseType(typeof(Specials))]
        public IHttpActionResult DeleteSpecial(int id)
        {
            Specials special = db.Special.Find(id);
            if (special == null)
            {
                return NotFound();
            }

            db.Special.Remove(special);
            db.SaveChanges();

            return Ok(special);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpecialExists(int id)
        {
            return db.Special.Count(e => e.ID == id) > 0;
        }
    }
}
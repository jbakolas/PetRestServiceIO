using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using PetRestServiceIOB.Models;

namespace PetRestServiceIOB.Controllers
{
    public class PetWalkersController : ApiController
    {
        private PetRestServiceIOBContext db = new PetRestServiceIOBContext();

        // GET: api/PetWalkers
        public IQueryable<PetWalker> GetPetWalkers()
        {
            return db.PetWalkers;
        }

        // GET: api/PetWalkers/5
        [ResponseType(typeof(PetWalker))]
        public async Task<IHttpActionResult> GetPetWalker(int id)
        {
            PetWalker petWalker = await db.PetWalkers.FindAsync(id);
            if (petWalker == null)
            {
                return NotFound();
            }

            return Ok(petWalker);
        }

        // PUT: api/PetWalkers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPetWalker(int id, PetWalker petWalker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != petWalker.walkerId)
            {
                return BadRequest();
            }

            db.Entry(petWalker).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetWalkerExists(id))
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

        // POST: api/PetWalkers
        [ResponseType(typeof(PetWalker))]
        public async Task<IHttpActionResult> PostPetWalker(PetWalker petWalker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PetWalkers.Add(petWalker);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = petWalker.walkerId }, petWalker);
        }

        // DELETE: api/PetWalkers/5
        [ResponseType(typeof(PetWalker))]
        public async Task<IHttpActionResult> DeletePetWalker(int id)
        {
            PetWalker petWalker = await db.PetWalkers.FindAsync(id);
            if (petWalker == null)
            {
                return NotFound();
            }

            db.PetWalkers.Remove(petWalker);
            await db.SaveChangesAsync();

            return Ok(petWalker);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PetWalkerExists(int id)
        {
            return db.PetWalkers.Count(e => e.walkerId == id) > 0;
        }
    }
}
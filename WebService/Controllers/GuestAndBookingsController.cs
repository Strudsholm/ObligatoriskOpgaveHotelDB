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
using WebService;

namespace WebService.Controllers
{
    public class GuestAndBookingsController : ApiController
    {
        private ViewContext db = new ViewContext();

        // GET: api/GuestAndBookings
        public IQueryable<GuestAndBookings> GetGuestAndBookings()
        {
            return db.GuestAndBookings;
        }

        // GET: api/GuestAndBookings/5
        [ResponseType(typeof(GuestAndBookings))]
        public IHttpActionResult GetGuestAndBookings(string id)
        {
            GuestAndBookings guestAndBookings = db.GuestAndBookings.Find(id);
            if (guestAndBookings == null)
            {
                return NotFound();
            }

            return Ok(guestAndBookings);
        }

        // PUT: api/GuestAndBookings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGuestAndBookings(string id, GuestAndBookings guestAndBookings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != guestAndBookings.Name)
            {
                return BadRequest();
            }

            db.Entry(guestAndBookings).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuestAndBookingsExists(id))
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

        // POST: api/GuestAndBookings
        [ResponseType(typeof(GuestAndBookings))]
        public IHttpActionResult PostGuestAndBookings(GuestAndBookings guestAndBookings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GuestAndBookings.Add(guestAndBookings);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GuestAndBookingsExists(guestAndBookings.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = guestAndBookings.Name }, guestAndBookings);
        }

        // DELETE: api/GuestAndBookings/5
        [ResponseType(typeof(GuestAndBookings))]
        public IHttpActionResult DeleteGuestAndBookings(string id)
        {
            GuestAndBookings guestAndBookings = db.GuestAndBookings.Find(id);
            if (guestAndBookings == null)
            {
                return NotFound();
            }

            db.GuestAndBookings.Remove(guestAndBookings);
            db.SaveChanges();

            return Ok(guestAndBookings);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GuestAndBookingsExists(string id)
        {
            return db.GuestAndBookings.Count(e => e.Name == id) > 0;
        }
    }
}
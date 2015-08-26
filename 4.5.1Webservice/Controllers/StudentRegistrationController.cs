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
using _4._5._1Webservice;

namespace _4._5._1Webservice.Controllers
{
    public class StudentRegistrationsController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/StudentRegistrations
        public IQueryable<StudentRegistration> GetStudentRegistrations()
        {
            return db.StudentRegistrations;
        }

        ////Gets the first 30 Registrations (because its sorted by date, descending.)
        //// skipnr skips the specified amount, for example next page contains nr 31-60
        //public IQueryable<StudentRegistration> Get30StudentRegistrations(int skipNr)
        //{
        //    var studregList = (from s in db.StudentRegistrations
        //                       select s).Skip(skipNr).Take(30);
        //    return studregList;
        //}
        // GET: api/StudentRegistrations/5
        [ResponseType(typeof(StudentRegistration))]
        public async Task<IHttpActionResult> GetStudentRegistration(int id)
        {
            StudentRegistration StudentRegistration = await db.StudentRegistrations.FindAsync(id);
            if (StudentRegistration == null)
            {
                return NotFound();
            }

            return Ok(StudentRegistration);
        }

        // PUT: api/StudentRegistrations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStudentRegistration(int id, StudentRegistration StudentRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != StudentRegistration.Id)
            {
                return BadRequest();
            }

            db.Entry(StudentRegistration).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentRegistrationExists(id))
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

        // POST: api/StudentRegistrations
        [ResponseType(typeof(StudentRegistration))]
        public async Task<IHttpActionResult> PostStudentRegistration(StudentRegistration StudentRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StudentRegistrations.Add(StudentRegistration);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = StudentRegistration.Id }, StudentRegistration);
        }

        // DELETE: api/StudentRegistrations/5
        [ResponseType(typeof(StudentRegistration))]
        public async Task<IHttpActionResult> DeleteStudentRegistration(int id)
        {
            StudentRegistration StudentRegistration = await db.StudentRegistrations.FindAsync(id);
            if (StudentRegistration == null)
            {
                return NotFound();
            }

            db.StudentRegistrations.Remove(StudentRegistration);
            await db.SaveChangesAsync();

            return Ok(StudentRegistration);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentRegistrationExists(int id)
        {
            return db.StudentRegistrations.Count(e => e.Id == id) > 0;
        }
    }
}
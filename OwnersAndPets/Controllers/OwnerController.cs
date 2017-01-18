using OwnersAndPets.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;


namespace OwnersAndPets.Controllers
{
    public class OwnerController : ApiController
    {
        private OwnersAndPetsContext db = new OwnersAndPetsContext();
       
        public IEnumerable<OwnersViewModel> GetOwners()
        {
                return db.Owners.Include(x => x.Pets)
                         .AsEnumerable()
                         .Select(x => new OwnersViewModel
                         {
                             Id = x.Id,
                             Name = x.Name,
                             PetCount = x.Pets.Count()
                         });
        }

        /// POST api/<controller>
        public HttpResponseMessage PostOwner(Owner Owner)
        {
            if (ModelState.IsValid)
            {
                db.Owners.Add(Owner);
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, Owner);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = Owner.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/values/5
        [ResponseType(typeof(Owner))]
        public IHttpActionResult DeleteOwner(int id)
        {
            Owner owner = db.Owners.Find(id);
            if (owner == null)
            {
                return NotFound();
            }
            db.Owners.Remove(owner);
            db.SaveChanges();
            return Ok(owner);
        }
    }
}

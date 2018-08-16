using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DataAccess;
using WebAPIEvol.Filters;

namespace WebAPIEvol.Controllers
{
    [CustomExceptionFilter]
    public class ContactController : ApiController
    {
        EvolDataAccess objEvolDataAccess;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ContactController()
        {
             objEvolDataAccess = new EvolDataAccess();
        }
            
        [HttpGet]
        public IHttpActionResult GET()
        {
            log.Info("Contact : GET"); 
            List<Contact> contacts = objEvolDataAccess.GetAllContact();
            if (contacts == null)
            {
                return NotFound(); // Returns a NotFoundResult
            }
            return Ok(contacts);
        }

        [HttpGet]
        public IHttpActionResult GET(int id)
        {
            Contact contact = objEvolDataAccess.GetContactById(id);
            if (contact == null)
            {
                return NotFound(); // Returns a NotFoundResult
            }
            return Ok(contact);
        }

        [HttpPost]
        public IHttpActionResult POST(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool isSuccess = objEvolDataAccess.AddContact(contact);

            return Ok(contact);
        }

        [HttpPut]
        public IHttpActionResult PUT(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool isSuccess = objEvolDataAccess.UpdateContact(contact);
           
            return Ok(contact);
        }

        [HttpDelete]
        public IHttpActionResult DELETE(int Id)
        {
            bool isSuccess = objEvolDataAccess.DeleteContact(Id);

            if (isSuccess == false)
            {
                return NotFound(); // Returns a NotFoundResult
            }

            return Ok();
        }
    }
}

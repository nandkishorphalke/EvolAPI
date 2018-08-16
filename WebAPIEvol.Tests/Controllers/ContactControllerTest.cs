using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPIEvol;
using WebAPIEvol.Controllers;

namespace WebAPIEvol.Tests.Controllers
{
    [TestClass]
    public class ContactControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            ContactController controller = new ContactController();

            // Act
            var result = controller.GET();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            ContactController controller = new ContactController();

            // Act
            IHttpActionResult result = controller.GET(1);
            var contentResult = result as OkNegotiatedContentResult<Contact>;

            // Assert
            Assert.AreEqual(1, contentResult.Content.ContactId);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            ContactController controller = new ContactController();

            Contact objContact = new Contact() { 
                                                Email = "Test@test.com",
                                                FirstName = "FNameTest",
                                                LastName = "LNameTest",
                                                PhoneNumber = "00000000",
                                                Status = false
                                                
                                                  };

            // Act
            IHttpActionResult result = controller.POST(objContact);
            var contentResult = result as OkNegotiatedContentResult<bool>;
            // Assert
            Assert.AreEqual(true, contentResult.Content);
          
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            ContactController controller = new ContactController();

            Contact objContact = new Contact()
            {
                ContactId = 1,
                Email = "Test@test.com",
                FirstName = "FNameTest",
                LastName = "LNameTest",
                PhoneNumber = "00000000",
                Status = false
            };


            // Act
            IHttpActionResult result = controller.PUT(objContact);

            // Assert
            var contentResult = result as OkNegotiatedContentResult<bool>;
            Assert.AreEqual(true, contentResult.Content);
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            ContactController controller = new ContactController();

            // Act
            IHttpActionResult result =  controller.DELETE(1);

            // Assert
            var contentResult = result as OkNegotiatedContentResult<bool>;
            Assert.AreEqual(true, contentResult.Content);
        }
    }
}

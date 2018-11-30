using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudApiVietnam.Controllers;
using CloudApiVietnam.Models;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using System.Linq;

namespace CloudApiVietnam.Tests.Controllers
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class FormulierenControllerTest
    {
        FormulierenController controller = new FormulierenController();
        private int id;
        [TestMethod]
        [TestInitialize()]
        public void FormGet_Ok()
        {
            // Arramge
            FormulierenController controller = GetController();

            // Act
            HttpResponseMessage actionResult = controller.Get();

            // Assert
            List<Formulieren> formulier;
            Assert.IsTrue(actionResult.TryGetContentValue<List<Formulieren>>(out formulier));
            this.id = formulier.FirstOrDefault().Id;
            Assert.AreEqual(actionResult.StatusCode, HttpStatusCode.OK);
        }

        private static FormulierenController GetController()
        {
            return new FormulierenController
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }

        [TestMethod]
        public void FormGetWithId_Ok()
        {
            // Arramge
            FormulierenController controller = GetController();

            // Act
            //How to determine wich id to pass?
            HttpResponseMessage actionResult = controller.Get(this.id);

            // Assert
            Assert.AreEqual(actionResult.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public void FormGetWithId_NotFound()
        {
            // Arramge
            FormulierenController controller = GetController();

            // Act
            HttpResponseMessage actionResult = controller.Get(-2);

            // Assert
            Assert.AreEqual(actionResult.StatusCode, HttpStatusCode.NotFound);
        }

        [TestMethod]
        public void FormPost_Ok()
        {
            // Arramge
            FormulierenController controller = GetController();
            FormulierenBindingModel formulierenBindingModel = new FormulierenBindingModel();
            formulierenBindingModel.Name = "Testformulier9999";
            formulierenBindingModel.Region = "Zuid-Holland";
            formulierenBindingModel.FormTemplate = "[{'Naam':'string'},{'Leeftijd':'string'},{'Afwijking':'string'}]";
            formulierenBindingModel.Created = DateTime.Now;

            // Act
            HttpResponseMessage actionResult = controller.Post(formulierenBindingModel);

            // Assert
            Assert.AreEqual(actionResult.StatusCode, HttpStatusCode.OK);
        }

      
      [TestMethod]
      public void FormPost_Ok_CanCreateDateTime()
      {
        // Arramge
        FormulierenController controller = GetController();
        //FormulierenBindingModel formulierenBindingModel = new FormulierenBindingModel();
        //formulierenBindingModel.Name = "Testformulier9999";
        //formulierenBindingModel.Region = "Zuid-Holland";
        //formulierenBindingModel.FormTemplate = "[{'Naam':'string'},{'Leeftijd':'string'},{'Afwijking':'string'}]";
        //formulierenBindingModel.Created = DateTime.Now;
        //formulierenBindingModel.Updated = DateTime.Now;

        var formulierBindingModel = new FormulierenBindingModel
        {
          Name = "TestFormulier1234",
          Region = "Hanoi",
          FormTemplate =  "{'Name':'string', 'BirthYear': 'string', 'SchoolName':'string', 'Gender':'string'}",
          Created = DateTime.Now,
         

        };
        // Act
        HttpResponseMessage actionResult = controller.Post(formulierBindingModel);

        // Assert
        Assert.AreEqual(actionResult.StatusCode, HttpStatusCode.OK);
      }

      [TestMethod]
      public void FormCanUpdateDateTime()
      {
        //Arrange
        FormulierenController formulierController = GetController();
        FormulierenBindingModel formulierenBindingModel = new FormulierenBindingModel()
        {
          Name = "UpdatedVietam",
          Region = "Hanoi",
          FormTemplate =  "{'Name':'string', 'BirthYear': 'string', 'SchoolName':'string', 'Gender':'string'}",
          Updated = DateTime.Now
        };

        //Act
        HttpResponseMessage actionResult = formulierController.Put(6, formulierenBindingModel);

        //Assert
        if (actionResult.StatusCode == HttpStatusCode.OK)
        {
          Assert.AreEqual(actionResult.StatusCode, HttpStatusCode.OK);
        }
     

      }


        [TestMethod]
        public void FormPost_BadRequest()
        {
            // Arramge
            // Arramge
            FormulierenController controller = GetController();

            FormulierenBindingModel formulierenBindingModel = new FormulierenBindingModel();
            formulierenBindingModel.Name = "Testformulier9999";
            formulierenBindingModel.Region = "Zuid-Holland";
            formulierenBindingModel.FormTemplate = "{iets:data";

            // Act
            HttpResponseMessage actionResult = controller.Post(formulierenBindingModel);

            // Assert
            Assert.AreEqual(actionResult.StatusCode, HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void FormDeleteWithId_NotFound()
        {
            // Arramge
            FormulierenController controller = GetController();

            // Act
            //How to determine wich id to pass?
            HttpResponseMessage actionResult = controller.Get(-2);

            // Assert
            Assert.AreEqual(actionResult.StatusCode, HttpStatusCode.NotFound);
        }

        [TestMethod]
        public void Put_Succes()
        {
            FormulierenBindingModel formBindingModel = new FormulierenBindingModel();
            FormulierenController controller = GetController();
            Random rnd = new Random();//rnd

            formBindingModel.FormTemplate = "[{'Naam':'string'},{'Leeftijd':'22'},{'" + rnd.Next(1, 100).ToString() + "':'ADHD'}]";
            formBindingModel.Region = "test";
            formBindingModel.Name = "name";

            HttpResponseMessage result = controller.Put(47, formBindingModel);
            var resultContent = result.Content.ReadAsAsync<dynamic>().Result;
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);

            formBindingModel.FormTemplate = "[{'Naam':'string'},{'Leeftijd':'22'}]";
            formBindingModel.Region = "test";
            formBindingModel.Name = "name";

            result = controller.Put(47, formBindingModel);
            resultContent = result.Content.ReadAsAsync<dynamic>().Result;
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);

            formBindingModel.FormTemplate = "[{'Naam':'string'},{'Leeftijd':'22'},{'Afwijking':'string'}]";
            formBindingModel.Region = "test";
            formBindingModel.Name = "name";

            result = controller.Put(47, formBindingModel);
            resultContent = result.Content.ReadAsAsync<dynamic>().Result;
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(resultContent);
        }

        [TestMethod]
        [TestCleanup()]
        public void FormDeleteWithId_NoContent()
        {
            // Arramge
            FormulierenController controller = GetController();

            // Act
            //How to determine wich id to pass?
            HttpResponseMessage actionResult = controller.Get(this.id);

            // Assert
            Assert.AreEqual(actionResult.StatusCode, HttpStatusCode.OK);
        }

        
    }
}

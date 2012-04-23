using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FundDataMaintenaceBusiness.Interfaces;
using FundDataMaintenaceBusiness.Models;
using FundDataMaintenance.Controllers;
using Moq;
using NUnit.Framework;

namespace FundDataMaintenanceTst
{
    [TestFixture]
    class UmbrellaControllerTest
    {
        Mock<IUmbrellaService> _service;

        [SetUp]
        public void Setup()
        {
            _service = new Mock<IUmbrellaService>();
        }

        [Test]
        public void WhenTheIndexActionIsExecuted_ThenItShouldReturnAViewResult()
        {
            _service.Setup(o => o.GetUmbrellas()).Returns(new List<UmbrellaSM>());
            var controller = new UmbrellaController(_service.Object);
            var results = controller.Index();
            Assert.That(results, Is.TypeOf(typeof(ViewResult)));
        }

        [Test]
        public void WhenTheEditActionIsExecuted_ThenItShouldReturnAViewResult()
        {
            _service.Setup(o => o.GetUmbrellaById(new int())).Returns(new UmbrellaSM());
            var controller = new UmbrellaController(_service.Object);
            var results = controller.Edit(new int());
            Assert.That(results, Is.TypeOf(typeof(ViewResult)));
        }
    }
}

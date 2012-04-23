using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;
using FundDataMaintenaceBusiness.Models;
using FundDataMaintenaceBusiness.Services;
using FundDataMaintenanceData;
using FundDataMaintenanceRepository.Interfaces;
using Moq;
using NUnit.Framework;

namespace FundDataMaintenanceTest.Services
{
    [TestFixture]
    class UmbrellaServiceTest
    {
        Mock<IUmbrellaRepository> _umbrellaRepository;
        Mock<IReferenceRepository> _referenceRepository;
        Mock<IPartyRepository> _partyRepository;

        [SetUp]
        public void Setup()
        {
            _umbrellaRepository = new Mock<IUmbrellaRepository>();
            _referenceRepository = new Mock<IReferenceRepository>();
            _partyRepository = new Mock<IPartyRepository>();
        }

        [Test]
        public void WhenTheGetUmbrellasMethodIsExecuted_ThenItShouldReturnAList()
        {
            _umbrellaRepository.Setup(o => o.GetUmbrellas()).Returns((new List<UMBRELLA>()).AsQueryable);
            var service = new UmbrellaService(_umbrellaRepository.Object, _partyRepository.Object, _referenceRepository.Object);
            var result = service.GetUmbrellas();
            Assert.That(result, Is.TypeOf(typeof(List<UmbrellaSM>)));
        }

        [Test]
        public void WhenTheGetUmbrellaByIdisExecuted_ThenItShouldReturnASingleUmbrella()
        {
            _umbrellaRepository.Setup(o => o.GetUmbrella(new int())).Returns(new UMBRELLA()
                                                                         {
                                                                             UMBRELLA_ID = 1,
                                                                             CODE = "TEST",
                                                                             LEGAL_NAME = "LEGAL NAME TEST",
                                                                             PARTY_ROLE2 = new PARTY_ROLE
                                                                                               {
                                                                                                   PARTY = new PARTY
                                                                                                               {
                                                                                                                   NAME = "CUSTODIAN NAME TEST"
                                                                                                               }
                                                                                               },
                                                                             ACTIVE_IND = "Y",
                                                                             FUNDs = new EntityCollection<FUND>()
                                                                         });
            // todo: setup partyrepository mock data
            var service = new UmbrellaService(_umbrellaRepository.Object, _partyRepository.Object, _referenceRepository.Object);
            var result = service.GetUmbrellaById(new int());
            Assert.That(result, Is.TypeOf(typeof(UmbrellaSM)));
        }

    }
}

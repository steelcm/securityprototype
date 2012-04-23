using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Web.Security;
using FundDataMaintenaceBusiness.Interfaces;
using FundDataMaintenaceBusiness.Models;
using FundDataMaintenaceBusiness.Services;
using FundDataMaintenance.Attributes;
using FundDataMaintenance.Models;
using AutoMapper;

namespace FundDataMaintenance.Controllers{

    public class UmbrellaController : Controller
    {
        private readonly IUmbrellaService _umbrellaService;

        public UmbrellaController(IUmbrellaService umbrellaRepository)
        {
            _umbrellaService = umbrellaRepository;
        }

        [HttpGet, Authorization]
        public ActionResult Index()
        {            
            Mapper.CreateMap<UmbrellaSM, UmbrellaIndexVM>();
            var viewModel = _umbrellaService.GetUmbrellas().Select(Mapper.Map<UmbrellaIndexVM>).ToList();
            return View(viewModel);
        }

        [HttpGet, Authorization(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            Mapper.CreateMap<UmbrellaSM, UmbrellaEditVM>();
            var viewModel = Mapper.Map<UmbrellaEditVM>(_umbrellaService.GetUmbrellaById(id));
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Update(UmbrellaEditVM viewModel)
        {
            return null;
        }

    }
}

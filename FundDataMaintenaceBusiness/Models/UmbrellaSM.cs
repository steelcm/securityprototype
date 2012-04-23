using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace FundDataMaintenaceBusiness.Models
{
    public class UmbrellaSM
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int DomicileCountryId { get; set; }
        public IList<SelectListItem> DomicileCountrySelectList { get; set; }
        public int VehicleTypeId { get; set; }
        public IList<SelectListItem> VehicleTypeSelectList { get; set; }
        public int FiscalYearEndId { get; set; }
        public IList<SelectListItem> FiscalYearEndSelectList { get; set; }
        public string Custodian { get; set; }
        public int CustodianId { get; set; }
        public IList<SelectListItem> CustodianSelectList { get; set; }
        public int FileProviderId { get; set; }
        public IList<SelectListItem> FileProviderSelectList { get; set; }
        public int AdminManagerId { get; set; }
        public IList<SelectListItem> AdminManagerSelectList { get; set; }
        public int PayingAgentId { get; set; }
        public IList<SelectListItem> PayingAgentSelectList { get; set; }
        public int LegalAdviserId { get; set; }
        public IList<SelectListItem> LegalAdviserSelectList { get; set; }
        public bool Active { get; set; }
        public int ActiveFundCount { get; set; }
    }
}

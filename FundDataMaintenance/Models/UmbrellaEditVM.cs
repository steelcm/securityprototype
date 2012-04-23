using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FundDataMaintenance.Attributes;

namespace FundDataMaintenance.Models
{
    public class UmbrellaEditVM
    {
        public int Id { get; set; }
        
        [ReadOnly(true)]
        public string Code { get; set; }
        
        [DisplayName("Legal Name"), ReadOnly(false)]
        [ReadOnlyAuthorize]
        public string Name { get; set; }
        
        public string Custodian { get; set; }
        
        [DisplayName("Custodian"), ReadOnly(true), UIHint("Dropdown")]
        public int? CustodianId { get; set; }
        
        public IList<SelectListItem> CustodianSelectList { get; set; }
        
        [DisplayName("Domicile Country"), ReadOnly(false), UIHint("Dropdown")]
        public int? DomicileCountryId { get; set; }

        public IList<SelectListItem> DomicileCountrySelectList { get; set; }

        [DisplayName("Vehicle Type")]
        public int? VehicleTypeId { get; set; }

        public IList<SelectListItem> VehicleTypeSelectList { get; set; }

        [DisplayName("Fiscal Year End")]
        public int? FiscalYearEndId { get; set; }

        public IList<SelectListItem> FiscalYearEndSelectList { get; set; }

        [DisplayName("File Provider")]
        public int? FileProviderId { get; set; }

        public IList<SelectListItem> FileProviderSelectList { get; set; }

        [DisplayName("Administrative Manager")]
        public int? AdminManagerId { get; set; }

        public IList<SelectListItem> AdminManagerSelectList { get; set; }

        [DisplayName("Paying Agent")]
        public int? PayingAgentId { get; set; }

        public IList<SelectListItem> PayingAgentSelectList { get; set; }

        [DisplayName("Legal Adviser")]
        public int? LegalAdviserId { get; set; }

        public IList<SelectListItem> LegalAdviserSelectList { get; set; }

        [DisplayName("Is Active?")]
        public bool Active { get; set; }

        [DisplayName("Readonly"), ReadOnly(true)]
        public bool ReadonlyActive { get { return true; } }

        [DisplayName("No. Of Active Funds")]
        public int ActiveFundCount { get; set; }
    }
}
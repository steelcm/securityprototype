using System;
using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using FundDataMaintenaceBusiness.Interfaces;
using FundDataMaintenaceBusiness.Models;
using FundDataMaintenanceData;
using FundDataMaintenanceRepository.Interfaces;

namespace FundDataMaintenaceBusiness.Services
{
    public class UmbrellaService : IUmbrellaService
    {
        private readonly IUmbrellaRepository _umbrellaRepository;
        private readonly IPartyRepository _partyRepository;
        private readonly IReferenceRepository _referenceRepository;

        public UmbrellaService(IUmbrellaRepository umbrellaRepository, IPartyRepository partyRepository, IReferenceRepository referenceRepository)
        {
            this._umbrellaRepository = umbrellaRepository;
            this._partyRepository = partyRepository;
            this._referenceRepository = referenceRepository;
        }

        public List<UmbrellaSM> GetUmbrellas()
        {
            var umbrellas = _referenceRepository.GetAll<UMBRELLA>();
            var results = umbrellas.ToList().Select(o => new UmbrellaSM{
                Id = o.UMBRELLA_ID,
                Code = o.CODE,
                Name = o.LEGAL_NAME,
                Custodian = o.PARTY_ROLE2.PARTY.NAME,
                Active = o.ACTIVE_IND.Equals("Y"),
                ActiveFundCount = o.FUNDs.Where(f => f.LAUNCH_DATE < DateTime.Today).Count()
            }).ToList();
            return results;
        }

        public UmbrellaSM GetUmbrellaById(int id)
        {
            var umbrella = _referenceRepository.GetById<UMBRELLA>(id);
            // generate base data
            var result = new UmbrellaSM
            {
                Id = umbrella.UMBRELLA_ID,
                Code = umbrella.CODE,
                Name = umbrella.LEGAL_NAME,
                Custodian = umbrella.PARTY_ROLE2.PARTY.NAME,
                CustodianId = umbrella.CUSTODIAN_ID.HasValue ? umbrella.CUSTODIAN_ID.Value : -1,
                DomicileCountryId = umbrella.DOMICILE_COUNTRY_ID.HasValue ? umbrella.DOMICILE_COUNTRY_ID.Value : -1,
                VehicleTypeId = umbrella.VEHICLE_TYPE_ID.HasValue ? umbrella.VEHICLE_TYPE_ID.Value : -1,
                FiscalYearEndId = umbrella.FISCAL_YEAR_END_ID.HasValue ? umbrella.FISCAL_YEAR_END_ID.Value : -1,
                FileProviderId = umbrella.FILE_PROVIDER_ID.HasValue ? umbrella.FILE_PROVIDER_ID.Value : -1,
                AdminManagerId = umbrella.ADMINISTRATIVE_MANAGER_ID.HasValue ? umbrella.ADMINISTRATIVE_MANAGER_ID.Value : -1,
                PayingAgentId = umbrella.PAYING_AGENT_ID.HasValue ? umbrella.PAYING_AGENT_ID.Value : -1,
                LegalAdviserId = umbrella.LEGAL_ADVISOR_ID.HasValue ? umbrella.LEGAL_ADVISOR_ID.Value : -1,
                Active = umbrella.ACTIVE_IND.Equals("Y"),
                ActiveFundCount = umbrella.FUNDs.Where(f => f.LAUNCH_DATE < DateTime.Today).Count()
            };
            // generate select lists
            result.CustodianSelectList = _partyRepository.GetPartyRoles(_partyRepository.GetPartyRoleType("CUST")).Where(o => o.PARTY_ROLE_ID.Equals(result.CustodianId) || o.ACTIVE_IND.Equals("Y")).ToList().Select(o => new SelectListItem { Value = o.PARTY_ROLE_ID.ToString(), Text = string.Concat(o.PARTY.CODE, " - ", o.PARTY.NAME), Selected = o.PARTY_ROLE_ID.Equals(result.CustodianId) }).ToList();
            result.DomicileCountrySelectList = _referenceRepository.GetAll<COUNTRY>().Where(o => o.COUNTRY_ID.Equals(result.DomicileCountryId) || o.ACTIVE_IND.Equals("Y")).ToList().Select(o => new SelectListItem { Value = o.COUNTRY_ID.ToString(), Text = string.Concat(o.ISO_CODE, " - ", o.NAME), Selected = o.COUNTRY_ID.Equals(result.DomicileCountryId) }).ToList();
            result.VehicleTypeSelectList = _referenceRepository.GetAll<VEHICLE_TYPE>().Where(o => o.VEHICLE_TYPE_ID.Equals(result.VehicleTypeId) || o.ACTIVE_IND.Equals("Y")).ToList().Select(o => new SelectListItem { Value = o.VEHICLE_TYPE_ID.ToString(), Text = string.Concat(o.CODE, " - ", o.NAME), Selected = o.VEHICLE_TYPE_ID.Equals(result.VehicleTypeId) }).ToList();
            result.FiscalYearEndSelectList = _referenceRepository.GetAll<FISCAL_YEAR_END>().Where(o => o.FISCAL_YEAR_END_ID.Equals(result.FiscalYearEndId) || o.ACTIVE_IND.Equals("Y")).ToList().Select(o => new SelectListItem { Value = o.FISCAL_YEAR_END_ID.ToString(), Text = string.Concat(o.CODE, " - ", o.NAME), Selected = o.FISCAL_YEAR_END_ID.Equals(result.FiscalYearEndId) }).ToList();
            result.FileProviderSelectList = _partyRepository.GetPartyRoles(_partyRepository.GetPartyRoleType("FP")).Where(o => o.PARTY_ROLE_ID.Equals(result.FileProviderId) || o.ACTIVE_IND.Equals("Y")).ToList().Select(o => new SelectListItem { Value = o.PARTY_ROLE_ID.ToString(), Text = string.Concat(o.PARTY.CODE, " - ", o.PARTY.NAME), Selected = o.PARTY_ROLE_ID.Equals(result.FileProviderId) }).ToList();
            result.AdminManagerSelectList = _partyRepository.GetPartyRoles(_partyRepository.GetPartyRoleType("AM")).Where(o => o.PARTY_ROLE_ID.Equals(result.AdminManagerId) || o.ACTIVE_IND.Equals("Y")).ToList().Select(o => new SelectListItem { Value = o.PARTY_ROLE_ID.ToString(), Text = string.Concat(o.PARTY.CODE, " - ", o.PARTY.NAME), Selected = o.PARTY_ROLE_ID.Equals(result.AdminManagerId) }).ToList();
            result.PayingAgentSelectList = _partyRepository.GetPartyRoles(_partyRepository.GetPartyRoleType("PA")).Where(o => o.PARTY_ROLE_ID.Equals(result.PayingAgentId) || o.ACTIVE_IND.Equals("Y")).ToList().Select(o => new SelectListItem { Value = o.PARTY_ROLE_ID.ToString(), Text = string.Concat(o.PARTY.CODE, " - ", o.PARTY.NAME), Selected = o.PARTY_ROLE_ID.Equals(result.PayingAgentId) }).ToList();
            result.LegalAdviserSelectList = _partyRepository.GetPartyRoles(_partyRepository.GetPartyRoleType("LA")).Where(o => o.PARTY_ROLE_ID.Equals(result.LegalAdviserId) || o.ACTIVE_IND.Equals("Y")).ToList().Select(o => new SelectListItem { Value = o.PARTY_ROLE_ID.ToString(), Text = string.Concat(o.PARTY.CODE, " - ", o.PARTY.NAME), Selected = o.PARTY_ROLE_ID.Equals(result.LegalAdviserId) }).ToList();
            return result;
        }
    }
}

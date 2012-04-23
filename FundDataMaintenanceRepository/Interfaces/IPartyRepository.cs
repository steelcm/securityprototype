using System.Collections.Generic;
using System.Linq;
using FundDataMaintenanceData;

namespace FundDataMaintenanceRepository.Interfaces
{
    public interface IPartyRepository : IRepository<PARTY>
    {
        PARTY GetParty(int id);
        IQueryable<PARTY> GetParties(PARTY_ROLE_TYPE partyRoleType);
        IQueryable<PARTY_ROLE> GetPartyRoles(PARTY_ROLE_TYPE partyRoleType);
        PARTY_ROLE_TYPE GetPartyRoleType(string partyRoleTypeCode);
    }
}
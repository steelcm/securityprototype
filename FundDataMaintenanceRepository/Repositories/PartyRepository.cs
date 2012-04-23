using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FundDataMaintenanceData;
using FundDataMaintenanceRepository.Interfaces;

namespace FundDataMaintenanceRepository.Repositories
{
    public class PartyRepository : IPartyRepository
    {
        private readonly FDAEntities _db;

        public PartyRepository(FDAEntities database)
        {
            _db = database;
        }

        #region Implementation of IRepository<PARTY>

        public IQueryable<PARTY> Entities
        {
            get { throw new NotImplementedException(); }
        }

        public PARTY New()
        {
            throw new NotImplementedException();
        }

        public void Update(PARTY entity)
        {
            throw new NotImplementedException();
        }

        public void Create(PARTY entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(PARTY entity)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IPartyRepository

        public PARTY GetParty(int id)
        {
            return _db.PARTies.Where(o => o.PARTY_ID.Equals(id)).FirstOrDefault();
        }

        public IQueryable<PARTY> GetParties(PARTY_ROLE_TYPE partyRoleType)
        {
            return _db.PARTY_ROLE.Where(o => o.PARTY_ROLE_TYPE.Equals(partyRoleType)).Select(o => o.PARTY);
        }

        public IQueryable<PARTY_ROLE> GetPartyRoles(PARTY_ROLE_TYPE partyRoleType)
        {
            return _db.PARTY_ROLE.Include("PARTY").Where(o => o.PARTY_ROLE_TYPE.PARTY_ROLE_TYPE_ID.Equals(partyRoleType.PARTY_ROLE_TYPE_ID));
        }

        public PARTY_ROLE_TYPE GetPartyRoleType(string partyRoleTypeCode)
        {
            return _db.PARTY_ROLE_TYPE.Where(o => o.CODE.Equals(partyRoleTypeCode)).FirstOrDefault();
        }

        #endregion

        #region Implementation of IDisposable

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

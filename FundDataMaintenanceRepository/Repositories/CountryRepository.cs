using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FundDataMaintenanceData;
using FundDataMaintenanceRepository.Interfaces;

namespace FundDataMaintenanceRepository.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly FDAEntities _db;

        public CountryRepository(FDAEntities database)
        {
            _db = database;
        }

        #region Implementation of ICountryRepository

        public COUNTRY GetCountry(int id)
        {
            return _db.COUNTRies.Where(o => o.COUNTRY_ID.Equals(id)).FirstOrDefault();
        }

        public IQueryable<COUNTRY> GetCountries()
        {
            return _db.COUNTRies;
        }

        #endregion

        #region Implementation of IDisposable

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IRepository<COUNTRY>

        public IQueryable<COUNTRY> Entities
        {
            get { throw new NotImplementedException(); }
        }

        public COUNTRY New()
        {
            throw new NotImplementedException();
        }

        public void Update(COUNTRY entity)
        {
            throw new NotImplementedException();
        }

        public void Create(COUNTRY entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(COUNTRY entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

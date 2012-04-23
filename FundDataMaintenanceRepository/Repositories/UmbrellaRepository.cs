using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FundDataMaintenanceData;
using FundDataMaintenanceRepository.Interfaces;

namespace FundDataMaintenanceRepository.Repositories
{
    public class UmbrellaRepository : IUmbrellaRepository
    {
        private readonly FDAEntities _db;

        //public UmbrellaRepository()
        //{
        //    _db = new FDAEntities();
        //}

        public UmbrellaRepository(FDAEntities database)
        {
            _db = database;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<UMBRELLA> Entities
        {
            get { return _db.UMBRELLAs; }
            //get { throw new NotImplementedException(); }
        }

        public UMBRELLA New()
        {
            throw new NotImplementedException();
        }

        public void Update(UMBRELLA entity)
        {
            throw new NotImplementedException();
        }

        public void Create(UMBRELLA entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(UMBRELLA entity)
        {
            throw new NotImplementedException();
        }

        public UMBRELLA GetUmbrella(int id)
        {
            return _db.UMBRELLAs.Where(o => o.UMBRELLA_ID.Equals(id)).FirstOrDefault();
        }

        public IQueryable<UMBRELLA> GetUmbrellas()
        {
            return _db.UMBRELLAs.Include("FUNDs");
        }
    }
}

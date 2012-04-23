using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FundDataMaintenanceData;

namespace FundDataMaintenanceRepository.Interfaces
{
    public interface ICountryRepository : IRepository<COUNTRY>
    {
        COUNTRY GetCountry(int id);
        IQueryable<COUNTRY> GetCountries();
    }
}

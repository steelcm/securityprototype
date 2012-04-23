using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FundDataMaintenanceData;

namespace FundDataMaintenanceRepository.Interfaces
{
    public interface IUmbrellaRepository : IRepository<UMBRELLA>
    {
        UMBRELLA GetUmbrella(int id);
        IQueryable<UMBRELLA> GetUmbrellas();
    }
}

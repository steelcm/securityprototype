using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FundDataMaintenaceBusiness.Models;
using FundDataMaintenanceRepository.Interfaces;

namespace FundDataMaintenaceBusiness.Interfaces
{
    public interface IUmbrellaService
    {
        List<UmbrellaSM> GetUmbrellas();
        UmbrellaSM GetUmbrellaById(int id);
    }
}

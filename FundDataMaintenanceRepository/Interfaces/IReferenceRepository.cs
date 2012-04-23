using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundDataMaintenanceRepository.Interfaces
{
    public abstract class IReferenceRepository
    {
        public abstract IQueryable<T> GetAll<T>();
        public abstract T GetById<T>(int id);
    }
}

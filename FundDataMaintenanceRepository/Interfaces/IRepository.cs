using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundDataMaintenanceRepository.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        IQueryable<T> Entities { get; }
        T New();
        void Update(T entity);
        void Create(T entity);
        void Delete(T entity);
    }
}

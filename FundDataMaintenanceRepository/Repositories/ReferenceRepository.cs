using System;
using System.Collections.Generic;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using FundDataMaintenanceData;
using FundDataMaintenanceRepository.Interfaces;

namespace FundDataMaintenanceRepository.Repositories
{
    public class ReferenceRepository : IReferenceRepository
    {
        private readonly FDAEntities _db;

        public ReferenceRepository()
        {
            _db = new FDAEntities();
        }

        public ReferenceRepository(FDAEntities database)
        {
            _db = database;
        }

        #region Implementation of IReferenceRepository

        public override IQueryable<T> GetAll<T>()
        {
            var type = typeof(T);
            var container = _db.MetadataWorkspace.GetEntityContainer(_db.DefaultContainerName, DataSpace.CSpace);
            var set = (from meta in container.BaseEntitySets
                       where meta.ElementType.Name == type.Name
                       select meta).First();
            var results = _db.CreateQuery<T>("[" + set.Name + "]").AsQueryable();
            return results;
        }

        public override T GetById<T>(int id)
        {
            var type = typeof(T);

            // x
            ParameterExpression argument = Expression.Parameter(type, "x");
            Expression expression = argument;

            // x.Id == id
            expression = Expression.Property(expression, GetKeyPropertyInfo(type));
            var valueExpression = Expression.Constant(id);
            expression = Expression.Equal(expression, valueExpression);

            // x => x.Id == id
            var lamda = Expression.Lambda<Func<T, bool>>(expression, argument);

            var container = _db.MetadataWorkspace.GetEntityContainer(_db.DefaultContainerName, DataSpace.CSpace);
            var set = (from meta in container.BaseEntitySets
                       where meta.ElementType.Name == type.Name
                       select meta).First();
            var result = _db.CreateQuery<T>("[" + set.Name + "]").AsQueryable().FirstOrDefault(lamda);
            return result;
        }

        #endregion

        public PropertyInfo GetKeyPropertyInfo(Type type)
        {
            var properties = type.GetProperties();
            foreach (var propertyInfo in properties)
            {
                var attributes = propertyInfo.GetCustomAttributes(true);
                if (attributes.Any(attribute => attribute is EdmScalarPropertyAttribute && ((EdmScalarPropertyAttribute)attribute).EntityKeyProperty))
                {
                    return propertyInfo;
                }
            }
            throw new ApplicationException(String.Format("No key property found for type {0}", type.Name));
        }

    }
}

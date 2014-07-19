using System;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;
using Database.Entities;

namespace Database
{
    public abstract class RepositoryBase<T, DbT> : IRepository<T>
        where T : Entity
        where DbT : class, IDbEntity, new()
    {
        protected readonly DbDataContext context = new DbDataContext(ConfigurationManager.ConnectionStrings["KitchenConnectionString"].ConnectionString);

        public IQueryable<T> GetAll()
        {
            return GetTable().Select(GetConverter());
        }

        public bool Save(T entity)
        {
            DbT dbEntity;

            if (entity.IsNew())
            {
                dbEntity = new DbT();
            }
            else
            {
                dbEntity = GetTable().SingleOrDefault(x => x.Id == entity.Id);
                if (dbEntity == null)
                {
                    return false;
                }
            }

            UpdateEntry(dbEntity, entity);

            if (entity.IsNew())
            {
                GetTable().InsertOnSubmit(dbEntity);
            }

            context.SubmitChanges();

            entity.Id = dbEntity.Id;
            return true;
        }

        public bool Delete(int id)
        {
            var dbEntity = GetTable().SingleOrDefault(x => x.Id == id);

            if (dbEntity == null)
            {
                return false;
            }

            GetTable().DeleteOnSubmit(dbEntity);

            context.SubmitChanges();
            return true;
        }

        public bool Delete(T entity)
        {
            return Delete(entity.Id);
        }

        protected abstract Table<DbT> GetTable();
        protected abstract Expression<Func<DbT, T>> GetConverter();
        protected abstract void UpdateEntry(DbT dbEntity, T entity);
    }
}

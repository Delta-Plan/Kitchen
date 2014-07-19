using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using common.Logging;
using common.Singleton;
using Database.Abstracts;

namespace Database.Accessors
{
    public class BaseAccessor<T> : SingletonBase<BaseAccessor<T>> where T : class, IBaseEntity
    {
        protected ILogger DefaultLogger = NLogWrapper.GetNLogWrapper();
        //Todo DeltaPlan: logger frome method
        public virtual T SelectById(int Id)
        {
            DataContext a = KitchenDataContext.CreateInstance(null,
                ConnectionStringHelper.GetConString(DefaultLogger));
            a.ExecuteQuery<T>("select top 1 * from Recipe where Id=@p0", Id);
            throw new NotImplementedException();
        }

        public List<T> SelectAll()//типа сдёрни всё 1оо5оо записей с базы?
        {
            var logger = DefaultLogger;
            var conStr = ConnectionStringHelper.GetConString(logger);
            var db = KitchenDataContext.CreateInstance(logger, conStr);
            return db.GetTable<T>().ToList();
        }

        public void Insert(T entity)
        {
            Insert(DefaultLogger, entity);
        }

        public void Insert(ILogger logger, T entity)
        {
            // todo I.Shlykov
        }

        public void Delete(T entity)
        {
            Delete(DefaultLogger, entity);
        }

        public void Delete(ILogger logger, T entity)
        {
            // todo I.Shlykov
        }

        public void Update(T entity)
        {
            Update(DefaultLogger, entity);
        }

        public void Update(ILogger logger, T entity)
        {
            if(entity.Id == 0)
                logger.Warn(String.Format("Попфтка обновления несуществующей сущности типа: '{0}'", typeof(T)));
            
            // todo I.Shlykov
        }
    }
}

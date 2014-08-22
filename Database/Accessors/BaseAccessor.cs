using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using common.Logging;
using common.Settings;
using common.Singleton;
using Database.Abstracts;

namespace Database.Accessors
{
    public abstract class BaseAccessor<T> where T : class, IBaseEntity 
    {
        protected ILogger DefaultLogger = NLogWrapper.GetNLogWrapper();

        public virtual T SelectById(int id)
        {
            DataContext a = KitchenDataContext.CreateInstance(null,
                SettingsManager.Instance.GetSettingByKey("ConnectionString").ToString());
            return a.GetTable<T>().Single(_ => _.Id == id);
        }

        public IQueryable<T> SelectAll()
        {
            var logger = DefaultLogger;
            var conStr = SettingsManager.Instance.GetSettingByKey("ConnectionString").ToString();
            var db = KitchenDataContext.CreateInstance(logger, conStr);
            return db.GetTable<T>();
        }

        public void Insert(T entity)
        {
            DataContext a = KitchenDataContext.CreateInstance(DefaultLogger,
                SettingsManager.Instance.GetSettingByKey("ConnectionString").ToString());
            var recipe = a.GetTable<T>();
            recipe.InsertOnSubmit(entity);
            try
            {
                a.SubmitChanges();
            }
            catch (Exception ex)
            {
                DefaultLogger.Error(String.Format("Не удалось записать сущность в базу. {0}", ex.Message));
            }
        }

        public void Delete(T entity)
        {
            DataContext a = KitchenDataContext.CreateInstance(DefaultLogger,
                SettingsManager.Instance.GetSettingByKey("ConnectionString").ToString());
            a.GetTable<T>().DeleteOnSubmit(entity);
            try
            {
                a.SubmitChanges();
            }
            catch (Exception ex)
            {
                DefaultLogger.Error(String.Format("Не удалось удалить сущность из базы. {0}", ex.Message));
            }
        }

        public void Update(T entity)
        {
            if(entity.Id == 0)
                DefaultLogger.Warn(String.Format("Попsтка обновления несуществующей сущности типа: '{0}'", typeof(T)));
            
            // todo I.Shlykov
        }
    }
}

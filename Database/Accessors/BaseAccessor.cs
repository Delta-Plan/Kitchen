using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using common.Logging;
using common.Settings;
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
            return a.GetTable<T>().Single(_ => _.Id == id);//S.Rozhin this code not work because Id field has no mapping to SQL
        }

        protected IEnumerable<T> ExecuteQuery(string query, params object[] parameters)
        {
            var conStr = SettingsManager.Instance.GetSettingByKey("ConnectionString").ToString();
            var logger = DefaultLogger;
            using (var dc = KitchenDataContext.CreateInstance(logger, conStr))
            {
                return dc.ExecuteQuery<T>(query,parameters);
            }
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
            using (var a = KitchenDataContext.CreateInstance(DefaultLogger, SettingsManager.Instance.GetSettingByKey("ConnectionString").ToString()))
            {
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
        }

        public void Delete(T entity)
        {
            using (var a = KitchenDataContext.CreateInstance(DefaultLogger, SettingsManager.Instance.GetSettingByKey("ConnectionString").ToString()))
            {
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
        }

        public void Update(T entity)
        {
            if(entity.Id == 0)
                DefaultLogger.Warn(String.Format("Попsтка обновления несуществующей сущности типа: '{0}'", typeof(T)));
            
            // todo I.Shlykov
        }
    }
}

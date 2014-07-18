using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common.Logging;
using common.Singleton;
using Database.Abstracts;

namespace Database.Accessors
{
    public class EntityAccessor<T> : SingletonBase<EntityAccessor<T>> where T : IBaseEntity
    {
        public T SelectById(int Id)
        {
            DataContext a = KitchenDataContext.CreateInstance(null,
                ConnectionStringHelper.GetConString(NLogWrapper.GetNLogWrapper()));
            a.ExecuteQuery<T>("select top 1 * from Recipe where Id=@p0", Id);
            throw new NotImplementedException();
        }

        public List<T> SelectAll()
        {
            throw new NotImplementedException();
        } 
    }
}

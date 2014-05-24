using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common.logging;

namespace Database.baseAccessors
{
    class EntityAccessor<T> where T : IBaseEntity
    {
        public T GetById(int Id)
        {
            DataContext a = null;//from singleton
            a.ExecuteQuery<T>("select top 1 * from Recipe where Id=@p0", Id);
            throw new NotImplementedException();
        }
    }

    public interface IBaseEntity//todo S.rozhin check for internal
    {
        int OwnerId { get;}
        bool Save(DataContext dc, int userId, ILogger log, bool doSubmit = false);
        bool Delete(DataContext dc, int userId, ILogger log, bool doSubmit = false);


    }
}

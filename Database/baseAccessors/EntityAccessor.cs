using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.baseAccessors
{
    class EntityAccessor<T> where T : BaseEntity
    {
        public T GetById(int Id)
        {
            DataContext a = null;//from singleton
            a.ExecuteQuery<T>("select top 1 * from Recipe where Id=@p0", Id);
            throw new NotImplementedException();
        }
    }

    public class BaseEntity//todo S.rozhin check for internal
    {
        public int Id { get; protected set; }

    
    
    }
}

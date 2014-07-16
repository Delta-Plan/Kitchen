using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common.logging;

namespace Database.Accessors
{
    class EntityAccessor<T> where T : IBaseEntity
    {
        public T GetById(int Id)
        {
            DataContext a = KitchenDataContext.CreateInstance(null, ConnectionStringHelper.GetConString());//from singleton
            a.ExecuteQuery<T>("select top 1 * from Recipe where Id=@p0", Id);
            throw new NotImplementedException();
        }
    }

    public interface IBaseEntity//todo S.rozhin check for internal
    {
        int Id { get;}
        bool Save(DataContext dc, int userId, ILogger log, bool doSubmit = false);
        bool Delete(DataContext dc, int userId, ILogger log, bool doSubmit = false);
    }

    public abstract class BaseEntity<T> : IBaseEntity where T : class
    {
        [Column(IsPrimaryKey = true, Name = "Id", IsDbGenerated = true)]
        protected int _id;
        
        [Column(Name = "Deleted")]
        private bool _isDeleted;

        protected abstract T GetRef();
        public int Id {get { return _id; } }
        
        [Obsolete("будет унесено в аксессоры")]
        public bool Save(DataContext dc, int userId, ILogger log, bool doSubmit = false)
        {
            var table = dc.GetTable<T>();
            //todo existing entity check
            table.InsertOnSubmit(GetRef());
            if (doSubmit)
            {
                dc.SubmitChanges(ConflictMode.FailOnFirstConflict);
            }
            return true;
        }

        [Obsolete("будет унесено в аксессоры")]
        public bool Delete(DataContext dc, int userId, ILogger log, bool doSubmit = false)
        {
            _isDeleted = true;
            if (doSubmit)
            {
                dc.SubmitChanges();
            }
            return true;
        }
    }
}

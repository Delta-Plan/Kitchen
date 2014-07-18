using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using common.Logging;

namespace Database.Abstracts
{
    public abstract class BaseEntity<T> : IBaseEntity where T : class
    {
        [Column(IsPrimaryKey = true, Name = "Id", IsDbGenerated = true)]
        protected int _id;
        
        [Column(Name = "Deleted")]
        private bool _isDeleted;

        public int Id {get { return _id; } }

        public bool IsDeleted
        {
            get { return _isDeleted; }
        }

        protected abstract T GetRef();

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
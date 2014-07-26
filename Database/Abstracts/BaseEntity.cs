using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using common.Logging;

namespace Database.Abstracts
{
    [InheritanceMapping(Type = typeof(BaseRecipe), IsDefault = false, Code = 0)]
    public abstract class BaseEntity<T> : IBaseEntity where T : class
    {
        [Column(IsPrimaryKey = true, Name = "Id", IsDbGenerated = true)]
        protected int _id;
        
        //[Column(Name = "IsDeleted")]
        //private bool _isDeleted;

        public int Id {get { return _id; } private set { _id = value; } }

        //public bool IsDeleted
        //{
        //    get { return _isDeleted; }
        //}

    }
}
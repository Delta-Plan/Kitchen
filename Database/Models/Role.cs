using System.Data.Linq.Mapping;
using Database.Abstracts;

namespace Database
{
    [Table(Name = "Roles")]
    public class Role : IBaseEntity
    {
        protected int _id;

        [Column(Storage = "_id", AutoSync = AutoSync.OnInsert, IsPrimaryKey = true)] 
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [Column] 
        public string Name;

        [Column] 
        public string Description;
    }
}

using System.Data.Linq.Mapping;
using Database.Abstracts;

namespace Database.Models
{
    [Table(Name="Users")]
    public class User : IBaseEntity
    {
        protected int _id;

        [Column(Storage = "_id", AutoSync = AutoSync.OnInsert, IsPrimaryKey = true, IsDbGenerated = true)] 
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [Column] 
        public string Name;

        [Column]
        public int RoleId;
    }
}

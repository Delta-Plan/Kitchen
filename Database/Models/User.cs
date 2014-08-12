using System.Data.Linq.Mapping;
using Database.Abstracts;

namespace Database.Models
{
    [Table(Name="Users")]
    public class User : IBaseEntity
    {
        [Column(IsPrimaryKey = true)] 
        protected int _id;

        public int Id
        {
            get { return _id; }
        }

        [Column] public string Name;

        [Column] public int RoleId;
    }
}

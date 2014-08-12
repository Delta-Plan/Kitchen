using System.Data.Linq.Mapping;
using Database.Abstracts;

namespace Database
{
    [Table(Name = "Roles")]
    public class Role : IBaseEntity
    {
        [Column(IsPrimaryKey = true)] 
        protected int _id;

        public int Id
        {
            get { return _id; }
        }

        [Column] 
        public string Name;

        [Column] 
        public string Description;
    }
}

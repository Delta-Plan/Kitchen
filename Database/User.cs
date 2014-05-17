using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace Database
{
    [Table(Name="Users")]
    public class User
    {
        [Column(IsPrimaryKey = true)] public int Id;

        [Column] public string Name;

        [Column] public int RoleId;
    }
}

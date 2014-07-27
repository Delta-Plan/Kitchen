using System.Data.Linq.Mapping;

namespace Database.Models
{
    [Table(Name="Users")]
    public class User
    {
        [Column(IsPrimaryKey = true)] public int Id;

        [Column] public string Name;

        [Column] public int RoleId;
    }
}

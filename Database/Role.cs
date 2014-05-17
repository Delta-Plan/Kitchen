using System.Data.Linq.Mapping;

namespace Database
{
    [Table(Name = "Roles")]
    public class Role
    {
        [Column(IsPrimaryKey = true)] public int Id;

        [Column] public string ShortName;

        [Column] public string Desctiption;
    }
}

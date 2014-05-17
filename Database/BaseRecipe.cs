
using System.Data.Linq.Mapping;

namespace Database
{
    [Table(Name = "Recipes")]
    public abstract class BaseRecipe
    {
        [Column(IsPrimaryKey = true)] public int Id;

        [Column] public string Name;

        [Column] public string Description;
    }
}
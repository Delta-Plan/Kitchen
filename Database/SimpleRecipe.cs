
using System.Data.Linq.Mapping;

namespace Database
{
    [Table(Name="dbo.Recipes")]
    public class SimpleRecipe : BaseRecipe
    {
        public SimpleRecipe()
        {
            this.IsPublic = true;
        }
    }
}
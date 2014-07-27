using System.Data.Linq.Mapping;

namespace Database
{
    [InheritanceMapping(Type = typeof(BaseRecipe), IsDefault = false)]
    [Table(Name = "dbo.Recipes")]
    public class SimpleRecipe : BaseRecipe
    {
        public SimpleRecipe()
        {
            this.IsPublic = true;
        }
        //[Column(IsDiscriminator = true, Name = "Disctiminator")]
        //public int? RecipeType { get; set; }
    }
}
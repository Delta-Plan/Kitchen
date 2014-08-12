using System.Data.Linq.Mapping;

namespace Database
{
    //[InheritanceMapping(Type = typeof(SimpleRecipe), IsDefault = false, Code = 2)]
    //[Table(Name = "dbo.Recipes")]
    public class SimpleRecipe : BaseRecipe // todo пока не придумал, ак из одной таблицы получать разные объекты
    {
        public SimpleRecipe()
            : base()
        {
            this.IsPublic = true;
            this.Description = "простое описалово";
        }
        //[Column(IsDiscriminator = true, Name = "Disctiminator")]
        //public int? RecipeType { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class RecipeRepository : RepositoryBase<Recipe, Entities.Recipe>
    {
        protected override Table<Entities.Recipe> GetTable()
        {
            return context.Recipes;
        }

        protected override Expression<Func<Entities.Recipe, Recipe>> GetConverter()
        {
            return c => new Recipe
            {
                Id = c.Id,
                Name = c.Name,
                Reagents = JSONConvertHelper.FromJSONString<ReagentWrap>(c.Reagents),
                Description = c.Description
            };
        }

        protected override void UpdateEntry(Entities.Recipe dbRecipe, Recipe recipe)
        {
            dbRecipe.Name = recipe.Name;
            dbRecipe.Reagents = recipe.Reagents.ToJSONString();
            dbRecipe.Description = recipe.Description;
        }
    }
}

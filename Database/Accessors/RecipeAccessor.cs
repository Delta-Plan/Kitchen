using System.Collections.Generic;
using common.Logging;
using Database.Ingredients;

namespace Database.Accessors
{
    public class RecipeAccessor : BaseAccessor<BaseRecipe>
    {
        public override BaseRecipe SelectById(int id)
        {
            //logger.Info(string.Format("Started RecipeReader.GetRecipie. RecipieId: {0}", recipieId));
            return TestRecipe;
        }

        public IList<BaseRecipe> LastUpdated(int count)
        {
            var list = new List<BaseRecipe>(count);
            for (int c = 0; c < count; c++)
            {
                list.Add(TestRecipe);
            }
            return list;
        }

        private static readonly SimpleRecipe TestRecipe = new SimpleRecipe()
        {
            Description = "Чёрный хлеб пропитать подсолнечным маслом, затем посолить. Сверху потереть пальчиком. Добавить перец по вкусу.",
            Name = "Чёрный хлебушек с маслом",
            Ingridients = new RecipieIngridients()
                {
                    Components = new List<Component>()
                        {
                            new Component() { Ammount = 1,
                                ProductType = new ProductType()
                                    {
                                        Description = "Румяный, с хрустящей корочкой..", Name = "Чёрный хлеб"
                                    },
                                    Measurement = MeasureType.Item }
                        }
                }
        };
    }
}
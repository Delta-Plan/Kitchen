using System.Collections.Generic;
using common.Logging;
using Database.Ingredients;

namespace Database.Accessors
{
    public class RecipeAccessor : BaseAccessor<BaseRecipe>
    {
        public static BaseRecipe GetRecipie(int recipieId, ILogger logger)
        {
            logger.Info(string.Format("Started RecipeReader.GetRecipie. RecipieId: {0}", recipieId));
            return TestRecipe;
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
                                Ingridient = new Ingridient()
                                    {
                                        Description = "Румяный, с хрустящей корочкой..", Name = "Чёрный хлеб"
                                    },
                                    Measurement = MeasureType.Item }
                        }
                }
        };
    }
}
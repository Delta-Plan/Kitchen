using System.Collections.Generic;
using common.Logging;
using Database.Abstracts;
using Database.Ingredients;

namespace Database.Accessors
{
    public class RecipeAccessor<T> : BaseAccessor<RecipeAccessor<T>, T> where T : class, IBaseEntity
    {
        protected  RecipeAccessor()
        {
            
        }

        public override T SelectById(int id)
        {
            return base.SelectById(id);
            //logger.Info(string.Format("Started RecipeReader.GetRecipie. RecipieId: {0}", recipieId));
            //return TestRecipe;
        }

        public IList<T> LastUpdated(int count)
        {
            var list = new List<T>(count);
            for (int c = 0; c < count; c++)
            {
                //list.Add(TestRecipe);
                //todo что-нибудь...
            }
            return list;
        }

        //private static readonly SimpleRecipe TestRecipe = new SimpleRecipe()
        //{
        //    Description = "Чёрный хлеб пропитать подсолнечным маслом, затем посолить. Сверху потереть пальчиком. Добавить перец по вкусу.",
        //    Name = "Чёрный хлебушек с маслом",
        //    Ingridients = new RecipieIngridients()
        //        {
        //            Components = new List<Component>()
        //                {
        //                    new Component() { Ammount = 1,
        //                        ProductType = new ProductType()
        //                            {
        //                                Description = "Румяный, с хрустящей корочкой..", Name = "Чёрный хлеб"
        //                            },
        //                            Measurement = MeasureType.Item }
        //                }
        //        }
        //};
    }
}
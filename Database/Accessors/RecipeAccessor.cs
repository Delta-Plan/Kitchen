using System.Collections.Generic;
using Database.Models;
using common.Logging;
using common.Singleton;
using Database.Abstracts;
using Database.Ingredients;

namespace Database.Accessors
{
    public class RecipeAccessor : BaseAccessor<BaseRecipe>
    {
        #region Singleton
        private static object _sync = new object();
        private static RecipeAccessor _instance;
        public static RecipeAccessor Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_sync)
                        if(_instance== null)
                            _instance = new RecipeAccessor();
                }
                return _instance;
            }
        }
        #endregion

        public override BaseRecipe SelectById(int id)
        {
            return base.SelectById(id);
            //logger.Info(string.Format("Started RecipeReader.GetRecipie. RecipieId: {0}", recipieId));
            //return TestRecipe;
        }

        public IList<BaseRecipe> LastUpdated(int count)
        {
            var list = new List<BaseRecipe>(count);
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
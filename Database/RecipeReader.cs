using common.logging;

namespace Database
{
    public class RecipeReader
    {
        public static BaseRecipe GetRecipie(int recipieId, ILogger logger)
        {
            logger.Info(string.Format("Started RecipeReader.GetRecipie. RecipieId: {0}", recipieId));
            return TestRecipe;
        }
        private static readonly SimpleRecipe TestRecipe = new SimpleRecipe()
        {
            Description = "Description",
            Name = "Name"
        };
    }
}
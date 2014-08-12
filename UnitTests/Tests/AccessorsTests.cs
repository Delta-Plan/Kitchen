using System.Linq;
using common.Logging;
using common.Settings;
using Database;
using Database.Accessors;
using NUnit.Framework;

namespace UnitTests.Tests
{
    [TestFixture]
    public class AccessorsTests : BaseTest
    {
        private int TestUserId;
        private ILogger Logger = NLogWrapper.GetNLogWrapper();

        [Test]
        public void SetupTest()
        {
            var dataContext = KitchenDataContext.CreateInstance(Logger, SettingsManager.Instance.GetSettingByKey("ConnectionString").ToString());
            var roles = dataContext.GetTable<Role>().ToList();
            Assert.True(roles.Count > 0);
        }

        [Test]
        public void RecipeAccessorTest()
        {
            var recipe = new BaseRecipe{Name = "чорный хлеб"};
            RecipeAccessor.Instance.Insert(recipe);
            var recipes = RecipeAccessor.Instance.SelectAll().ToList();
            Assert.True(recipes.Count > 0);
            var getted = recipes.Single(_ => _.Id == recipe.Id);
            Assert.NotNull(getted);
            Assert.True(getted.GetType() == typeof (BaseRecipe));
            //
            //
            RecipeAccessor.Instance.Delete(getted);
            recipes = RecipeAccessor.Instance.SelectAll().ToList();
            Assert.False(recipes.Any(_ => _.Id == recipe.Id));
        }

    }
}

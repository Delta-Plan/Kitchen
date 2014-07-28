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
            RecipeAccessor<BaseRecipe>.Instance.Insert(recipe);
            var simpleRecipe = new SimpleRecipe {Name = "очень чорный хлеп"};
            RecipeAccessor<SimpleRecipe>.Instance.Insert(simpleRecipe);
            var r = RecipeAccessor<BaseRecipe>.Instance.SelectAll().ToList();
            Assert.True(r.Count > 0);
            var getted = r.Single(_ => _.Name.Equals(recipe.Name));
            Assert.NotNull(getted);
            Assert.True(getted.GetType() == typeof (BaseRecipe));
            //
            var r2 = RecipeAccessor<SimpleRecipe>.Instance.SelectAll();
            var simpleGetted = r2.Single(_ => _.Name.Equals(simpleRecipe.Name));
            Assert.NotNull(simpleGetted);
            Assert.True(simpleGetted.GetType() == typeof(SimpleRecipe));
            //
            RecipeAccessor<BaseRecipe>.Instance.Delete(getted);
            r = RecipeAccessor<BaseRecipe>.Instance.SelectAll().ToList();
            Assert.False(r.Any(_ => _.Name.Equals(recipe.Name)));
            //
            RecipeAccessor<SimpleRecipe>.Instance.Delete(simpleGetted);
            r2 = RecipeAccessor<SimpleRecipe>.Instance.SelectAll();
            Assert.False(r2.Any(_ => _.Name.Equals(simpleRecipe.Name)));
        }

    }
}

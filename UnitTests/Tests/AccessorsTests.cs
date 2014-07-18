using System.Linq;
using common.Logging;
using Database;
using Database.Accessors;
using NUnit.Framework;

namespace UnitTests.Tests
{
    [TestFixture]
    public class AccessorsTests
    {
        private int TestUserId;
        private ILogger Logger;

        [SetUp]
        public void CommonSetUp()
        {
            Logger = NLogWrapper.GetNLogWrapper();
        }

        [TearDown]
        public void CommonTearDown()
        {
            
        }

        [Test]
        public void SetupTest()
        {
            var dataContext = KitchenDataContext.CreateInstance(Logger, ConnectionStringHelper.GetConString(Logger, "Ivan_db"));
            var roles = dataContext.GetTable<Role>().ToList();
            Assert.True(roles.Count > 0);
        }

        [Test]
        public void RecipeAccessorTest()
        {
            var ra = RecipeAccessor.Instance;
            // todo I.Shlykov
        }

    }
}

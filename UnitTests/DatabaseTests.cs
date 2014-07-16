using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using common.logging;
using Database;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class DatabaseTests
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
            var dataContext = KitchenDataContext.CreateInstance(Logger, ConnectionStringHelper.GetConString("Ivan_db"));
            var roles = dataContext.GetTable<Role>().ToList();
            Assert.True(roles.Count > 0);
        }
    }
}

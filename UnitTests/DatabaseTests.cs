using System.Configuration;
using System.Data.Linq;
using System.Linq;
using Database;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class DatabaseTests
    {
        private int TestUserId;

        [SetUp]
        public void CommonSetUp()
        {
            using (var dc = new DataContext(GetConnectionString("Ivan_db")))
            {
                var users = dc.GetTable<User>();
                var u = new User();
                u.Name = "TestUser";
                u.RoleId = 0;
                users.InsertOnSubmit(u);
                TestUserId = u.Id;
                dc.SubmitChanges();
            }
        }

        [TearDown]
        public void CommonTearDown()
        {
            using (var dc = new DataContext(GetConnectionString("Ivan_db")))
            {
                var users = dc.GetTable<User>();
                var u = users.SingleOrDefault(_ => _.Id == TestUserId);
                users.DeleteOnSubmit(u);
                dc.SubmitChanges();
            }
        }

        [Test]
        public void SetupTest()
        {
            using (var dc = new DataContext(GetConnectionString("Ivan_db")))
            {
                var users = dc.GetTable<User>();
                var u = users.SingleOrDefault(_ => _.Id == TestUserId);
                Assert.NotNull(u);
            }
        }

        private string GetConnectionString(string index)
        {
            return ConfigurationManager.ConnectionStrings[index].ConnectionString;
        }
    }
}

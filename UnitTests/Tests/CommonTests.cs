using NUnit.Framework;

namespace UnitTests.Tests
{
    [TestFixture]
    public class CommonTests
    {
        #region SetUp - TearDown
        [SetUp]
        public void CommonSetUp()
        {
            
        }

        [TearDown]
        public void CommonTearDown()
        {

        }
        #endregion

        [Test]
        public void SingletoneThreadSafeTest()
        {
            //todo I.Shlykov
        }
    }
}

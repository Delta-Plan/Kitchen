using Database;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class CommonTests
    {
        [Test]
        public void JSONConverterTest()
        {
            var reg = new Reagent {Name = "Milk", Amount = "0.5l"};
            string json = JSONConvertHelper.ToJSONString(reg);
            var R = JSONConvertHelper.FromJSONString<Reagent>(json);
            //
            Assert.AreEqual(reg.Name, R.Name);
            Assert.AreEqual(reg.Amount, R.Amount);
        }
    }
}

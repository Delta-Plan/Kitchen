using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common.Settings;
using NUnit.Framework;

namespace UnitTests.Tests
{
    [TestFixture]
    public class SettingsTest : BaseTest
    {
        [Test]
        public void XmlReadWriteTest()
        {
            ISettingsManager manager = SettingsManager.Instance;
            Assert.True(manager.GetAllKeys().Length > 0);
            Assert.True(manager.GetAllSettings().Length > 0);
            Assert.NotNull(manager.GetSettingByKey("ConnectionString"));
        }
    }
}

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
            var settings = SettingsManager.Instance.SettingsFileName;
            Assert.True(File.Exists(settings));
        }
    }
}

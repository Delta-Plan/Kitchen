using System;
using System.Configuration;
using System.Data.Linq;
using common.Logging;
using common.Settings;

namespace Database
{
    public partial class KitchenDataContext : DataContext
    {
        private static ILogger Logger;

        public static KitchenDataContext CreateInstance(ILogger logger, string connectionString)
        {
            Logger = logger;
            AssertConnectionString(ref connectionString);
            return new KitchenDataContext(connectionString);
        }

        private static void AssertConnectionString(ref string connectionString)
        {
            if (String.IsNullOrEmpty(connectionString))
            {
                Logger.Warn(String.Format("Wrong connection string: \"{0}\"", connectionString));
                connectionString = DefaultConnectionString();
            }
            //todo try to connect
        }

        private static string DefaultConnectionString()
        {
            return SettingsManager.Instance.GetSettingByKey("ConnectionString").ToString();
        }
    }
}

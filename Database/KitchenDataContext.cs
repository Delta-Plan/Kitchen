using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common.logging;
using common.Singleton;

namespace Database
{
    public class KitchenDataContext : DataContext
    {
        private static volatile KitchenDataContext _kitchenDataContext;
        private static readonly object SyncRoot = new object();
        private static ILogger Logger;

        private KitchenDataContext(string connectionString)
            :base(connectionString)
        {
            
        }

        public static KitchenDataContext CreateInstance(ILogger logger, string connectionString)
        {
            if(_kitchenDataContext == null)
                //lock (SyncRoot)
                {
                    Logger = logger;
                    if (_kitchenDataContext == null)
                    {
                        AssertConnectionString(ref connectionString);
                        _kitchenDataContext = new KitchenDataContext(connectionString);
                    }
                }
            return _kitchenDataContext;
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
            return ConfigurationManager.ConnectionStrings["KitchenConnectionString"].ConnectionString;
        }
    }
}

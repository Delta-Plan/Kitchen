using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common.logging;
using common.Singleton;

namespace Database
{
    public class KitchenDataContext : DataContext, ISingleton<KitchenDataContext>
    {
        private ILogger _logger;
        private static KitchenDataContext _kitchenDataContext;

        private static  string DefaultConnectionString
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        private KitchenDataContext(string connectionString)
            :base(connectionString)
        {

        }

        public static KitchenDataContext CreateInstance(ILogger logger)
        {
            return CreateInstance(logger, DefaultConnectionString);
        }

        public static KitchenDataContext CreateInstance(ILogger logger, string connectionString)
        {
            //_logger = logger;
            if(_kitchenDataContext == null)
                _kitchenDataContext = new KitchenDataContext(connectionString);
            return _kitchenDataContext;
        }


        KitchenDataContext ISingleton<KitchenDataContext>.CreateInstance(ILogger logger)
        {
            return CreateInstance(logger);
        }
    }
}

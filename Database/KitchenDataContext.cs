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
        private KitchenDataContext _kitchenDataContext;

        private string DefaultConnectionString
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

        public KitchenDataContext CreateInstance(ILogger logger)
        {
            CreateInstance(logger, DefaultConnectionString);
        }

        public KitchenDataContext CreateInstance(ILogger logger, string connectionString)
        {
            _logger = logger;
            if(_kitchenDataContext == null)
                _kitchenDataContext = new KitchenDataContext(connectionString);
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common.logging;

namespace common.Singleton
{
    public class GenericSingleton
    {
        public T Instance<T>(ILogger logger)
        {
            return default(T);
        }
    }
}

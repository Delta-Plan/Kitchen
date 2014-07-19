using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common.Logging;

namespace common.Singleton
{
    public interface ISingleton<out T> where T : class
    {
        T CreateInstance(ILogger logger);
    }
}

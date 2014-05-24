using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common.logging;

namespace common
{
    public interface IInitableFromString
    {
        bool InitFromString(string str, ILogger logger);
        string SerialiseToString(string str, ILogger logger);
        bool Initialized { get;}
    }
}

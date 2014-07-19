using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common.Settings
{
    public interface ISettingsManager
    {
        object GetSettingByKey(string key);
        object[] GetAllSettings();
        string[] GetAllKeys();
    }
}

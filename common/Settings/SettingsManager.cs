using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using common.Singleton;

namespace common.Settings
{
    public class SettingsManager : SingletonBase<SettingsManager>, ISettingsManager
    {
        private Dictionary<string, object> Settings;

        private SettingsManager()
        {
            Settings = new Dictionary<string, object>();
            var wrap = SettingsStock.GetSettings();
            Settings["ConnectionString"] = wrap.ConnectionString;
        }

        public object GetSettingByKey(string key)
        {
            object val;
            Settings.TryGetValue(key, out val);
            return val;
        }

        public void SetSettingByKey(string key, object o)
        {
            Settings[key] = o;
        }

        public object[] GetAllSettings()
        {
            return Settings.Values.ToArray();
        }

        public string[] GetAllKeys()
        {
            return Settings.Keys.ToArray();
        }

        public void Save()
        {
            // todo
        }
    }
}

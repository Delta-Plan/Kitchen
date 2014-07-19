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
        private const string FileNameLocal = "\\Settings\\settings.xml";

        private SettingsManager()
        {
            InitFromFile();
        }

        public string SettingsFileName
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path) + FileNameLocal;
            }
        }

        private void InitFromFile()
        {
            Settings = new Dictionary<string, object>();
            var serializer = new XmlSerializer(typeof (SettingsWrap));
            var streamReader = new StreamReader(SettingsFileName);
            streamReader.ReadToEnd();
            var config = (SettingsWrap) serializer.Deserialize(streamReader);
            //
            Settings["ConnectionString"] = config.ConnectionString;
        }

        private void SaveToFile(string file)
        {
            var config = new SettingsWrap {ConnectionString = Settings["ConnectionString"].ToString()};
            var serializer = new XmlSerializer(typeof (SettingsWrap));
            var streamWriter = new StreamWriter(SettingsFileName);
            serializer.Serialize(streamWriter, config);
        }

        public object GetSettingByKey(string key)
        {
            return Settings[key];
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
            SaveToFile(SettingsFileName);
        }
    }
}

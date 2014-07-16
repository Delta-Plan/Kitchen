using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common.Logging;

namespace Database
{
    public class ConnectionStringHelper
    {
        public static string GetConString(ILogger logger)
        {
            return GetConString(logger, "default"); // todo стоит подумать, как доставать дефолтную строку
        }

        public static string GetConString(ILogger logger, string name)
        {
            string s = ConfigurationManager.ConnectionStrings[name].ConnectionString;
            if (AssertString(s))
                return s;
            else
            {
                logger.Error(
                    String.Format(
                        "Не удалось получить валидную строку соединения.\nИдентификатор строки соединения:'{0}'.\nПолученная строка соединения: '{1}'.",
                        name, s));
                return String.Empty;
            }
        }

        public static void SetConString()
        {
            // todo Ivan
        }

        private static bool AssertString(string connectionString)
        {
            return true; //todo all O'Key
        }
    }
}

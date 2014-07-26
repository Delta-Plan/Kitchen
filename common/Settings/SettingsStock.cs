using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common.Settings
{
    public class SettingsStock
    {
        public static SettingsWrap GetSettings()
        {
            return new SettingsWrap
            {
                ConnectionString = "Data Source=r9vlblg\\SQLEXPRESS;Initial Catalog=KitchenDb;Integrated Security=True"
            };
        }
    }
}

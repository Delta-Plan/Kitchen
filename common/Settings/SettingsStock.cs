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
                //ConnectionString = "Data Source=IVAN_PC\\SQLEXPRESS;Initial Catalog=KitchenDb;Integrated Security=True"
                ConnectionString = "Data Source=R9VLBLG\\SQLEXPRESS;Initial Catalog=KitchenDb;Integrated Security=True"
            };
        }
    }
}

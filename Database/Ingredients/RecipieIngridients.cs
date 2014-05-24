using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common;
using common.logging;

namespace Database.Ingredients
{
    public class RecipieIngridients : IInitableFromString
    {
        private IList<Component> _components;
        public bool InitFromString(string str, ILogger logger)
        {
            throw new NotImplementedException();
        }

        public string SerialiseToString(string str, ILogger logger)
        {
            throw new NotImplementedException();
        }
        public RecipieIngridients(string str)
        {
            throw new NotImplementedException();
        }
        public bool Initialized { get; protected set; }
    }
}

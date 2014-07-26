using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common;
using common.Logging;

namespace Database.Ingredients
{
    public class RecipieIngridients
    {
        public IList<Component> Components;
        protected bool InitFromString(string str, ILogger logger)
        {
            throw new NotImplementedException();
        }

        public string SerialiseToJsonString()
        {
            throw new NotImplementedException();
        }
        public RecipieIngridients(){}
        public RecipieIngridients(string str)
        {
            throw new NotImplementedException();
        }
        public bool Initialized { get; protected set; }
    }
}

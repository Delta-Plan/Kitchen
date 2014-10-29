using System;
using System.Collections.Generic;
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
            return "Todo";
            //throw new NotImplementedException();
        }
        public RecipieIngridients(){}
        public RecipieIngridients(string str)
        {
            //throw new NotImplementedException();
        }
        public bool Initialized { get; protected set; }
    }
}

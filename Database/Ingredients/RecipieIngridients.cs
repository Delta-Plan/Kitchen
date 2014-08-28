using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
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
            String json = String.Empty;
            //S.Rozhin todo проверка на условия, чтобы не вылетать постоянно
            try
            {
                 json = new JavaScriptSerializer().Serialize(Components);
            }
            catch (InvalidOperationException longReciepException)
            {
                ILogger Logger = NLogWrapper.GetNLogWrapper();
                Logger.Error(String.Format("A lot of ingredients in recipe. Can't convert to JSON string from object RecipieIngridients\n{0}",
                            longReciepException.Message));
                
            }
            catch (ArgumentException longReciepException)
            {
                ILogger Logger = NLogWrapper.GetNLogWrapper();
                Logger.Error(String.Format("Limit exceeded on recursion. Can't convert to JSON string from object RecipieIngridients\n{0}",
                            longReciepException.Message));

            }

            
            return json;
            //throw new NotImplementedException();
        }
        public RecipieIngridients(){}
        public RecipieIngridients(string str)
        {

            try
            {
                var Obj = (IList<Component>) new JavaScriptSerializer().Deserialize(str, typeof(IList<Component>));
                Components = Obj; 
                Initialized = true;
            }
            catch (ArgumentException invalidIngridientsException)
            {
                this.Initialized = false;
                ILogger Logger = NLogWrapper.GetNLogWrapper();
                Logger.Error(String.Format("Invalid recipes ingredient in base. Can't convert from JSON string to object RecipieIngridients\n{0}",//S.Rozhin хорошо бы ещё понимать, где эта хрень в базе, чтобы поправить руками можно было.
                            invalidIngridientsException.Message));

            }
            
        }
        public bool Initialized { get; protected set; }
    }
}

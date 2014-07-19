using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Database.Entities;

namespace Database
{
    public class Recipe : Entity
    {
        public string Name { get; set; }
        public  ReagentWrap Reagents {get; set; }
        public string Description { get; set; }
    }

    [DataContract]
    public class ReagentWrap
    {
        [DataMember]
        public List<Reagent> List { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var reg in List)
                sb.Append(string.Format("{0} - {1} ", reg.Name, reg.Amount));
            return sb.ToString();
        }

        public string ToJSONString()
        {
            return JSONConvertHelper.ToJSONString(this);
        }
    }

    [DataContract]
    public class Reagent
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public object Amount { get; set; }
    }
}

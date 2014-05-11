using System.IO;
using System.Runtime.Serialization.Json;

namespace Database
{
    public class JSONConvertHelper
    {
        public static string ToJSONString(object o)
        {
            var stream1 = new MemoryStream();
            var ser = new DataContractJsonSerializer(o.GetType());

            ser.WriteObject(stream1, o);

            stream1.Position = 0;
            var sr = new StreamReader(stream1);

            return sr.ReadToEnd();
        }

        public static T FromJSONString<T>(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;

            var ser = new DataContractJsonSerializer(typeof(T));

            return (T)ser.ReadObject(stream);
        }
    }
}

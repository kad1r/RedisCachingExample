using Newtonsoft.Json;
using System.Linq;
using System.Text;

namespace Data.Helpers
{
    public class CacheHelper
    {
        protected virtual byte[] Serialize(object item)
        {
            var jsonString = JsonConvert.SerializeObject(item);

            return Encoding.UTF8.GetBytes(jsonString);
        }

        protected virtual T Deserialize<T>(string[] serializedObject)
        {
            if (serializedObject == null)
            {
                return default(T);
            }

            var jsonStr = new StringBuilder();

            jsonStr.Append("[");

            foreach (var item in serializedObject)
            {
                jsonStr.Append(item);

                if (item != serializedObject.LastOrDefault())
                {
                    jsonStr.Append(",");
                }
            }

            jsonStr.Append("]");

            return JsonConvert.DeserializeObject<T>(jsonStr.ToString());
        }
    }
}

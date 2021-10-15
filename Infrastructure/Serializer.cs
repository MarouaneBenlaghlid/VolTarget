using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Infrastructure
{
    public interface ISerializer<T>
    {
        string Serialize(T item);
        T Deserialize(string item);
    }

    public class Serializer<T> : ISerializer<T>
    {
        public string Serialize(T item)
        {
            return JsonConvert.SerializeObject(item);
        }

        public T Deserialize(string item)
        {
            return JsonConvert.DeserializeObject<T>(item);
        }
    }
}
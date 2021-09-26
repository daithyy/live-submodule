using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace IMIRT.SaveSystem
{
    public class BinarySerialiser : ISerialiser
    {
        public string SerialiseObject<T>(T dataObject)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            MemoryStream memoryStream = new MemoryStream();

            formatter.Serialize(memoryStream, dataObject);

            return (Convert.ToBase64String(memoryStream.GetBuffer()));
        }

        public T DeserialiseObject<T>(string dataString)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(dataString));
            
            return (T)formatter.Deserialize(memoryStream);
        }
    }
}

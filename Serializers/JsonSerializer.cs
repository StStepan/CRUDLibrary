using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_experience.Serializers
{
    public class JsonSerializer: ISerializer
    {
        //json serializer woth library methods
        public string FileExtension { get; } = ".json|*.json";

        //Simple json serialization with library functions
        public void Serialize(object[] media, string filePath)
        {
            using (StreamWriter fileStream = new StreamWriter(filePath,false))
            {
                string jsonMedia = JsonConvert.SerializeObject(media, Formatting.Indented, new JsonSerializerSettings
                { TypeNameHandling = TypeNameHandling.All, PreserveReferencesHandling = PreserveReferencesHandling.Objects });
                fileStream.Write(jsonMedia);
            }
        }

        //Simple json deserialization with library functions
        public object[] Deserialize(string filePath)
        {
            object[] media;
            using (StreamReader fileStream = new StreamReader(filePath))
            {
                string jsonMedia = fileStream.ReadToEnd();
                media = (object[])JsonConvert.DeserializeObject<object[]>(jsonMedia, new JsonSerializerSettings
                { TypeNameHandling = TypeNameHandling.All, PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            }
            return media;
        }
    }
}

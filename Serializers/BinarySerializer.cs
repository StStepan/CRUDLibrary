using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace C_sharp_experience.Serializers
{
    public class BinarySerializer: ISerializer
    {
        //classic binary serializer
        public string FileExtension { get; } = ".dat|*.dat";
        //Simple binary serialization with library functions
        public void Serialize(object[] media , string filePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, media);
            }
        }
        //Simple binary deserialization with library functions
        public object[] Deserialize(string filePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            object[] media;
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                media = (object[])formatter.Deserialize(fs);
            }
            return media;
        }

    }
}

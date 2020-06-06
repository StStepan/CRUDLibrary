using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_experience.Serializers
{
    public interface ISerializer
    {
        //general interface for working with all serializers
        void Serialize(object[] media, string filePath);
        object[] Deserialize(string filePath);
        string FileExtension { get; } 
    }
}

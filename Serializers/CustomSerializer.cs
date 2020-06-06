using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C_sharp_experience.Medium;

namespace C_sharp_experience.Serializers
{
    class CustomSerializer : ISerializer
    {
        //just serialize into text file
        public string FileExtension { get; } = ".txt|*.txt";

        //serializing all properties of the class in out object
        private string ObjectSerializer(object obj)
        {
            string result = "";
            //all properties of object
            PropertyInfo[] properties = obj.GetType().GetProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                Type propertyValueType = properties[i].GetValue(obj).GetType();
                //recursion if what we see is an object of another class
                if ((propertyValueType.IsClass) && (propertyValueType.Namespace != "System"))
                    result += ObjectSerializer(properties[i].GetValue(obj));
                else
                    result += Convert.ToString(properties[i].GetValue(obj)) + '*';
            }
            return result;
        }
        //main method for serializing
        public void Serialize(object[] media, string filePath)
        {
            using (StreamWriter fileStream = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                for (int j = 0; j < media.Length; j++)
                {
                    string result = media[j].GetType().FullName + "*";
                    result += ObjectSerializer(media[j]);
                    fileStream.WriteLine(result);
                }
            }
        }

        //separate onne word from another (separator = *)
        private string GetWord(string line, ref int posInLine)
        {
            string result = "";
            while ((line[posInLine] != '*') && (posInLine < line.Length))
            {
                result += line[posInLine];
                posInLine++;
            }
            posInLine++;
            return result;
        }

        //deserializing all properties of the class in out object
        private object ObjectDeserializer(Type valueType,string line,ref int posInLine )
        {
            object obj = Activator.CreateInstance(valueType);
            PropertyInfo[] properties;
            //all properties of object
            properties = obj.GetType().GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                Type propertyValueType = properties[i].GetValue(obj).GetType();
                //recursion if what we see is an object of another class
                if ((propertyValueType.IsClass) && (propertyValueType.Namespace != "System"))
                    properties[i].SetValue(obj, ObjectDeserializer(propertyValueType,line, ref posInLine));
                else
                    SetValueInObject(obj, properties[i], GetWord(line, ref posInLine));
            }
            return obj;
        }
        //finding the amount of objects in our serialized object
        private int GetNumObj(string filePath)
        {
            int result = 0;
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                    result++;
            }
            return result;
        }

        //Creatirng a media object from serialized file
        public void SetValueInObject(Object media, PropertyInfo propertyInfo, string value)
        {
            object obj;
            Type valueType = propertyInfo.GetValue(media).GetType();
            if (valueType.IsEnum)
                obj = Enum.Parse(valueType, value);
            else
                obj = Convert.ChangeType(value, valueType);
            propertyInfo.SetValue(media, obj);
        }

        //main method for deserialize
        public object[] Deserialize(string filePath)
        {
            int posInLine = 0;
            string line;
            object[] media = new Media[GetNumObj(filePath)];
            using (StreamReader fileStream = new StreamReader(filePath, Encoding.UTF8))
            {
                for (int i = 0; i < media.Length; i++)
                {
                    line = fileStream.ReadLine();
                    Type objType = Type.GetType(GetWord(line, ref posInLine));
                    media[i] =  ObjectDeserializer(objType, line, ref posInLine); 
                    posInLine = 0;
                }   
            }
            return media;
        }
    }
}

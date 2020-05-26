using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_experience.Attributes
{
    //Attribute class for all media forms
    class FSuitableType : Attribute
    {
        public Type[] SuitableType { get; set; }
        public FSuitableType(Type[] suitableType)
        {
            SuitableType = suitableType;
        }
        public bool CheckTypeForAvailability(Type suitableType)
        {
            for (int i = 0; i < SuitableType.Length; i++)
                if (SuitableType[i] == suitableType)
                    return true;
            return false;
        }
    }
}

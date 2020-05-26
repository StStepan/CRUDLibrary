using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_experience.Attributes
{
    class MediaType:Attribute
    {
        public string TypeName { get; set; }

        public MediaType(string typeName)
        {
            TypeName = typeName;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_experience.Attributes
{
    //class for extensions of encrypted files
    class PluginAttribute:Attribute
    {
        public string Extension { set; get; }
        public PluginAttribute(string extension)
        {
            Extension = extension;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LFSR.Attributes
{
    class PluginAttribute : Attribute
    {
        public string Extension { set; get; }
        public PluginAttribute(string extension)
        {
            Extension = extension;
        }
    }
}

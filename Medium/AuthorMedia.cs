using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_experience.Medium
{
    [Serializable]
    abstract public class AuthorMedia : Media
    {
        public string author { get; set; }
    }
}

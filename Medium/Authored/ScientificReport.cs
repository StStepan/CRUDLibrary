using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_sharp_experience.MediaElements;
using C_sharp_experience.Attributes;

namespace C_sharp_experience.Medium.Authored
{
    [Serializable]
    [MediaType("Научная работа")]
    public class ScientificReport : AuthorMedia
    {
        public Subject subject { get; set; }

    }

}

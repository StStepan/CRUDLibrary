using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_sharp_experience.MediaElements;
using C_sharp_experience.Attributes;
using C_sharp_experience.Attributes.MediaElements;
using System.Drawing;

namespace C_sharp_experience.Medium.Printed
{
    [MediaType("Журнал")]
    public class Magazine : PrintMedia
    {
        public TypeCategoryMag category { set; get; }

        public int volume { set; get; }

    }
}

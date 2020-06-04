using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_experience.Attributes.MediaElements
{
    public enum TypePereodicity
    {
        [Description("Ежедневно")]
        daily,
        [Description("Еженедельно")]
        weekly,
        [Description("Ежемесячно")]
        monthly,
        [Description("Ежеквартально")]
        quartally,
        [Description("Ежегодично")]
        yearly
    }
    [Serializable]
    public class Pereodicity
    {
        public TypePereodicity typePereodicity { get; set; }

        public Pereodicity(TypePereodicity typePereodicity)
        {
            this.typePereodicity = typePereodicity;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_experience.MediaElements
{
    public enum TypeAudience
    {
        [Description("Дети")]
        kids,
        [Description("Подростки")]
        teens,
        [Description("Молодежь")]
        youth,
        [Description("Взрослые")]
        adults,
        [Description("Пенсионеры")]
        elderly
    }
    [Serializable]
    public class Audience
    {
        public TypeAudience typeAudience { get; set; }

        public Audience(TypeAudience typeAudience)
        {
            this.typeAudience = typeAudience;
        }
    }
}

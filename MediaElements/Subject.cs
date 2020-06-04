using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_experience.MediaElements
{
    public enum TypeSubject
    {
        [Description("Фундаментальные исследования")]
        basicResearch,
        [Description("Прикладные исследования")]
        appliedScience,
        [Description("Научно-исследовательские работы")]
        researchAndDevelopment
    }
    [Serializable]
    public class Subject
    {
        public TypeSubject typeSubject { get; set; }

        public Subject(TypeSubject typeSubject)
        {
            this.typeSubject = typeSubject;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_experience.MediaElements
{

    public enum TypeCategoryMag
    {
        [Description("Религия")]
        religious,
        [Description("Дикая природа")]
        wildlife,
        [Description("Сатира")]
        satirical,
        [Description("Юмор")]
        humor,
        [Description("Мужские журналы")]
        men,
        [Description("Мода")]
        fashion,
        [Description("Женские журналы")]
        women

    }
    [Serializable]
    public class CategoryMagazine
    {
        public TypeCategoryMag typeCategoryMag { get; set; }

        public CategoryMagazine(TypeCategoryMag typeCategoryMag)
        {
            this.typeCategoryMag = typeCategoryMag;
        }
    }
}

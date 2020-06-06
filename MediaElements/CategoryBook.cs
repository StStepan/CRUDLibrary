using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_experience.MediaElements
{
    public enum TypeCategoryBook
    {
        [Description("Приключение")]
        adventure,
        [Description("Детектив")]
        detective,
        [Description("Научная фантастика")]
        scienceFiction,
        [Description("Пост-апокалипсис")]
        postApocalyptic,
        [Description("Дистопия")]
        distopia,
        [Description("Киберпанк")]
        cyberpunk,
        [Description("Фэнтези")]
        fantasy,
        [Description("Романтика")]
        romance,
        [Description("Без категории")]
        none
    }
    [Serializable]
    public class CategoryBook
    {
        public TypeCategoryBook typeCategoryBook { get; set; } = TypeCategoryBook.adventure;

        public CategoryBook(TypeCategoryBook typeCategoryBook)
        {
            this.typeCategoryBook = typeCategoryBook;
        }
    }
}

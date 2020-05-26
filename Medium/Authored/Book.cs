using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_sharp_experience.MediaElements;
using C_sharp_experience.Attributes;

namespace C_sharp_experience.Medium.Authored
{
    [MediaType("Книга")]
    public class Book:AuthorMedia
    {
        public TypeCategoryBook category { get; set; }

    }
}

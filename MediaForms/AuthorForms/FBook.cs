using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C_sharp_experience.MediaElements;
using C_sharp_experience.MediaForms;
using C_sharp_experience.Attributes;
using C_sharp_experience.Medium.Authored;

namespace C_sharp_experience.MediaForms.AuthorForms
{
    //Attribute assosiates class with form
    [FSuitableType((new Type[] { typeof(Book) }))]
    public partial class FBook : FAuthored
    {
        //Create an instance for edit/view/create
        private Book FinalBook = null;
        public FBook()
        {
            InitializeComponent();
            SetComboBCategory(comboBCategory, typeof(TypeCategoryBook));
        }

        public FBook(object media, bool readOnly)
        {
            InitializeComponent();
            SetComboBCategory(comboBCategory, typeof(TypeCategoryBook));
            SetBook((Book)media);
            if (readOnly)
            {
                SetReadOnly();
            }
        }


        public void SetComboBCategory(ComboBox cb, Type type)
        {
            if (!type.IsEnum)
            {
                throw new ArgumentException("Only Enum types can be set");
            }
            //List of pair of key and value 
            List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();
            //For each member of enum we make attributes
            foreach (int i in Enum.GetValues(type))
            {
                string name = Enum.GetName(type, i);
                string desc = name;
                FieldInfo fi = type.GetField(name);
                // Get description for enum element
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Length > 0)
                {
                    string s = attributes[0].Description;
                    if (!string.IsNullOrEmpty(s))
                    {
                        desc = s;
                    }
                }
                list.Add(new KeyValuePair<string, int>(desc, i));
            }
            //Do this for SelectedValue be an int value
            cb.DisplayMember = "Key";
            cb.ValueMember = "Value";
            cb.DataSource = list;
        }


        public void SetCategory(CategoryBook category)
        {
            comboBCategory.SelectedIndex = (int)category.typeCategoryBook;
        }

        public CategoryBook GetCategory()
        {

            TypeCategoryBook typeCategoryBook = (TypeCategoryBook)comboBCategory.SelectedIndex;
            CategoryBook categoryBook = new CategoryBook(typeCategoryBook);
            return categoryBook;
        }
        public void EditBook(Book book)
        {
            book.author = GetAuthor();
            book.Name = GetName();
            book.published = GetDatePublished();
            book.category = GetCategory();

        }

        public void SetBook(Book book)
        {
            FinalBook = book;
            SetAuthor(book.author);
            SetName(book.Name);
            SetCategory(book.category);
            SetDatePublished(book.published);
        }
        private void BSave_Click(object sender, EventArgs e)
        {
            if (FinalBook == null)
            {
                Book book = new Book();
                EditBook(book);
                MainForm.AddMedia(book);
            }
            else
                EditBook(FinalBook);
            Close();
        }
    }
}

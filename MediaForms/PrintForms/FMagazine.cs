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
using C_sharp_experience.Attributes;
using C_sharp_experience.Medium.Printed;

namespace C_sharp_experience.MediaForms.PrintForms
{
    //Attribute assosiates class with form
    [FSuitableType((new Type[] { typeof(Magazine) }))]
    public partial class FMagazine : FPrint
    {
        //Create an instance for edit/view/create
        private Magazine FinalMagazine = null;
        public FMagazine()
        {
            InitializeComponent();
            SetComboBCategory(comboBCategory, typeof(TypeCategoryMag));
        }

        public FMagazine(object media, bool readOnly)
        {
            InitializeComponent();
            SetComboBCategory(comboBCategory, typeof(TypeCategoryMag));
            SetMagazine((Magazine)media);
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

        public void SetAudience(TypeCategoryMag type)
        {
            switch (type)
            {
                case TypeCategoryMag.fashion: comboBCategory.SelectedIndex = 0; break;
                case TypeCategoryMag.humor: comboBCategory.SelectedIndex = 1; break;
                case TypeCategoryMag.men: comboBCategory.SelectedIndex = 2; break;
                case TypeCategoryMag.religious: comboBCategory.SelectedIndex = 3; break;
                case TypeCategoryMag.satirical: comboBCategory.SelectedIndex = 4; break;
                case TypeCategoryMag.wildlife: comboBCategory.SelectedIndex = 5; break;
                case TypeCategoryMag.women: comboBCategory.SelectedIndex = 6; break;
            }
        }

        public TypeCategoryMag GetAudience()
        {
            switch (comboBCategory.SelectedIndex)
            {
                case 0: return TypeCategoryMag.fashion;
                case 1: return TypeCategoryMag.humor;
                case 2: return TypeCategoryMag.men;
                case 3: return TypeCategoryMag.religious;
                case 4: return TypeCategoryMag.satirical;
                case 5: return TypeCategoryMag.wildlife;
                case 6: return TypeCategoryMag.women;
            }
            return TypeCategoryMag.fashion;
        }

        private void textBVolume_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkDigit(sender, e);//check for digit
        }

        public void SetVolume(int vol)
        {
            if (vol != 0)
            {
                textBVolume.Text = vol.ToString();
            }
            else
            {
                textBVolume.Text = "";
            }
        }
        public int GetVolume()
        {
            if (textBVolume.Text!="")
            {
                return Int32.Parse(textBVolume.Text.ToString());
            }
            else
            {
                return 0;
            }
        }

        public void SetCategory(TypeCategoryMag type)
        {
            switch (type)
            {
                case TypeCategoryMag.fashion: comboBCategory.SelectedIndex = 0; break;
                case TypeCategoryMag.humor: comboBCategory.SelectedIndex = 1; break;
                case TypeCategoryMag.men: comboBCategory.SelectedIndex = 2; break;
                case TypeCategoryMag.religious: comboBCategory.SelectedIndex = 3; break;
                case TypeCategoryMag.satirical: comboBCategory.SelectedIndex = 4; break;
                case TypeCategoryMag.wildlife: comboBCategory.SelectedIndex = 5; break;
                case TypeCategoryMag.women: comboBCategory.SelectedIndex = 6; break;

            }
        }

        public TypeCategoryMag GetCategory()
        {
            switch (comboBCategory.SelectedIndex)
            {
                case 0: return TypeCategoryMag.fashion;
                case 1: return TypeCategoryMag.humor;
                case 2: return TypeCategoryMag.men;
                case 3: return TypeCategoryMag.religious;
                case 4: return TypeCategoryMag.satirical;
                case 5: return TypeCategoryMag.wildlife;
                case 6: return TypeCategoryMag.women;
            }
            return TypeCategoryMag.fashion;
        }

        public void EditMagazine(Magazine magazine)
        {
            magazine.Name = GetName();
            magazine.published = GetDatePublished();
            magazine.category = GetCategory();
            magazine.volume = GetVolume();
            magazine.issueNum = GetIssueNum();
            magazine.pereodicity = GetPereodicity();
            magazine.sizeCirculation = GetCirculation();

        }

        public void SetMagazine(Magazine magazine)
        {
            FinalMagazine = magazine;
            SetName(magazine.Name);
            SetCategory(magazine.category);
            SetDatePublished(magazine.published);
            SetCirculation(magazine.sizeCirculation);
            SetIssueNum(magazine.issueNum);
            SetPereodicity(magazine.pereodicity);
            SetVolume(magazine.volume);
        }
        private void BSave_Click(object sender, EventArgs e)
        {
            if (FinalMagazine == null)
            {
                Magazine magazine = new Magazine();
                EditMagazine(magazine);
                MainForm.AddMedia(magazine);
            }
            else
                EditMagazine(FinalMagazine);
            Close();
        }
    }
}

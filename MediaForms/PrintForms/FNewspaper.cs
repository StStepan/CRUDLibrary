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
using C_sharp_experience.Medium;

namespace C_sharp_experience.MediaForms.PrintForms
{
    //Attribute assosiates class with form
    [FSuitableType((new Type[] { typeof(Newspaper) }))]
    public partial class FNewspaper : FPrint
    {
        
        //Create an instance for edit/view/create
        private Newspaper FinalNewspaper = null;
        public FNewspaper()
        {
            InitializeComponent();
            SetComboBAudience(comboBAudience, typeof(TypeAudience));
        }

        public FNewspaper(object media, bool readOnly)
        {
            InitializeComponent();
            SetComboBAudience(comboBAudience, typeof(TypeAudience));
            SetNewspaper((Newspaper)media);
            if (readOnly)
            {
                SetReadOnly();
            }
        }

        public void SetComboBAudience(ComboBox cb, Type type)
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

        public void SetAudience(Audience audience)
        {
            comboBAudience.SelectedIndex = (int)audience.typeAudience;
        }

        public Audience GetAudience()
        {
            TypeAudience typeAudience = (TypeAudience)comboBAudience.SelectedIndex;
            Audience audience = new Audience(typeAudience);
            return audience;
        }

        public bool GetOfficial()
        {
            return radioBOfficialTrue.Checked;
        }

        public void SetOfficial(bool official)
        {

            radioBOfficialTrue.Checked = official;

        }


        public void EditNewspaper(Newspaper newspaper)
        {
            newspaper.Name = GetName();
            newspaper.published = GetDatePublished();
            newspaper.issueNum = GetIssueNum();
            newspaper.pereodicity = GetPereodicity();
            newspaper.sizeCirculation = GetCirculation();
            newspaper.audience = GetAudience();
            newspaper.official = GetOfficial();

        }

        public void SetNewspaper(Newspaper newspaper)
        {
            FinalNewspaper = newspaper;
            SetName(newspaper.Name);
            SetDatePublished(newspaper.published);
            SetCirculation(newspaper.sizeCirculation);
            SetIssueNum(newspaper.issueNum);
            SetPereodicity(newspaper.pereodicity);
            SetAudience(newspaper.audience);
            SetOfficial(newspaper.official);

        }
        private void BSave_Click(object sender, EventArgs e)
        {
            if (FinalNewspaper == null)
            {
                Newspaper newspaper = new Newspaper();
                EditNewspaper(newspaper);
                AddMedia add = MainForm.AddMedia;
                add(newspaper);
            }
            else
                EditNewspaper(FinalNewspaper);
            Close();
            

        }
    }
}

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
using C_sharp_experience.Attributes.MediaElements;
using C_sharp_experience.MediaElements;

namespace C_sharp_experience.MediaForms
{
    public partial class FPrint : FMedia
    {

        public FPrint()
        {
            InitializeComponent();
            SetComboBPereodicity(comboBPereodicity, typeof(TypePereodicity));

        }
        public void SetComboBPereodicity(ComboBox cb, Type type)
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

        public void SetPereodicity(Pereodicity pereodicity)
        {

            comboBPereodicity.SelectedIndex = (int)pereodicity.typePereodicity;
        }

        public Pereodicity GetPereodicity()
        {
            
            TypePereodicity typePereodicity = (TypePereodicity)comboBPereodicity.SelectedIndex;
            Pereodicity pereodicity = new Pereodicity(typePereodicity);
            return pereodicity;
        }

        public void SetIssueNum(int num)
        {
            if (num != 0)
            {
                textBIssueNum.Text = num.ToString();

            }
            else
            {
                textBIssueNum.Text = "1";
            }
        }

        public int GetIssueNum()
        {
            if (textBIssueNum.Text != "")
            {
                return Int32.Parse(textBIssueNum.Text.ToString());
            }
            else
            {
                return 1;
            }
            
        }

        public void SetCirculation(int num)
        {
            if (num != 0)
            {

                textBCirculation.Text = num.ToString();

            }
            else
            {
                textBCirculation.Text = "";
            }
        }

        public int GetCirculation()
        {
            if (textBCirculation.Text != "")
            {
                return Int32.Parse(textBCirculation.Text.ToString());
            }
            else
            {
                return 1;
            }
            
        }

        public void checkDigit(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkDigit(sender, e);//check for digit
        }

        private void textBIssueNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkDigit(sender, e);//check for digit
        }


    }
}

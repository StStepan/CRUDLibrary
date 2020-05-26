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
using C_sharp_experience.Medium.Authored;
using C_sharp_experience.Attributes;

namespace C_sharp_experience.MediaForms.AuthorForms
{
    //Attribute assosiates class with form
    [FSuitableType((new Type[] { typeof(ScientificReport) }))]
    public partial class FScientificReport : FAuthored
    {
        //Create an instance for edit/view/create
        private ScientificReport FinalReport = null;
        public FScientificReport()
        {
            InitializeComponent();
            SetComboBSubject(comboBSubject, typeof(TypeSubject));
        }

        public FScientificReport(object media, bool readOnly)
        {
            InitializeComponent();
            SetComboBSubject(comboBSubject, typeof(TypeSubject));
            SetScientificReport((ScientificReport)media);
            if (readOnly)
            {
                SetReadOnly();
            }
        }

        public void SetComboBSubject(ComboBox cb, Type type)
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

        public void SetSubject(TypeSubject type)
        {
            switch (type)
            {
                case TypeSubject.appliedScience: comboBSubject.SelectedIndex = 0; break;
                case TypeSubject.basicResearch: comboBSubject.SelectedIndex = 1; break;
                case TypeSubject.researchAndDevelopment: comboBSubject.SelectedIndex = 2; break;
            }
        }

        public TypeSubject GetSubject()
        {
            switch (comboBSubject.SelectedIndex)
            {
                case 0: return TypeSubject.appliedScience;
                case 1: return TypeSubject.basicResearch;
                case 2: return TypeSubject.researchAndDevelopment;
            }
            return TypeSubject.appliedScience;
        }

        public void EditScientificReport(ScientificReport report)
        {
            report.author = GetAuthor();
            report.Name = GetName();
            report.published = GetDatePublished();
            report.subject = GetSubject();
        }

        public void SetScientificReport(ScientificReport report)
        {
            FinalReport = report;
            SetAuthor(report.author);
            SetName(report.Name);
            SetDatePublished(report.published);
            SetSubject(report.subject);
        }

        private void BSave_Click(object sender, EventArgs e)
        {

            if (FinalReport == null)
            {
                ScientificReport report = new ScientificReport();
                EditScientificReport(report);
                MainForm.AddMedia(report);
            }
            else
                EditScientificReport(FinalReport);
            Close();

        }
    }
}

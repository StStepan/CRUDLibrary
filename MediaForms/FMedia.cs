using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C_sharp_experience.Medium;

namespace C_sharp_experience.MediaForms
{
    public partial class FMedia : Form
    {
        public delegate void AddMedia(Media media);
        public FMedia()
        {
            InitializeComponent();
            datePickerPublished.MaxDate = DateTime.Today;
        }

        public void SetReadOnly()
        {
            foreach (var TextBox in Controls.OfType<TextBox>())
            {
                TextBox.ReadOnly = true;
            }
            foreach (var ComboBox in Controls.OfType<ComboBox>())
            {
                ComboBox.Enabled = false;
            }
            foreach (var RadioButton in Controls.OfType<RadioButton>())
            {
                RadioButton.Enabled = false;
            }
            foreach (var Button in Controls.OfType<Button>())
            {
                Button.Enabled = false;
            }
            foreach (var DateTimePicker in Controls.OfType<DateTimePicker>())
            {
                DateTimePicker.Enabled = false;
            }
            
        }

        public void SetName(string name)
        {
            if (name!="")
            {
                textBoxName.Text = name;
            }
            else
            {
                textBoxName.Text = "";
            }
        }

        public string GetName()
        {
            return textBoxName.Text;
        }

        public void SetDatePublished(DateTime date)
        {
            if (date.Ticks!=0)
            {
                datePickerPublished.Value = date;
            }
            else
            {
                datePickerPublished.Value = DateTime.Today;
            }
        }

        public DateTime GetDatePublished()
        {
            return datePickerPublished.Value.Date;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_sharp_experience.MediaForms
{
    public partial class FAuthored : FMedia
    {
        public FAuthored()
        {
            InitializeComponent();
        }

        public void SetAuthor(string s)
        {
            if (s!="")
            {
                textBAuthor.Text = s;
            }
            else
            {
                textBAuthor.Text = "";
            }
        }

        public string GetAuthor()
        {
            return textBAuthor.Text.ToString();
        }
    }
}

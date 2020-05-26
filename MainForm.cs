using C_sharp_experience.MediaForms.AuthorForms;
using C_sharp_experience.MediaForms.PrintForms;
using C_sharp_experience.Medium.Authored;
using C_sharp_experience.Medium.Printed;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C_sharp_experience.Attributes;
using C_sharp_experience.Medium;

namespace C_sharp_experience
{    
    public partial class MainForm : Form
    {
        //List for storing
        private readonly List<Type> MediaTypes = new List<Type>();
        private readonly List<Form> FormsList = new List<Form>();
        private static readonly List<object> MediaList = new List<object>();
        public MainForm()
        {
            
            InitializeComponent();
            this.comboBMediaSelect.SelectedIndex = 0;
            FillMediaTypes();
            FillFormsList();
            //line for forbidding column resizing
            this.listViewMedium.ColumnWidthChanging += new ColumnWidthChangingEventHandler(listViewMedium_ColumnWidthChanging);

        }

        

        public static void AddMedia(object media)
        {
            MediaList.Add(media);
        }

        //Method creates a new form to input for every selected class
        private void CreateFormForAdd(Type mediaType)
        {
            Form form = null;
            foreach (Form tmpForm in FormsList)
            {
                Type type = tmpForm.GetType();
                //Check for correct form from the FromsList
                if (Attribute.IsDefined(type, typeof(FSuitableType)))
                {
                    //Retrieve our custom attribute from received type
                    var attributeValue = Attribute.GetCustomAttribute(type, typeof(FSuitableType)) as FSuitableType;
                    //If type of the form is appropriate to media
                    if (attributeValue.CheckTypeForAvailability(mediaType))
                        form = (Form)Activator.CreateInstance(type);
                }
            }
            if (form != null)
                form.ShowDialog();
        }

        private void CreateFormForViewOrEdit(Object media, bool readMode)
        {
            Form form = null;
            foreach (Form tmpForm in FormsList)
            {
                Type type = tmpForm.GetType();
                //Check for correct form from the FromsList
                if (Attribute.IsDefined(type, typeof(FSuitableType)))
                {
                    //Retrieve our custom attribute from received type
                    var attributeValue = Attribute.GetCustomAttribute(type, typeof(FSuitableType)) as FSuitableType;
                    //If our object's type == type of form
                    if (attributeValue.CheckTypeForAvailability(media.GetType()))
                        form = (Form)Activator.CreateInstance(type, media, readMode);
                }
            }
            if (form != null)
                form.ShowDialog();
        }
        private void Add_Click(object sender, EventArgs e)
        {
            CreateFormForAdd(MediaTypes[comboBMediaSelect.SelectedIndex]);
            Redraw();
        }

        private void Redraw()
        {
            listViewMedium.Items.Clear();
            int i = 1;
            string[] str = new string[4];
            foreach (Media media in MediaList)
            {
                Type type = media.GetType();
                str[0] = i.ToString();
                i++;
                if (Attribute.IsDefined(type, typeof(MediaType)))
                {
                    var attributeValue = Attribute.GetCustomAttribute(type, typeof(MediaType)) as MediaType;
                    str[2] = attributeValue.TypeName;
                }
                else
                    str[2] = "";

                str[1] = media.Name;
                ListViewItem item = new ListViewItem(str);               
                listViewMedium.Items.Add(item);
            }

        }

        //Methods for filling base lists
        private void FillMediaTypes()
        {
            MediaTypes.Add(typeof(Newspaper));
            MediaTypes.Add(typeof(Magazine));
            MediaTypes.Add(typeof(Book));
            MediaTypes.Add(typeof(ScientificReport));
        }
        private void FillFormsList()
        {
            FormsList.Add(new FNewspaper());
            FormsList.Add(new FMagazine());
            FormsList.Add(new FBook());
            FormsList.Add(new FScientificReport());
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (listViewMedium.SelectedItems.Count == 1 && listViewMedium.SelectedIndices.Count>0)
            {
                ListView.SelectedIndexCollection indexes = listViewMedium.SelectedIndices;
                CreateFormForViewOrEdit(MediaList[indexes[0]], false);
                Redraw();
            }
            else
            {
                MessageBox.Show("А что редактировать то?");
            }

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (listViewMedium.SelectedItems.Count == 1 && listViewMedium.SelectedIndices.Count > 0)
            {
                ListView.SelectedIndexCollection indexes = listViewMedium.SelectedIndices;
                MediaList.RemoveAt(indexes[0]);
                Redraw();
            }
            else
            {
                MessageBox.Show("А что удалять то?");
            }
        }

        private void BView_Click(object sender, EventArgs e)
        {
            if (listViewMedium.SelectedItems.Count == 1 && listViewMedium.SelectedIndices.Count > 0)
            {
                ListView.SelectedIndexCollection indexes = listViewMedium.SelectedIndices;
                CreateFormForViewOrEdit(MediaList[indexes[0]], true);
                Redraw();
            }
            else
            {
                MessageBox.Show("А что просматривать то?");
            }
        }

        private void listViewMedium_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            Console.Write("Column Resizing");
            e.NewWidth = this.listViewMedium.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }
    }
}

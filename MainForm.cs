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
using C_sharp_experience.Serializers;
using System.IO;
using System.Reflection;
using C_sharp_experience.MediaForms;

namespace C_sharp_experience
{    
    public partial class MainForm : Form
    {
        //List for storing
        private readonly List<Type> MediaTypes = new List<Type>();
        private readonly List<Form> FormsList = new List<Form>();
        private static readonly List<object> MediaList = new List<object>();
        private readonly List<Type> SerializersList = new List<Type>();

        private string[] PluginList;
        public MainForm()
        {
            
            InitializeComponent();
            this.comboBMediaSelect.SelectedIndex = 0;
            this.comboBoxSerializers.SelectedIndex = 0;
            FillMediaTypes();
            FillFormsList();
            FillSerializersList();
            //line for forbidding column resizing
            this.listViewMedium.ColumnWidthChanging += new ColumnWidthChangingEventHandler(listViewMedium_ColumnWidthChanging);
            SetEncryptFiles();
            if (comboBEncryption.Items.Count != 0)
            {
                comboBEncryption.SelectedIndex = 0;
            }
        }
        //save all plugin files in List & view them in CB
        private void SetEncryptFiles()
        {
            PluginList = Directory.GetFiles(Application.StartupPath + "\\Plugins\\");
            foreach (String file in PluginList)
                comboBEncryption.Items.Add(Path.GetFileNameWithoutExtension(file));
        }

        private void FillSerializersList()
        {
            SerializersList.Add(typeof(BinarySerializer));
            SerializersList.Add(typeof(JsonSerializer));
            SerializersList.Add(typeof(CustomSerializer));
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
            {
                form.ShowDialog();                
            }
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
            {
                form.ShowDialog();                
            }
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

        //Staff connected with serialization
        private void BSaveInfo_Click(object sender, EventArgs e)
        {
            //check for any elements
            if (listViewMedium.SelectedItems.Count == 0)
                return;
            //create a storage for serializable stuff
            object[] selectedMedia = new object[listViewMedium.SelectedItems.Count];
            ListView.SelectedIndexCollection indexes = listViewMedium.SelectedIndices;
            int i = 0;
            //tranfer from our storage to the newly made
            foreach (int index in indexes)
            {
                selectedMedia[i] = MediaList[index];
                i++;
            }
            ISerializer serializer = (ISerializer)Activator.CreateInstance(SerializersList[comboBoxSerializers.SelectedIndex]);
            saveFileDialog.Filter = serializer.FileExtension;
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filePath = saveFileDialog.FileName;
            serializer.Serialize(selectedMedia, filePath);
            //end of standart serialization
            //start of the encryption
            DialogResult choice = MessageBox.Show("Зашифровать файл?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (choice == DialogResult.Yes)
            {
                if (comboBEncryption.SelectedIndex == -1)
                {
                    MessageBox.Show("Не загружены алгоритмы для шифрования.");
                    return;
                }
                //loading plugin file
                Assembly assembly = Assembly.LoadFile(PluginList[comboBEncryption.SelectedIndex]);
                //using instance of encryptionalgorithm
                object obj = assembly.CreateInstance("EncryptionAlgorithms");
                Type type = obj.GetType();
                //creating instance of Encrypt method
                MethodInfo method = type.GetMethod("Encrypt");
                //usage of encrypt method and deletion of old, non encrypted file
                method.Invoke(obj, new object[] { filePath });
                File.Delete(filePath);
            }
        }

        private void BLoadInfo_Click(object sender, EventArgs e)
        {
            object[] loadMedia;
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filePath = openFileDialog.FileName;

            try
            {
                //check for non-ciphered file
                if (GetSerializer(filePath) == null)
                    if (DeccryptingFile(ref filePath) == false)//if file is cyphered/ attempt to dicipher
                    {
                        MessageBox.Show("Не загружен алгоритм для дешифрования.");
                        return;
                    }
                //everything ok, proceed with standatr deserializing
                ISerializer serializer = GetSerializer(filePath);
                if (serializer == null)
                {
                    MessageBox.Show("Десериализация не удалась!");
                    return;
                }
                //load list of saved media
                loadMedia = serializer.Deserialize(filePath);
                foreach (Media media in loadMedia)
                    MediaList.Add(media);
                Redraw();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //method to decypher cyphered file
        private bool DeccryptingFile(ref string filePath)
        {
            string extension = Path.GetExtension(filePath);
            //attempt to dectpher with each plugin
            foreach (string pluginPath in PluginList)
            {
                //load of plugins
                Assembly assembly = Assembly.LoadFile(pluginPath);
                //usage of algorithms class
                object obj = assembly.CreateInstance("EncryptionAlgorithms");
                var attrs = Attribute.GetCustomAttributes(obj.GetType());
                //going throug all custom attributes
                foreach (var attr in attrs)
                {
                    //finding attribute with extension stored
                    if (attr.GetType().Name == typeof(PluginAttribute).Name)//comparing extension of file with extension of plugin
                        if (Convert.ToString(attr.GetType().GetProperty("Extension").GetValue(attr)) == extension)
                        {
                            //using peculiar method of decrypting
                            MethodInfo method = obj.GetType().GetMethod("Decrypt");
                            method.Invoke(obj, new object[] { filePath });
                            filePath = filePath.Substring(0, filePath.Length - extension.Length);
                            return true;
                        }
                }
            }
            return false;
        }

        //intrface for the selection of serializers
        private ISerializer GetSerializer(string filepath)
        {
            ISerializer serializer = null;
            bool flag = false;
            foreach (Type ser in SerializersList)
            {
                serializer = (ISerializer)Activator.CreateInstance(ser);
                if ((serializer.FileExtension).IndexOf(Path.GetExtension(filepath)) != -1)
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
                return serializer;
            else
                return null;
        }
    }
}

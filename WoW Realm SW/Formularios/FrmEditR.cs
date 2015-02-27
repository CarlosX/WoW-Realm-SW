using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using WoW_Realm_SW.Properties;
using WoW_Realm_SW.Controlador;

namespace WoW_Realm_SW
{
    public delegate void ReloadList();
    public partial class FrmEditR : Form
    {
        public event ReloadList Real;
        public FrmEditR(string name, string realmlist, string rpath, string wpath)
        {
            InitializeComponent();
            textBox1.Text = name;
            textBox2.Text = realmlist;
            textBox3.Text = rpath;
            textBox4.Text = wpath;

            this.name = name;
            this.realmlist = realmlist;
            this.rpath = rpath;
            this.wpath = wpath;

            button3.Visible = true;
        }

        protected void onReal()
        {
            if (Real != null)
                Real();
        }

        public FrmEditR()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opdf = new OpenFileDialog();
            opdf.Filter = "Config (.wtf)|Config.wtf";
            if (opdf.ShowDialog() == DialogResult.OK)
                textBox3.Text = opdf.FileName.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opdf = new OpenFileDialog();
            opdf.Filter = "WoW (*.exe)|*.exe";
            if (opdf.ShowDialog() == DialogResult.OK)
                textBox4.Text = opdf.FileName.ToString();
        }

        private void mephobiaButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length != 0 && textBox2.Text.Trim().Length != 0)
            {
                try
                {
                    XDocument doc = XDocument.Load(Settings.Default["xml_filename"].ToString());
                    XElement Realm = new XElement("Realm", new XElement("Name", textBox1.Text),
                        new XElement("Realmlist", textBox2.Text),
                        new XElement("rPath", textBox3.Text),
                        new XElement("wPath", textBox4.Text));
                    doc.Root.Add(Realm);
                    doc.Save(Settings.Default["xml_filename"].ToString());

                    //- Realmlist Addresses id:1
                    ConfigDao.RealmlistAddresses.Add(textBox2.Text);

                    //- Realmlist Paths id:2
                    ConfigDao.RealmlistPaths.Add(textBox3.Text);

                    //- WoW Exe Paths id:3
                    ConfigDao.WoWExePaths.Add(textBox4.Text);

                    //- Realm Names id:1
                    ConfigDao.RealmNames.Add(textBox1.Text);

                    ConfigDao.ReloadRealm();

                    onReal();
                }
                catch(Exception ex)
                {
                    // Exceptions: wrong xml structure, empty file
                    //- So we create a new xml configuration file
                    //Form1 form1 = new Form1();
                    //form1.CreateDefaultXMLConfFile();

                    //- We add new data which failed in this exception
                    XDocument doc = XDocument.Load(Settings.Default["xml_filename"].ToString());
                    XElement Realm = new XElement("Realm", new XElement("Name", textBox1.Text),
                        new XElement("Realmlist", textBox2.Text),
                        new XElement("rPath", textBox3.Text),
                        new XElement("wPath", textBox4.Text));
                    doc.Root.Add(Realm);

                    doc.Save(Settings.Default["xml_filename"].ToString());
                    MessageBox.Show("An error was ocurred while adding new data in configuration file, we recommend you to restart your application. "+ ex.ToString());
                }
            }

            this.Dispose();
            this.Close();
        }

        private void mephobiaButton2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length != 0 && textBox2.Text.Trim().Length != 0)
            {
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(Settings.Default["xml_filename"].ToString());

                    string namepath = "ServerInfo/Realm[Name='" + this.name + "']";
                    string realmlistaddress = "ServerInfo/Realm[Realmlist='" + this.realmlist + "']";
                    string realmlistpath = "ServerInfo/Realm[rPath='" + this.rpath + "']";
                    string woexepath = "ServerInfo/Realm[wPath='" + this.wpath + "']";

                    XmlNode _name = doc.SelectSingleNode(namepath);
                    XmlNode _realmlistaddress = _name.FirstChild.NextSibling;
                    XmlNode _realmlistpath = _realmlistaddress.NextSibling;
                    XmlNode _wowexepath = doc.SelectSingleNode(woexepath);

                    if (textBox1.Text != _name.FirstChild.InnerText)
                        _name.FirstChild.InnerText = textBox1.Text;

                    if (textBox2.Text != _realmlistaddress.InnerText)
                        _realmlistaddress.InnerText = textBox2.Text;

                    if (textBox3.Text != _realmlistpath.InnerText)
                        _realmlistpath.InnerText = textBox3.Text;

                    if (textBox4.Text != _wowexepath.LastChild.InnerText)
                        _wowexepath.LastChild.InnerText = textBox4.Text;

                    doc.Save(Settings.Default["xml_filename"].ToString());

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            this.Dispose();
            this.Close();
        }

        private string name;
        private string realmlist;
        private string rpath;
        private string wpath;
    }
}

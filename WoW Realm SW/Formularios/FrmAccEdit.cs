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

namespace WoW_Realm_SW
{
    public partial class FrmAccEdit : Form
    {
        public FrmAccEdit(string username, string password)
        {
            InitializeComponent();
            textBox1.Text = username;
            textBox2.Text = MyFunctions.base64Decode(password);

            this.username = username;
            this.password = MyFunctions.base64Decode(password);

            button3.Visible = true;
        }

        public FrmAccEdit()
        {
            InitializeComponent();
        }

        private void mephobiaButton1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void mephobiaButton2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length != 0 && textBox2.Text.Trim().Length != 0)
            {
                try
                {
                    XDocument doc = XDocument.Load(Settings.Default["xml_filename"].ToString());
                    XElement Realm = new XElement("Account", new XElement("Username", textBox1.Text),
                        new XElement("Password", MyFunctions.base64Encode(textBox2.Text.ToString())));
                    doc.Root.Add(Realm);
                    doc.Save(Settings.Default["xml_filename"].ToString());
                }
                catch
                {
                    // Exceptions: wrong xml structure, empty file
                    //- So we create a new xml configuration file
                    Form1 form1 = new Form1();
                    form1.CreateDefaultXMLConfFile();

                    //- We add new data which failed in this exception
                    XDocument doc = XDocument.Load(Settings.Default["xml_filename"].ToString());
                    XElement Realm = new XElement("Account", new XElement("Username", textBox1.Text),
                        new XElement("Password", MyFunctions.base64Encode(textBox2.Text.ToString())));
                    doc.Root.Add(Realm);

                    doc.Save(Settings.Default["xml_filename"].ToString());
                    MessageBox.Show("An error was ocurred while adding new data in configuration file, we recommend you to restart your application.");
                }
            }
            this.Dispose();
            this.Close();
        }

        private void mephobiaButton3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length != 0 && textBox2.Text.Trim().Length !=0)
            {
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(Settings.Default["xml_filename"].ToString());

                    string usernamePath = "ServerInfo/Account[Username='" + this.username + "']";
                    string passwordPath = "ServerInfo/Account[Password='" + this.password + "']";

                    XmlNode _username = doc.SelectSingleNode(usernamePath);
                    XmlNode _password = _username.FirstChild.NextSibling;

                    if (textBox1.Text != _username.FirstChild.InnerText)
                        _username.FirstChild.InnerText = textBox1.Text;

                    if (textBox2.Text != _username.LastChild.InnerText)
                        _password.LastChild.InnerText = MyFunctions.base64Encode(textBox2.Text.ToString());

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

        private string username;
        private string password;
    }
}

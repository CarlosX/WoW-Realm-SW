using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using WoW_Realm_SW.Properties;
using WoW_Realm_SW.Controlador;

namespace WoW_Realm_SW
{
    public partial class Form1 : Form
    {
        private const int EM_SETCUEBANNER = 0x1501; //! Used to set placeholder text

        //! Key codes to send to the client
        private const uint WM_KEYDOWN = 0x0100;
        private const uint WM_KEYUP = 0x0101;
        private const uint WM_CHAR = 0x0102;
        private const int VK_RETURN = 0x0D;
        private const int VK_TAB = 0x09;

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(Settings.Default["xml_filename"].ToString()))
            {
                if (new FileInfo(Settings.Default["xml_filename"].ToString()).Length != 0)
                {
                    ConfigDao.Load(Settings.Default["xml_filename"].ToString());
                    LoadXMLToListbox();
                    LoadXMLAccountsToComboBox();
                }
                else
                {
                    CreateDefaultXMLConfFile();
                    LoadXMLToListbox();
                    LoadXMLAccountsToComboBox();
                }
            }
            else
            {
                CreateDefaultXMLConfFile();
                LoadXMLToListbox();
                LoadXMLAccountsToComboBox();
            }
            checkBox1.Checked = Settings.Default.clear_cache;
            checkBox2.Checked = Settings.Default.auto_account_login;
        }

        public void LoadXMLAccountsToComboBox()
        {
            try
            {
                comboBox1.Items.Clear();

                // Add Accounts to comboBox1
                foreach (KeyValuePair<string, string> entry in ConfigDao.AccountsDataList)
                {
                    comboBox1.Items.Add(entry.Key);
                }

                if (ConfigDao.AccountsDataList.Count > 0)
                    comboBox1.SelectedIndex = 0;
            }
            catch
            {
            }
        }

        public void LoadXMLToListbox()
        {
            try
            {
                listBox1.Items.Clear();

                // Realmlist Addresses Data List add to listbox1
                foreach (KeyValuePair<string, string> entry in ConfigDao.RealmlistAddressDataList)
                {
                    listBox1.Items.Add(entry.Key);
                }

                if (ConfigDao.RealmlistAddressDataList.Count > 0)
                    listBox1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void CreateDefaultXMLConfFile()
        {
            try
            {
                /*
                XmlDocument xmlDoc = new XmlDocument();

                XmlNode serverInfoNode = xmlDoc.CreateElement("ServerInfo");
                xmlDoc.AppendChild(serverInfoNode);

                // Realms part
                XmlNode realmNode = xmlDoc.CreateElement("Realm");
                serverInfoNode.AppendChild(realmNode);

                XmlNode realmNameNode = xmlDoc.CreateElement("Name");
                realmNameNode.InnerText = "My Localhost Server";
                realmNode.AppendChild(realmNameNode);

                XmlNode realmlistNode = xmlDoc.CreateElement("Realmlist");
                realmlistNode.InnerText = "127.0.0.1";
                realmNode.AppendChild(realmlistNode);

                XmlNode realmlistPathNode = xmlDoc.CreateElement("rPath");
                realmlistPathNode.InnerText = "C:\\wow\\WTF\\config.wtf";
                realmNode.AppendChild(realmlistPathNode);

                XmlNode wowExePathNode = xmlDoc.CreateElement("wPath");
                wowExePathNode.InnerText = "C:\\wow\\Wow.exe";
                realmNode.AppendChild(wowExePathNode);

                // Accounts Part
                XmlNode accountNode = xmlDoc.CreateElement("Account");
                serverInfoNode.AppendChild(accountNode);

                XmlNode usernameNode = xmlDoc.CreateElement("Username");
                usernameNode.InnerText = "Test"; //- Username: Test
                accountNode.AppendChild(usernameNode);

                XmlNode passwordNode = xmlDoc.CreateElement("Password");
                passwordNode.InnerText = "VGVzdA=="; //- Password: Test
                accountNode.AppendChild(passwordNode);

                xmlDoc.Save(Settings.Default["xml_filename"].ToString());*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start(Settings.Default["author_url"].ToString());
        }

        private void mephobiaButton4_Click(object sender, EventArgs e)
        {
            try
            {
                string filesav = ConfigDao.RealmlistPathDataList[listBox1.SelectedItem.ToString()];
                string realmlist = "SET realmlist \"" + ConfigDao.RealmlistAddressDataList[listBox1.SelectedItem.ToString()] + "\"";

                string lineToWrite = null;
                List<string> dataconfig = new List<string>();
                bool found = false;
                using (StreamReader reader = new StreamReader(filesav))
                {
                    while ((lineToWrite = reader.ReadLine()) != null)
                    {
                        string[] tmp11 = lineToWrite.Split(' ');
                        if (tmp11[1].ToLower() == "realmlist")
                        {
                            dataconfig.Add(realmlist);
                            found = true;
                        }
                        else
                        {
                            dataconfig.Add(lineToWrite);
                        }
                    }
                    if (!found)
                        dataconfig.Add(realmlist);
                }

                using (StreamWriter writer = new StreamWriter(filesav))
                {
                    foreach (string dat in dataconfig)
                    {
                        writer.WriteLine(dat);
                    }
                }

                label2.Text = "Config Done!";
            }
            catch { MessageBox.Show("Invalid realmlist.wtf not found"); }

            
            try
            {
                if (Settings.Default.clear_cache)
                {
                    string MainDirectory = ConfigDao.WoWExePathDataList[listBox1.SelectedItem.ToString()];
                    string root = Path.GetDirectoryName(MainDirectory);

                    if (Directory.Exists(root + "\\Cache"))
                        Directory.Delete(root + "\\Cache", true);
                }
                string exefile = ConfigDao.WoWExePathDataList[listBox1.SelectedItem.ToString()];
                Process process = Process.Start(exefile);

                string accountName = comboBox1.Text.ToString();
                Thread.Sleep(600);

                //! Run this code in a new thread so the main form does not freeze up.
                new Thread(() =>
                {
                    if (Settings.Default.auto_account_login)
                    {
                        try
                        {
                            Thread.CurrentThread.IsBackground = true;

                            while (!process.WaitForInputIdle()) ;

                            Thread.Sleep(100);

                            foreach (char accNameLetter in accountName)
                            {
                                SendMessage(process.MainWindowHandle, WM_CHAR, new IntPtr(accNameLetter), IntPtr.Zero);
                                Thread.Sleep(5);
                            }
                            string p2 = ConfigDao.AccountsDataList[accountName];
                            string password = MyFunctions.base64Decode(p2);
                            Thread.Sleep(2);

                            SendMessage(process.MainWindowHandle, WM_KEYUP, new IntPtr(VK_TAB), IntPtr.Zero);
                            SendMessage(process.MainWindowHandle, WM_KEYDOWN, new IntPtr(VK_TAB), IntPtr.Zero);

                            foreach (char accPassLetter in password)
                            {
                                SendMessage(process.MainWindowHandle, WM_CHAR, new IntPtr(accPassLetter), IntPtr.Zero);
                                Thread.Sleep(5);
                            }

                            //! Login to account
                            SendMessage(process.MainWindowHandle, WM_KEYUP, new IntPtr(VK_RETURN), IntPtr.Zero);
                            SendMessage(process.MainWindowHandle, WM_KEYDOWN, new IntPtr(VK_RETURN), IntPtr.Zero);

                            //! Login to char (disabled atm, will be used in next feature)
                            //if (Settings.Default.LoginToChar)
                            //{
                            //    Thread.Sleep(1500);
                            //    SendMessage(process.MainWindowHandle, WM_KEYUP, new IntPtr(VK_RETURN), IntPtr.Zero);
                            //    SendMessage(process.MainWindowHandle, WM_KEYDOWN, new IntPtr(VK_RETURN), IntPtr.Zero);
                            //}

                            Thread.CurrentThread.Abort();
                        }
                        catch
                        {
                            Thread.CurrentThread.Abort();
                        }
                    }
                }).Start();
            }
            catch { MessageBox.Show("Invalid Wow.exe not found"); }

            this.WindowState = FormWindowState.Minimized;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(ConfigDao.WoWExePathDataList[listBox1.SelectedItem.ToString()]))
                {
                    PlayButton.Text = "Invalid Realm Settings";
                    PlayButton.Enabled = false;
                    return;
                }

                if (!File.Exists(ConfigDao.RealmlistPathDataList[listBox1.SelectedItem.ToString()]))
                {
                    PlayButton.Text = "Invalid Realm Settings";
                    PlayButton.Enabled = false;
                    return;
                }

                PlayButton.Text = "Let's Play";
                PlayButton.Enabled = true;
            }
            catch { }
        }

        private void mephobiaButton1_Click(object sender, EventArgs e)
        {
            FrmEditR frm = new FrmEditR();
            frm.Real += form2_Real;
            frm.ShowDialog();
        }

        private void form2_Real()
        {
            LoadXMLToListbox();
        }

        private void mephobiaButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure wanna delete?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(Settings.Default["xml_filename"].ToString());
                    string path = "ServerInfo/Realm[Name='" + listBox1.SelectedItem.ToString() + "']";
                    XmlNode node = doc.SelectSingleNode(path);
                    node.ParentNode.RemoveChild(node);
                    doc.Save(Settings.Default["xml_filename"].ToString());
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Server not selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                LoadXMLToListbox();
                listBox1.ResetText();
                listBox1.Refresh();
            }
        }

        private void checkBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Settings.Default.clear_cache = checkBox1.Checked;
            Properties.Settings.Default.Save();
        }

        private void mephobiaButton2_Click(object sender, EventArgs e)
        {
            try
            {
                FrmEditR form2 = new FrmEditR(listBox1.SelectedItem.ToString(),
                    ConfigDao.RealmlistAddressDataList[listBox1.SelectedItem.ToString()],
                    ConfigDao.RealmlistPathDataList[listBox1.SelectedItem.ToString()],
                    ConfigDao.WoWExePathDataList[listBox1.SelectedItem.ToString()]);
                form2.Real += form2_Real;
                form2.ShowDialog();
                
                /*
                LoadXMLToListbox();
                listBox1.Refresh();
                listBox1.ResetText();*/
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("No server selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mephobiaButton4_Click_1(object sender, EventArgs e)
        {
            FrmUpdate form3 = new FrmUpdate();
            form3.ShowDialog();
        }

        private void mephobiaButton5_Click(object sender, EventArgs e)
        {
            FrmAccEdit form4 = new FrmAccEdit();
            form4.ShowDialog();
            comboBox1.Items.Clear();
            LoadXMLAccountsToComboBox();
        }

        private void mephobiaButton6_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAccEdit form4 = new FrmAccEdit(comboBox1.SelectedItem.ToString(),
                    ConfigDao.AccountsDataList[comboBox1.SelectedItem.ToString()]);

                form4.ShowDialog();
                LoadXMLAccountsToComboBox();
                comboBox1.Refresh();
                comboBox1.ResetText();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("No account selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mephobiaButton7_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Settings.Default["xml_filename"].ToString());
                string path = "ServerInfo/Account[Username='" + comboBox1.SelectedItem.ToString() + "']";
                XmlNode node = doc.SelectSingleNode(path);
                node.ParentNode.RemoveChild(node);
                doc.Save(Settings.Default["xml_filename"].ToString());
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Account not selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            LoadXMLAccountsToComboBox();
            comboBox1.ResetText();
            comboBox1.Refresh();
        }

        private void checkBox2_MouseDown(object sender, MouseEventArgs e)
        {
            Settings.Default.auto_account_login = checkBox2.Checked;
            Properties.Settings.Default.Save();
        }

        private void mephobiaControlBox_TwoButtons1_Click(object sender, EventArgs e)
        {

        }
    }
}

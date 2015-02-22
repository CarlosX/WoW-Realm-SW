using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WoW_Realm_SW.Properties;

namespace WoW_Realm_SW
{
    public partial class FrmUpdate : Form
    {
        public FrmUpdate()
        {
            InitializeComponent();
        }

        private void mephobiaButton1_Click(object sender, EventArgs e)
        {
            Process.Start(Settings.Default["update_url"].ToString());
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            int webVersion = 0;
            bool webParsed = Int32.TryParse(MyFunctions.GetAppVersion(), out webVersion);
            Settings.Default.Reload();
            label2.Text = Settings.Default.app_version.ToString();

            if (webParsed)
            {
                if (webVersion > Settings.Default.app_version)
                {
                    button1.Text = "Download Latest Version: " + webVersion;
                    button1.Enabled = true;
                }
                else
                {
                    button1.Text = "Already Running Latest Version";
                    button1.Enabled = false;
                }
            }
            else
                label2.Text = "There was a problem while retrieving application version.";
        }

        private void mephobiaButton1_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}

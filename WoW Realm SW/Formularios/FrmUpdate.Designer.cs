namespace WoW_Realm_SW
{
    partial class FrmUpdate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mephobiaTheme1 = new Theme.MephobiaTheme();
            this.mephobiaButton1 = new Theme.MephobiaButton();
            this.button1 = new Theme.MephobiaButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mephobiaTheme1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mephobiaTheme1
            // 
            this.mephobiaTheme1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.mephobiaTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.mephobiaTheme1.Controls.Add(this.mephobiaButton1);
            this.mephobiaTheme1.Controls.Add(this.button1);
            this.mephobiaTheme1.Controls.Add(this.label2);
            this.mephobiaTheme1.Controls.Add(this.label1);
            this.mephobiaTheme1.Customization = "Pz8//xQUFP+qqqr/IBq0/wAAAP8=";
            this.mephobiaTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mephobiaTheme1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mephobiaTheme1.Image = null;
            this.mephobiaTheme1.Location = new System.Drawing.Point(0, 0);
            this.mephobiaTheme1.Margin = new System.Windows.Forms.Padding(2);
            this.mephobiaTheme1.Movable = true;
            this.mephobiaTheme1.Name = "mephobiaTheme1";
            this.mephobiaTheme1.NoRounding = false;
            this.mephobiaTheme1.ShowIcon = false;
            this.mephobiaTheme1.Sizable = false;
            this.mephobiaTheme1.Size = new System.Drawing.Size(244, 106);
            this.mephobiaTheme1.SmartBounds = true;
            this.mephobiaTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.mephobiaTheme1.TabIndex = 0;
            this.mephobiaTheme1.Text = "mephobiaTheme1";
            this.mephobiaTheme1.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.mephobiaTheme1.Transparent = false;
            // 
            // mephobiaButton1
            // 
            this.mephobiaButton1.Customization = "KCgo/xQUFP+qqqr/";
            this.mephobiaButton1.Font = new System.Drawing.Font("Verdana", 8F);
            this.mephobiaButton1.Image = null;
            this.mephobiaButton1.Location = new System.Drawing.Point(214, 3);
            this.mephobiaButton1.Margin = new System.Windows.Forms.Padding(2);
            this.mephobiaButton1.Name = "mephobiaButton1";
            this.mephobiaButton1.NoRounding = false;
            this.mephobiaButton1.Size = new System.Drawing.Size(25, 20);
            this.mephobiaButton1.TabIndex = 3;
            this.mephobiaButton1.Text = "X";
            this.mephobiaButton1.Transparent = false;
            this.mephobiaButton1.Click += new System.EventHandler(this.mephobiaButton1_Click_1);
            // 
            // button1
            // 
            this.button1.Customization = "KCgo/xQUFP+qqqr/";
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Verdana", 8F);
            this.button1.Image = null;
            this.button1.Location = new System.Drawing.Point(13, 63);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.NoRounding = false;
            this.button1.Size = new System.Drawing.Size(219, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "Already Running Lastest Version";
            this.button1.Transparent = false;
            this.button1.Click += new System.EventHandler(this.mephobiaButton1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(134, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Version?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "WoW Realm SW:";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 106);
            this.Controls.Add(this.mephobiaTheme1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form3";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "App Version";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.Form3_Load);
            this.mephobiaTheme1.ResumeLayout(false);
            this.mephobiaTheme1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Theme.MephobiaTheme mephobiaTheme1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Theme.MephobiaButton button1;
        private Theme.MephobiaButton mephobiaButton1;
    }
}
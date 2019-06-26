using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ReceiveMessages
{
    public partial class Toast : MetroFramework.Forms.MetroForm
    {
        public Toast() { }
        public Toast(string m,string u)
        {
            InitializeComponent();
            message.Text = m;
            url.Text = u;
        }

        private void Toast_Load(object sender, EventArgs e)
        {
            this.Top = Screen.PrimaryScreen.Bounds.Height - this.Height -70;
            this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width -20;
            this.TopMost = true;
        }

        private void url_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://"+url.Text.ToString());
            this.Close();
        }
    }
}

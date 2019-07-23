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
        static int increasingUp=0;
        string goingUrl;
        static int top = 0;

        public Toast() { }
        public Toast(string m,string u)
        {
            InitializeComponent();
            goingUrl = u;
            url.Text = m;
            top = Screen.PrimaryScreen.Bounds.Height - this.Height - 70;
        }

        private void Toast_Load(object sender, EventArgs e)
        {
            this.Top =  top- increasingUp;
            this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width -20;

            increasingUp += this.Height + 10;
            
            this.TopMost = true;
        }

        private void url_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string link = goingUrl;
            Process.Start(link);
            this.Close();
        }

        private void Toast_FormClosed(object sender, FormClosedEventArgs e)
        {
            increasingUp -= this.Height + 10;
            top = this.Top;
        }
    }
}

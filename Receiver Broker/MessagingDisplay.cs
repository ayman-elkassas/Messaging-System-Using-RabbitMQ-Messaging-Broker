using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Threading;

namespace ReceiveMessages
{
    public partial class MessagingDisplay : MetroFramework.Forms.MetroForm
    {
        //private SoundPlayer _soundPlayer = new SoundPlayer("ReceiveMessages\\bin\\Debug\\plucky.ogg");
        public MessagingDisplay() { }
        public MessagingDisplay(List<Message> messages)
        {
            InitializeComponent();
            
            displayMessages(messages);
        }

        public void displayMessages(List<Message> messages)
        {
            if (messages != null)
            {
                messages.Reverse();
                foreach (var message in messages)
                {
                    dataGridView.Rows.Add(message.message, message.url, message.type);
                }
            }
        }

        private void MessagingDisplay_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Form1.th.Abort();
        }


    }
}

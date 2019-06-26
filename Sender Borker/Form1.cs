using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sender
{
    public partial class Sender : Form
    {
        public Sender()
        {
            InitializeComponent();
        }

        private void Sender_Load(object sender, EventArgs e)
        {
            List<DB> dbs = new List<DB>();
            dbs.Add(new DB("DOCS_TO", "NOTIFICATION_DOCS_TO"));
            dbs.Add(new DB("DOCS_FROM", "NOTIFICATION_DOCS_FROM"));
            registerTables(dbs);
        }

        public static void registerTables(List<DB> dbs)
        {
            for (int i = 0; i < dbs.Count; i++)
            {
                //db.registerListenerTable(tableName);
                dbs[i].registerListenerTable();
            }
        }
    }
}

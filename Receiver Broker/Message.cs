using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiveMessages
{
    public class Message
    {
        public Message()
        {

        }

        //props
        public string message { get; set; }
        public string url { get; set; }
        //type 1 for import , 2 for export ,3 
        public string type { get; set; }
        public string REMINDER_DATE { get; set; }
        public string REMINDER_MESSAGE { get; set; }
    }
}

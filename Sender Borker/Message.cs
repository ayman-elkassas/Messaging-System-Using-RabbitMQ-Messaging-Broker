﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sender
{
    public class Message
    {
        public Message()
        {

        }

        //props
        public string message { get; set; }
        public string url { get; set; }
        //type 1 for import , 2 for export
        public string type { get; set; }
    }
}

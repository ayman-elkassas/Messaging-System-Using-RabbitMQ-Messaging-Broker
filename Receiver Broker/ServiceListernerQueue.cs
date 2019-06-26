using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//Add refs
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Microsoft.Win32;
using System.Threading;
using System.Web.Script.Serialization;
using System.Security.Principal;
using System.Net;
using System.IO;

//Notifications Toast
namespace ReceiveMessages
{
    public partial class Form1 : Form
    {
        public static List<Message> messagesObjects=new List<Message>();
        public static Thread th;
        public static MessagingDisplay messagingDisplay;
        public static Toast toast;
        bool flag = false;

        int import, export = 0;

        public Form1()
        {
            //Register on startUp run service
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            reg.SetValue("ReceiveApp", Application.ExecutablePath.ToString());

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string queueName=null;
            //****************************************
            //get queue name from active directory...........
            //http://priyanka-solutions.blogspot.com/2014/10/connect-remote-active-directory-using-c.html
            //******************************************

            //php web service to get current user national id ............
            WebRequest request = WebRequest.Create("http://192.223.1.148/command_edara/php/ldap.php?out=1");
            request.Method = "GET";
            try
            {
                    WebResponse response = request.GetResponse();

                    // Obtain a 'Stream' object associated with the response object.
                    Stream ReceiveStream = response.GetResponseStream();

                    Encoding encode = Encoding.GetEncoding("utf-8");

                    // Pipe the stream to a higher level stream reader with the required encoding format. 
                    StreamReader readStream = new StreamReader(ReceiveStream, encode);

                    Char[] read = new Char[256];

                    // Read 256 charcters at a time.    
                    int count = readStream.Read(read, 0, 256);

                    while (count > 0)
                    {
                        // Dump the 256 characters on a string and display the string onto the console.
                        String str = new String(read, 0, count);
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        QueueName[] messages = js.Deserialize<QueueName[]>(str);
                        queueName = messages[0].employeeid;
                        count = readStream.Read(read, 0, 256);
                    }

                    readStream.Close();
                    // Release the resources of response object.
                    response.Close();

                    //queue name is unique for user that is national id
                    //start listen on my queue id
                    StartReceiveLoad(queueName);
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void StartReceiveLoad(string queue_name)
        {
            //prepare my factory 
            var factory = new ConnectionFactory()
            {
                HostName = "192.223.2.200",
                UserName = "ayman",
                Password = "ayman"
            };

            //create new connection with rabbitmq...
            var connection = factory.CreateConnection();
            //create new channel...
            IModel channel = connection.CreateModel();

            //Get current queue initialized from sender that the same qualificatioins parameters...
            QueueDeclareOk result = channel.QueueDeclare(queue: queue_name,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            //fire received event when queue received new data
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                //should message get the same json format keys ("[{message:'any text',url:'192.168.1.1',type:1}]");

                JavaScriptSerializer js = new JavaScriptSerializer();
                
                Message messages = js.Deserialize<Message>(message);
                messagesObjects.Add(messages);

                //first condition : when open in chashed queue
                //second : when message send in listen time
                //third : message send after time of cashed display 

                if ((messagesObjects != null && result.MessageCount == messagesObjects.Count)
                    || result.MessageCount == 0 || flag)
                {
                    import = 0;
                    export = 0;

                    if (result.MessageCount == messagesObjects.Count)
                        flag = true;

                    foreach (var item in messagesObjects)
                    {
                        if (int.Parse(item.type) == 1)
                            import++;
                        else if (int.Parse(item.type) == 2)
                            export++;
                    }

                    if (th != null)
                        th.Abort();

                    //messagingDisplay = new MessagingDisplay(messagesObjects);
                    if (export != 0 && import != 0) { toast = new Toast("لديك " + import + " مكاتبه وارده" + " و " + export + " صادره ", messagesObjects[0].url); }
                    
                    if (import == 1 || export == 1) {
                        if (import == 1) {toast= new Toast(messagesObjects[0].message, messagesObjects[0].url); }
                        else {toast= new Toast(messagesObjects[0].message, messagesObjects[0].url); }
                    }

                    if (toast!=null)
                    {
                        th = new Thread(() => StartListen(toast));
                        th.Start();
                    }
                }
            };

            channel.BasicConsume(queue: queue_name,
                                     noAck: true,
                                     consumer: consumer);
        }

        private void StartListen(Toast toast)
        {
            //for doesnot cashe previous data
            messagesObjects.Clear();
            sound.URL=@"E:\2-SPC\1-Archive System\1-Notification System ( RabbitMQ ) S-12-6-2019\17-6-2019 (Finish Receive app)\ReceiveMessages\ReceiveMessages\bin\Debug\plucky.mp3";
            sound.Ctlcontrols.play();
            toast.ShowDialog();
        }
    }
}

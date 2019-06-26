using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;


namespace Sender
{
    public class Send_Notification
    {
        //ref : https://www.rabbitmq.com/getstarted.html

        private string ip, username, pass;
        private ConnectionFactory factory;

        public Send_Notification(string hostname, string username, string password)
        {
            this.ip = hostname;
            this.username = username;
            this.pass = password;

            this.factory = new ConnectionFactory()
            {
                HostName = ip,
                UserName = username,
                Password = pass
            };
        }

        public string Send(string queueName, string message)
        {
            //create new connection with rabbitmq server
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                //create new queue if not exists.
                channel.QueueDeclare(queueName, true, false, false, null);
                channel.QueueDeclarePassive(queue: queueName);

                var body = Encoding.UTF8.GetBytes(message);

                //"" is a basic publish/subscribe pattern
                channel.BasicPublish(exchange: "",
                                         routingKey: queueName,
                                         basicProperties: null,
                                         body: body);

                return "Success Send : " + message + "to " + queueName;
            }
        }
    }
}

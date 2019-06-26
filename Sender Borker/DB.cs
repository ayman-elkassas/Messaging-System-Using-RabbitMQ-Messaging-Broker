using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using System.Data;
//using Oracle.ManagedDataAccess.Client;
//using System.Data.OracleClient;
using Oracle.DataAccess.Client;
using Newtonsoft.Json;

namespace Sender
{
    public class DB
    {
        string constr = "Data Source=orcl;User Id=workflow;Password=workflow";
        OracleConnection connection;
        string tableName;
        string NotificationNameAdapter;

        public DB(string table,string adapterName)
        {
            //connect db
            //register listener on table
            try
            {
                //Open the connection
                connection = new OracleConnection(constr);
                connection.Open();
                tableName = table;
                NotificationNameAdapter = adapterName;
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
        }


        public void registerListenerTable()
        {
            try
            {
                //register code
                string message = string.Empty;

                //select snapshot from table...
                OracleCommand selectCommand = new OracleCommand("select * from " + tableName, connection);
                selectCommand.AddRowid = true;
                //oracle dependancy saved screen shot of table and will be fire if any changes added to table
                OracleDependency dependency = new OracleDependency(selectCommand);
                selectCommand.Notification.IsNotifiedOnce = false;
                //if false in all changes in table will fire event
                dependency.QueryBasedNotification = false;

                selectCommand.Notification.IsNotifiedOnce = false;

                //onchanged fire event
                dependency.OnChange += new OnChangeEventHandler(OnTableChange);
                //execute to save first snapshot
                OracleDataReader reader = selectCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    message = reader[0].ToString();
                }
            }
            catch(Exception e)
            {

            }
            
        }
        
        public void OnTableChange(Object sender, OracleNotificationEventArgs args)
        {
            //Get data Changed before.........................

            if (args.Type == OracleNotificationType.Change)
            {
                int start = 0;
                if (args.Info.ToString() == "Update")
                {
                    start = 1;
                }

                for (int i = start; i < args.Details.Rows.Count; i++)
                {
                    DataRow detailRow = args.Details.Rows[i];
                    string rowid = detailRow["Rowid"].ToString();

                    DataSet ds = new DataSet();
                    using (System.Data.OracleClient.OracleDataAdapter da = new System.Data.OracleClient.OracleDataAdapter(NotificationNameAdapter, constr))
                    {
                        try
                        {
                            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand.Parameters.Add("MY_ID", System.Data.OracleClient.OracleType.VarChar).Value = rowid;
                            da.SelectCommand.Parameters.Add("Info", System.Data.OracleClient.OracleType.VarChar).Value = args.Info.ToString();

                            System.Data.OracleClient.OracleParameter ret = new System.Data.OracleClient.OracleParameter("my_cursor", System.Data.OracleClient.OracleType.Cursor);
                            ret.Direction = ParameterDirection.ReturnValue;
                            da.SelectCommand.Parameters.Add(ret);
                            da.Fill(ds);

                        }
                        catch (Exception ex)
                        {

                        }
                    }

                    string data = JsonConvert.SerializeObject(ds);
                    try
                    {
                        Message messageObject = new Message();
                        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                        {
                            messageObject.message = ds.Tables[0].Rows[j]["MESSAGE"].ToString();
                            messageObject.url = ds.Tables[0].Rows[j]["URL"].ToString(); ;
                            messageObject.type = ds.Tables[0].Rows[j]["TYPE"].ToString();

                            var jsonMessage = JsonConvert.SerializeObject(messageObject);

                            //after get two paramters of notification fire it...
                            string successMessage = sendNotification(ds.Tables[0].Rows[j]["NID"].ToString(), jsonMessage);
                        }
                    }
                    catch (Exception e)
                    {
                    }
                    
                }
            }
        }

        private string sendNotification(string id, string message)
        {
            Send_Notification sendNotify = new Send_Notification("192.223.2.200", "ayman", "ayman");
            string successMessage = sendNotify.Send(id, message);
            if (successMessage != null)
                return successMessage;
            else
                return "Error Sending..........";

            //here send
        }
    }
}

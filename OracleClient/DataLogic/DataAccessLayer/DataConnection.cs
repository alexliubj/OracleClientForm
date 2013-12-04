using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Collections.Specialized;
using  System.Configuration;

namespace DataLogic.DataAccessLayer
{
    public class DataConnection
    {

        private string connstring = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];

        private OracleConnection conn;
        public void CloseDatabase()
        {
            conn.Close();
        }
        public OracleCommand ConnectToDatabase()
        {
            conn = new OracleConnection(connstring);
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            return cmd;
        }

        public OracleCommand ConnectToDatabase(string excuteString)
        {
            conn = new OracleConnection(connstring);
            conn.Open();
            OracleCommand cmd = new OracleCommand(excuteString,conn);
            return cmd;
        }
    }
}

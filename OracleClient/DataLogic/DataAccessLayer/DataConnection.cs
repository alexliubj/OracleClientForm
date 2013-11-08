using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
namespace DataLogic.DataAccessLayer
{
    public class DataConnection
    {
        private string connstring = "user id=comp214_f13_102;password=password;data source=" +
                "(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)" +
                "(HOST=oracle1.centennialcollege.ca)(PORT=1521))(CONNECT_DATA=" +
                "(SERVICE_NAME=SQLD)))";
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

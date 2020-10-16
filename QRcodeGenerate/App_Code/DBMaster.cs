using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.App_Code
{
    public class DBMaster
    {
        private SqlConnection connect;
        public SqlConnection getConnection()
        {
            string connStr = "Server=localhost;Database=tasks;Integrated Security=SSPI;";
            connect = new SqlConnection(connStr);
            connect.Open();
            return connect;
        }
        public SqlDataReader getReader(string query)
        {
            SqlCommand cmd = new SqlCommand(query);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = this.getConnection();

            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public string getAdapterJSON(string query)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(query, this.connect);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            string text = JsonConvert.SerializeObject(ds.Tables[0]);
            return text;
        }
        public void closeConnection()
        {
            if (connect != null && connect.State == System.Data.ConnectionState.Open)
            {
                this.connect.Close();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibYuyiyo.BD
{
    class BD
    {
        private static BD mydb;
        private SqlConnection cnn;
        private BD()
        {
            open();
        }
        public static BD getInstance()
        {
            if (mydb == null)
            {
                mydb = new BD();
            }
            return mydb;
        }
        public DataTable sqlLeer(String sql)
        {
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public int sqlEjecutar(String sql)
        {
            SqlCommand cmd = new SqlCommand(sql, cnn);
            return cmd.ExecuteNonQuery();            
            
        }
        private void open()
        {
            cnn = new SqlConnection();
            cnn.ConnectionString = @"Data Source=sql5041.site4now.net;Initial Catalog=DB_A481B7_yuyito;Persist Security Info=True;User ID=DB_A481B7_yuyito_admin;Password=yuyito#2019";
            cnn.Open();
        }
        private void close()
        {
            cnn.Close();
        }
    }
}

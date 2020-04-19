using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Project01.SQLDB
{
    public class SQLDB
    {
        static string _ConnectionString= @"Data Source=DESKTOP-EP3U0I3\SQLEXPRESS;Initial Catalog=QuanLyQuanCafe;Integrated Security=True";

   
        static SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(_ConnectionString);
            con.Open();
            return con;
        }
 
        public static void ExecuteNoneQuery(SqlCommand cmd)
        {
            if (cmd.Connection != null)
            {
                cmd.ExecuteNonQuery();
            }
            else
            {
                using (SqlConnection con = GetConnection())
                {
                    cmd.Connection = GetConnection();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public static DataTable GetData(SqlCommand cmd)
        {
            if (cmd.Connection != null)
            {
                using (DataSet ds = new DataSet())
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        return ds.Tables[0];
                    }
                }
            }
            else
            {
                using (SqlConnection con = GetConnection())
                {
                    using (DataSet ds = new DataSet())
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            da.SelectCommand = cmd;
                            da.Fill(ds);
                            return ds.Tables[0];
                        }
                    }
                }
            }
        }


    }
}

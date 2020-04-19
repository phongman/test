using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Project01.DAO
{
    class Account
    {

        public static DataTable ThongTin_Account()
        {
            SqlCommand cmd = new SqlCommand("ThongTin_Account");
            cmd.CommandType = CommandType.StoredProcedure;

            return SQLDB.SQLDB.GetData(cmd);

        }

        public static bool ThongTin_Account_ByIDPass(string userName,string pass)
        {
            SqlCommand cmd = new SqlCommand("ThongTin_Account_ByIDPass");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userName", userName);
            cmd.Parameters.AddWithValue("@pass", pass);
            DataTable dt=SQLDB.SQLDB.GetData(cmd);
            if (dt.Rows.Count>0)
                return true;
            return false;

        }

    }
}

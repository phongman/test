using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Project01.DTO;

namespace Project01.DAO
{
    class DAOHoaDon
    {


        
        public static int MaHoaDonTheoBan(int ID)
        {
            SqlCommand cmd = new SqlCommand("MaHoaDon_TheoMaBan");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maBan", ID);

            DataTable dt = new DataTable();

            dt = SQLDB.SQLDB.GetData(cmd);

            if(dt.Rows.Count>0)
            {
                HoaDon hoaDon = new HoaDon(dt.Rows[0]);
                return hoaDon.ID;
            }
            return -1;

        }

        public static void ThemHoaDon(int idTable,int discount=0)
        {
            SqlCommand cmd = new SqlCommand("InsertBill");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idTable", idTable);
            cmd.Parameters.AddWithValue("@discount", discount);
            SQLDB.SQLDB.ExecuteNoneQuery(cmd);


        }
        public static void ThayDoiTrangThaiHoaDon(int idBill,int discount)
        {
            SqlCommand cmd = new SqlCommand("ThayDoiTrangThaiCuaHoaDon");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maBill", idBill);
            cmd.Parameters.AddWithValue("@discount", discount);
            SQLDB.SQLDB.ExecuteNoneQuery(cmd);


        }


        public static int getIDMaxBillInfo()
        {
            int idMax = 0;
            SqlCommand cmd = new SqlCommand("GetMaxIDInfo");
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable tb = SQLDB.SQLDB.GetData(cmd);
            idMax = (int)tb.Rows[0]["id"];

            return idMax;
        }




    }
}

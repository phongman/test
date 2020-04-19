using Project01.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Project01.DAO
{
    class DAOBillInfo
    {


        public static List<BillInfo> LayThongTinHoaDon(int id)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();

            SqlCommand cmd = new SqlCommand("HoaDonChiTiet_TheoMaHoaDon");
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@maHoaDon", id);

            DataTable dt = new DataTable();
            dt = SQLDB.SQLDB.GetData(cmd);

            foreach(DataRow item in dt.Rows)
            {
                BillInfo info = new BillInfo(item);
                listBillInfo.Add(info);

            }

            return listBillInfo;

        }


        public static void ThemHoaDonChiTiet(int idBill,int idFood,int count)
        {
            SqlCommand cmd = new SqlCommand("InsertBillInfo");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idBill",idBill);
            cmd.Parameters.AddWithValue("@idFood",idFood);
            cmd.Parameters.AddWithValue("@count",count);

            SQLDB.SQLDB.ExecuteNoneQuery(cmd);

        }




    }
}

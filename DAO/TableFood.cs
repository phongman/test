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
    class TableFood
    {

        public static void SwichTable(int tb1,int tb2)
        {
            SqlCommand cmd = new SqlCommand("SwitchTable");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idTable1", tb1);
            cmd.Parameters.AddWithValue("@idTable2", tb2);

            SQLDB.SQLDB.ExecuteNoneQuery(cmd);


        }


        public static List<Table> LoadTableList()
        {

            List<Table> tableList = new List<Table>();

            SqlCommand cmd = new SqlCommand("ThongTin_TableFood");
            cmd.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();

            dt = SQLDB.SQLDB.GetData(cmd);

            foreach(DataRow item in dt.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);

            }

            return tableList;
        }


    }
}

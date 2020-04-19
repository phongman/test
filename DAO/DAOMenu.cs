using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project01.DTO;
using System.Data;
using System.Data.SqlClient;


namespace Project01.DAO
{
    class DAOMenu
    {
        public static Table Menu { get; private set; }

        public static List<Menu> LayThongTinMenu(int idTable)
        {
            List<Menu> listMenu = new List<Menu>();

            SqlCommand cmd = new SqlCommand("ThongTinMenu");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maBan", idTable);


            DataTable dt = new DataTable();

            dt = SQLDB.SQLDB.GetData(cmd);

            foreach (DataRow item in dt.Rows)
            {
                Menu menu = new Menu(item);
                listMenu.Add(menu);

            }

            return listMenu;

            
        }
    }
}

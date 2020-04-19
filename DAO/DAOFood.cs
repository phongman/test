using Project01.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Project01.DAO
{
    public class DAOFood
    {

        public static List<Food> LayDanhSachFoodByID(int id)
        {
            List<Food> listFood = new List<Food>();

            SqlCommand cmd = new SqlCommand("DanhSachFoodByID");

          
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maCatelogy", id);

           DataTable dt= SQLDB.SQLDB.GetData(cmd);
            foreach(DataRow item in dt.Rows)
            {
                Food food = new Food(item);
                listFood.Add(food);

            }

            return listFood;


        }

    }
}

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
    public class DAOCatelogy
    {
        public  static List<Catelogy> listCatelogy()
        {
            List<Catelogy> listCatelogy = new List<Catelogy>();

            SqlCommand cmd = new SqlCommand("ThongTinCatelogy");

            DataTable dt = SQLDB.SQLDB.GetData(cmd);

            foreach(DataRow item in dt.Rows)
            {
                Catelogy ct = new Catelogy(item);
                listCatelogy.Add(ct);

            }

            return listCatelogy;
        }


    }
}

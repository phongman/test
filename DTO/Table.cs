using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Project01.DTO
{
    class Table
    {

        public Table(int id,string name,string status)
        {
            this.iD = id;
            this.Name = name;
            this.status = status;
        }
        public Table(DataRow row)
        {
            this.ID=(int)row["id"];
            this.Name = row["name"].ToString();
            this.Status = row["Status"].ToString();

        }


        public static int TableWidth = 150;
        public static int TableHeight = 150;
        private string name;
        private string status;
        private int iD;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }
    }
}

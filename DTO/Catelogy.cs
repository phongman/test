using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace Project01.DTO
{
    public class Catelogy
    {
        public Catelogy(int id,string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public Catelogy(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
        }

        private int iD;
        private string name;


        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
    }
}

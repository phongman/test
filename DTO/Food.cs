using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project01.DTO
{
    public class Food
    {
        public Food(int id,string name,int idCatelogy,double price)
        {
            this.ID = id;
            this.Name = name;
            this.iDCatelogy = idCatelogy;
            this.Price = price;
        }

        public Food(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.IDCatelogy = (int)row["idCategory"];
            this.Price = (double)row["price"];

        }

        private int iD;
        private string name;
        private int iDCatelogy;
        private double price;

       
        public double Price { get => price; set => price = value; }
        
        public string Name { get => name; set => name = value; }
        public int ID { get => iD; set => iD = value; }
        public int IDCatelogy { get => iDCatelogy; set => iDCatelogy = value; }
    }
}

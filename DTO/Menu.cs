using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Project01.DTO
{
    class Menu
    {
        public  Menu(string foodName,int count,double price,double totalPrice)
        {
            this.foodName = foodName;
            this.Count = count;
            this.Price = price;
            this.TotalPrice = totalPrice;
        }

        public Menu(DataRow dr)
        {
            this.foodName =dr["name"].ToString();
            this.Count = (int)dr["count"];
            this.Price = (double)dr["price"];
            this.TotalPrice = (double)dr["totalPrice"];
        }


        private int count;
        private string foodName;
        private double price;
        private double totalPrice;
        public string FoodName { get => foodName; set => foodName = value; }
        public int Count { get => count; set => count = value; }
        public double TotalPrice { get => totalPrice; set => totalPrice = value; }
        public double Price { get => price; set => price = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace Project01.DTO
{
    class HoaDon
    {

        public HoaDon(int id,DateTime? dateCheckIn,DateTime? dateCheckOut,int status,int discount=0)
        {
            this.ID = id;
            this.DateCheckIn = DateCheckIn;
            this.DateCheckOut = DateCheckOut;
            this.Status = status;
            this.Discount = discount;

        }


        public HoaDon(DataRow row)
        {
            this.ID =(int)row["id"];
            this.DateCheckIn = (DateTime?)row["DateCheckIn"];
            var dataCheckOutTemp = row["DateCheckOut"];

            if(dataCheckOutTemp.ToString()!="")
                this.DateCheckOut = (DateTime?)dataCheckOutTemp;


            this.Status=(int) row["Status"];
            if(row["discount"].ToString()!="")
                 this.Discount=(int)row["discount"];
            
        }


        private int discount;
        private int status;
        private DateTime? dateCheckOut;
        private DateTime? dateCheckIn;
        private int iD;

        public int ID { get => iD; set => iD = value; }
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int Status { get => status; set => status = value; }
        public int Discount { get => discount; set => discount = value; }
    }
}

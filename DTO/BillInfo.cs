using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Project01.DTO
{
    class BillInfo
    {
        public BillInfo(int id,int idBill,int idFood,int count)
        {
            this.ID = id;
            this.IDBilll = idBill;
            this.IDFood = idFood;
            this.Count = count;
        }


        public BillInfo(DataRow row)
        {
            this.ID = (int)row["id"];
            this.IDBilll = (int)row["idBill"];
            this.IDFood = (int)row["idFood"];
            this.Count = (int)row["count"];
        }


        private int iD;
        private int iDBilll;
        private int iDFood;
        private int count;

        public int ID { get => iD; set => iD = value; }
        public int IDFood { get => iDFood; set => iDFood = value; }
        public int Count { get => count; set => count = value; }
        public int IDBilll { get => iDBilll; set => iDBilll = value; }
    }
}

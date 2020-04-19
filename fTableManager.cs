using Project01.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;


namespace Project01
{
    public partial class fTableManager : Form
    {
        public fTableManager()
        {            InitializeComponent();
            LoadTable();
            loadCatelogy();
            loadComboboxTable(cbTable);
        }



        private void FTableManager_Load(object sender, EventArgs e)
        {

        }

        #region Method

        void LoadTable()
        {
            flpTable.Controls.Clear();
            List<Table> tableList = DAO.TableFood.LoadTableList();

            foreach(Table item in tableList)
            {
                Button btn = new Button() { Width = DTO.Table.TableWidth, Height = DTO.Table.TableHeight };
                string strStatus;
                btn.Click += btn_Click;
                btn.Tag = item;


                if(item.Status.Equals("False"))
                {
                    strStatus = "Trống";
                 
                }
                else
                {
                    btn.BackColor = Color.LightBlue;
                    strStatus = "Có khách";
                }

                btn.Text = item.Name + Environment.NewLine + strStatus;
            

                flpTable.Controls.Add(btn);
            }

        }

        private void hienThiHoaDon(int ID)
        {
            lvHoaDon.Items.Clear();
            List<DTO.Menu> listMenu = DAO.DAOMenu.LayThongTinMenu(ID);

            double totalPrice = 0;
            foreach(DTO.Menu item in listMenu)
            {
                ListViewItem lvItem = new ListViewItem(item.FoodName.ToString());
                lvItem.SubItems.Add(item.Count.ToString());
                lvItem.SubItems.Add(item.Price.ToString());
                lvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lvHoaDon.Items.Add(lvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentCulture = culture;
            txtTongTien.Text = totalPrice.ToString("c");

            
        }

        private void loadCatelogy()
        {
            List<Catelogy> listCatelogy = DAO.DAOCatelogy.listCatelogy();
            cbCatelogy.DataSource = listCatelogy;
            cbCatelogy.DisplayMember = "name";
        }


        private void loadFoodByID(int id)
        {
            List<Food> listFood = DAO.DAOFood.LayDanhSachFoodByID(id);
            cbFood.DataSource = listFood;
            cbFood.DisplayMember = "name";
           
        }

        private void checkOut(int id,int discount)
        {
            DAO.DAOHoaDon.ThayDoiTrangThaiHoaDon(id,discount);

        }

        private void loadComboboxTable(ComboBox cb)
        {
            cb.DataSource = DAO.TableFood.LoadTableList();
            cb.DisplayMember = "Name";
        }


        #endregion

        #region  Events

        private void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            lvHoaDon.Tag = (sender as Button).Tag;
            hienThiHoaDon(tableID);
            LoadTable();
        }



        private void ĐăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ThôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile();
            f.ShowDialog();
        }

        private void AdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.ShowDialog();
        }

        private void CbCatelogy_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;

            Catelogy selected = cb.SelectedItem as Catelogy;

            id = selected.ID;


            loadFoodByID(id);
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            Table table = lvHoaDon.Tag as Table;

            int idBill = DAO.DAOHoaDon.MaHoaDonTheoBan(table.ID);
            int idFood = (cbFood.SelectedItem as Food).ID;
            int count = (int)nudSoLuongThem.Value;

            if (idBill == -1)
            {
                DAO.DAOHoaDon.ThemHoaDon(table.ID);
                DAO.DAOBillInfo.ThemHoaDonChiTiet(DAO.DAOHoaDon.getIDMaxBillInfo(), idFood, count);
            }
            else
            {
                DAO.DAOBillInfo.ThemHoaDonChiTiet(idBill, idFood, count);
            }

            hienThiHoaDon(table.ID);
            LoadTable();


        }

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            Table table = lvHoaDon.Tag as Table;

            int discount = (int)nudGiamGia.Value;
            int idBill = DAO.DAOHoaDon.MaHoaDonTheoBan(table.ID);

            if(idBill!=-1)
            {
                if(MessageBox.Show("Bạn có muốn thanh toán hóa đơn cho bạn"+table.Name,"Thông báo",MessageBoxButtons.OKCancel)==System.Windows.Forms.DialogResult.OK)
                {

                    checkOut(idBill,discount);
                    hienThiHoaDon(table.ID);
                }

            }
            LoadTable();


        }




        #endregion

        private void BtnGiamGia_Click(object sender, EventArgs e)
        {
            string tongTien = txtTongTien.Text;
            string catChuoi = tongTien.Substring(0,(tongTien.Length) - 1);

            double discount = (double)nudGiamGia.Value;
            double tienChuaGiamGia = double.Parse(catChuoi);
            double tienDaGiamGia;

            if (discount != 0)
            {
                tienDaGiamGia = tienChuaGiamGia - (tienChuaGiamGia * discount * 0.01);
                CultureInfo culture = new CultureInfo("vi-VN");
                Thread.CurrentThread.CurrentCulture = culture;
                txtTongTien.Text = tienDaGiamGia.ToString("c");

            }
                
            
        }

        private void BtnChuyenBan_Click(object sender, EventArgs e)
        {
            
            int id1 = (lvHoaDon.Tag as Table).ID;
            int id2 = (cbTable.SelectedItem as Table).ID;
            string name1 = (lvHoaDon.Tag as Table).Name;
            string name2 = (cbTable.SelectedItem as Table).Name;

            if (MessageBox.Show(string.Format("Bạn có thật sự muốn chuyển bàn {0} qua bàn {1}",name1,name2),"Thông báo",MessageBoxButtons.OKCancel)==System.Windows.Forms.DialogResult.OK) 
           {
                DAO.TableFood.SwichTable(id1, id2);
                LoadTable();
           }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project01
{
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();
        }

        private void BtnXemTaiKhoan_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = DAO.Account.ThongTin_Account();
            dgvTaiKhoan.DataSource = dt;

        }
    }
}

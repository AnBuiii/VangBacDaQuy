using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangBacDaQuy.form
{
    public partial class frmDangNhap : Form
    {
        public static string user;
        public static string manhom;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT * from NGUOIDUNG WHERE TENDANGNHAP = '" + txbTenDangNhap.Text + "' AND MATKHAU = '" + txbMatKhau.Text + "'";
            if (!Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Thông tin đăng nhập không đúng");
                return;
            }
            Class.Functions.User = txbTenDangNhap.Text;
            this.Close();                
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            
        }
    }
}

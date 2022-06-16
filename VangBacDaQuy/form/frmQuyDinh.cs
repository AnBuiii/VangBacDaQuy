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
    public partial class frmQuyDinh : Form
    {
        public frmQuyDinh()
        {
            InitializeComponent();
        }

        private void frmQuyDinh_Load(object sender, EventArgs e)
        {
            String sql = "SELECT PhanTramTienTraTruoc FROM THAMSO";
        
             txbPhanTramTraTruoc.Text = (float.Parse(Class.Functions.GetFieldValues(sql)) * 100).ToString();
            txbPhanTramTraTruoc.Enabled = false;
            butLuu.Enabled = false;
            butHuy.Enabled = false;
        }

        private void txbPhanTramTraTruoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
            {

                if (txbPhanTramTraTruoc.TextLength > 0 && float.Parse(txbPhanTramTraTruoc.Text) > 100)
                {
                    txbPhanTramTraTruoc.Text = "";
                    MessageBox.Show("Chỉ từ 0 - 100%");

                }
                e.Handled = false;
            }

            else e.Handled = true;
        }

        private void butChinhSua_Click(object sender, EventArgs e)
        {
            txbPhanTramTraTruoc.Enabled = true;
            butLuu.Enabled = true;
            butHuy.Enabled = true;
            butChinhSua.Enabled = false;
        }

        Boolean saveData()
        {
            if (txbPhanTramTraTruoc.Text != "")
            {
                String sql = "UPDATE THAMSO SET PhanTramTienTraTruoc = " + (float.Parse(txbPhanTramTraTruoc.Text) / 100).ToString();
                Class.Functions.RunSQL(sql);
                txbPhanTramTraTruoc.Enabled = false;
                butLuu.Enabled = false;
                butHuy.Enabled = false;
                butChinhSua.Enabled = true;
                MessageBox.Show("Lưu thành công!");
                return true;
            }
            else
            {

                MessageBox.Show("Vui lòng nhập phần trăm tiền trả trước");
            }
            return false;
        }
        void resetData()
        {
            String sql = "SELECT PhanTramTienTraTruoc FROM THAMSO";
            txbPhanTramTraTruoc.Text = (float.Parse(Class.Functions.GetFieldValues(sql)) * 100).ToString();
            txbPhanTramTraTruoc.Enabled = false;
            butLuu.Enabled = false;
            butHuy.Enabled = false;
            butChinhSua.Enabled = true;
        }

        private void butLuu_Click(object sender, EventArgs e)
        {

            saveData();
        }

        private void butHuy_Click(object sender, EventArgs e)
        {
            resetData();
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            if (!butChinhSua.Enabled)
            {
                if ((MessageBox.Show("Bạn có muốn những thay đổi?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    if (saveData())
                    {
                        this.Close();
                    }

                }
            }
            else
            {
                resetData();
                this.Close();
            }
        }
    }
}

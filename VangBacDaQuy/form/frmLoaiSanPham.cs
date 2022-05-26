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
    public partial class frmLoaiSanPham : Form
    {
        DataTable dtLoaiSanPham;
        public frmLoaiSanPham()
        {
            InitializeComponent();
        }

        private void frmLoaiSanPham_Load(object sender, EventArgs e)
        {
            txbMaLoaiSp.Enabled = false;
            btnLuu.Enabled = false;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MALOAISP, TENLOAISP, DONVITINH, PHANTRAMLOINHUAN FROM LOAISANPHAM";
            dtLoaiSanPham = Class.Functions.GetDataToDataTable(sql);
            dgvLoaiSanPham.DataSource = dtLoaiSanPham;
            dgvLoaiSanPham.Columns[0].HeaderText = "Mã sản phẩm";
            dgvLoaiSanPham.Columns[1].HeaderText = "Tên sản phẩm";
            dgvLoaiSanPham.Columns[2].HeaderText = "Mã loại sản phẩm";
            dgvLoaiSanPham.Columns[3].HeaderText = "Đơn giá";
            /*dgvLoaiSanPham.Columns[0].Width = 100;
            dgvLoaiSanPham.Columns[1].Width = 300;
            dgvLoaiSanPham.Columns[2].Width = 300;
            dgvLoaiSanPham.Columns[3].Width = 300;*/
            dgvLoaiSanPham.AllowUserToAddRows = false;
            dgvLoaiSanPham.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void dgvLoaiSanPham_Click(object sender, EventArgs e)
        {

            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbMaLoaiSp.Focus();
                return;
            }
            if (dtLoaiSanPham.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txbMaLoaiSp.Text = dgvLoaiSanPham.CurrentRow.Cells["MALOAISP"].Value.ToString();
            txbTenLoaiSp.Text = dgvLoaiSanPham.CurrentRow.Cells["TENLOAISP"].Value.ToString();
            txbDVT.Text = dgvLoaiSanPham.CurrentRow.Cells["DONVITINH"].Value.ToString();
            txbPTLN.Text = dgvLoaiSanPham.CurrentRow.Cells["PHANTRAMLOINHUAN"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            txbMaLoaiSp.Enabled = true;
            txbMaLoaiSp.Focus();
            ResetValue();
        }

        private void ResetValue()
        {
            txbPTLN.Text = "";
            txbDVT.Text = "";
            txbMaLoaiSp.Text = "";
            txbTenLoaiSp.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql
            if (txbMaLoaiSp.Text.Trim().Length == 0) 
            {
                MessageBox.Show("Bạn phải nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbMaLoaiSp.Focus();
                return;
            }
            if (txbTenLoaiSp.Text.Trim().Length == 0) 
            {
                MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbTenLoaiSp.Focus();
                return;
            }
            if (txbDVT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã loại sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbDVT.Focus();
                return;
            }
            if (txbPTLN.Text.Trim().Length == 0) 
            {
                MessageBox.Show("Bạn phải nhập đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbPTLN.Focus();
                return;
            }

            sql = "Select MALOAISP From LOAISANPHAM where MALOAISP='" + txbMaLoaiSp.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã sản phẩm này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbMaLoaiSp.Focus();
                return;
            }

            sql = "INSERT INTO LOAISANPHAM VALUES('" + txbMaLoaiSp.Text + "',N'" + txbTenLoaiSp.Text + "',N'" + txbDVT.Text + "', " + Convert.ToInt32(txbPTLN.Text) + ")";
            Class.Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridView(); //Nạp lại DataGridView
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txbMaLoaiSp.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            String sql;
            if (dtLoaiSanPham.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txbMaLoaiSp.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txbTenLoaiSp.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbTenLoaiSp.Focus();
                return;
            }
            if (txbDVT.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn phải nhập mã loại sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbDVT.Focus();
                return;
            }
            if (txbPTLN.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn phải nhập đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbPTLN.Focus();
                return;
            }
           

            sql = "UPDATE LOAISANPHAM SET TENLOAISP = N'" + txbTenLoaiSp.Text + "', DONVITINH = N'" + txbDVT.Text + "', PHANTRAMLOINHUAN = " + Convert.ToDouble(txbPTLN.Text) +  " WHERE MALOAISP = '" + txbMaLoaiSp.Text + "'";
            Class.Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();
            btnHuy.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            String sql;
            if (dtLoaiSanPham.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txbMaLoaiSp.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "DELETE LOAISANPHAM WHERE MALOAISP = '" + txbMaLoaiSp.Text + "'";
            Class.Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txbMaLoaiSp.Enabled = false;
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

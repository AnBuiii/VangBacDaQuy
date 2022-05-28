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
    public partial class frmSanPham : Form
    {
        DataTable dtSanPham;
        DataTable dtPhieuMuaHang;
        DataTable dtPhieuBanHang;
        public frmSanPham()
        {
            InitializeComponent();
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            txbMaSp.Enabled = false;
            btnLuu.Enabled = false;
            Class.Functions.FillCombo("SELECT MALOAISP, TENLOAISP FROM LOAISANPHAM", cbMaLoaiSp, "MALOAISP", "MAKLOAISP");
            cbMaLoaiSp.SelectedIndex = -1;
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MASP, TENSP, MALOAISP, DONGIA, SOLUONG FROM SANPHAM";
            dtSanPham = Class.Functions.GetDataToDataTable(sql);
            dgvSanPham.DataSource = dtSanPham;
            dgvSanPham.Columns[0].HeaderText = "Mã sản phẩm";
            dgvSanPham.Columns[1].HeaderText = "Tên sản phẩm";
            dgvSanPham.Columns[2].HeaderText = "Mã loại sản phẩm";
            dgvSanPham.Columns[3].HeaderText = "Đơn giá";
            dgvSanPham.Columns[4].HeaderText = "Số lượng";
            /*dgvSanPham.Columns[0].Width = 100;
            dgvSanPham.Columns[1].Width = 300;
            dgvSanPham.Columns[2].Width = 300;
            dgvSanPham.Columns[3].Width = 300;*/
            dgvSanPham.AllowUserToAddRows = false;
            dgvSanPham.EditMode = DataGridViewEditMode.EditProgrammatically;

        }
        private void LoadDataPhieuBanHang(String masp)
        {
            string sql = "SELECT PHIEUBANHANG.SOPHIEU, MAKH, NGAYLAP, SOLUONG FROM PHIEUBANHANG, CHITIETPHIEUBANHANG WHERE PHIEUBANHANG.SOPHIEU = CHITIETPHIEUBANHANG.SOPHIEU AND MASP = '" + masp + "'" ;
            dtPhieuBanHang = Class.Functions.GetDataToDataTable(sql);
            dgvPhieuBanHang.DataSource = dtPhieuBanHang;
            dgvSanPham.DataSource = dtSanPham;
            dgvSanPham.Columns[0].HeaderText = "Số phiếu";
            dgvSanPham.Columns[1].HeaderText = "Mã khách hàng";
            dgvSanPham.Columns[2].HeaderText = "Ngày lập";
            dgvSanPham.Columns[3].HeaderText = "Số lượng";
            dgvPhieuBanHang.AllowUserToAddRows=false;
            dgvPhieuBanHang.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void dgvSanPham_Click(object sender, EventArgs e)
        {

            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbMaSp.Focus();
                return;
            }
            if (dtSanPham.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txbMaSp.Text = dgvSanPham.CurrentRow.Cells["MASP"].Value.ToString();
            txbTenSp.Text = dgvSanPham.CurrentRow.Cells["TENSP"].Value.ToString();
            cbMaLoaiSp.Text = dgvSanPham.CurrentRow.Cells["MALOAISP"].Value.ToString();
            txbDongia.Text = dgvSanPham.CurrentRow.Cells["DONGIA"].Value.ToString();
            txbSL.Text = dgvSanPham.CurrentRow.Cells["SOLUONG"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
            LoadDataPhieuBanHang(txbMaSp.Text);

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            txbMaSp.Enabled = true;
            txbMaSp.Focus();
            ResetValue();
        }

        private void ResetValue()
        {
            txbDongia.Text = "";
            cbMaLoaiSp.Text = "";
            txbMaSp.Text = "";
            txbTenSp.Text = "";
            txbSL.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql
            if (txbMaSp.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn phải nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbMaSp.Focus();
                return;
            }
            if (txbTenSp.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbTenSp.Focus();
                return;
            }
            if (cbMaLoaiSp.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn phải nhập mã loại sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbMaLoaiSp.Focus();
                return;
            }
            if (txbDongia.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn phải nhập đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbDongia.Focus();
                return;
            }
            if (txbSL.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbSL.Focus();
                return;
            }

            sql = "Select MASP From SANPHAM where MASP='" + txbMaSp.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã sản phẩm này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbMaSp.Focus();
                return;
            }

            sql = "INSERT INTO SANPHAM VALUES('" + txbMaSp.Text + "','" + cbMaLoaiSp.Text + "',N'" + txbTenSp.Text + "'," + Convert.ToDouble(txbDongia.Text.ToString()) + "," + Convert.ToInt32(txbSL.Text.ToString()) + ")";
            Class.Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridView(); //Nạp lại DataGridView
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txbMaSp.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            String sql;
            if (dtSanPham.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txbMaSp.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txbTenSp.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbTenSp.Focus();
                return;
            }
            if (cbMaLoaiSp.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn phải nhập mã loại sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbMaLoaiSp.Focus();
                return;
            }
            if (txbDongia.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn phải nhập đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbDongia.Focus();
                return;
            }
            if (txbSL.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbSL.Focus();
                return;
            }

            sql = "UPDATE SANPHAM SET TENSP = N'" + txbTenSp.Text + "', MALOAISP = '" + cbMaLoaiSp.Text + "', DONGIA = " + Convert.ToDouble(txbDongia.Text) + ", SOLUONG = " + Convert.ToInt32(txbSL.Text) + " WHERE MASP = '" + txbMaSp.Text + "'";
            Class.Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();
            btnHuy.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            String sql;
            if (dtSanPham.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txbMaSp.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "DELETE SANPHAM WHERE MASP = '" + txbMaSp.Text + "'";
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
            txbMaSp.Enabled = false;
        }

        private void cbMaLoaiSp_TextChanged(object sender, EventArgs e)
        {
            string sql;
            if (cbMaLoaiSp.Text == "")
            {
                txbTenLoaiSp.Text = "";
            }
            sql = "SELECT TENLOAISP FROM LOAISANPHAM WHERE MALOAISP = '" + cbMaLoaiSp.SelectedValue + "'";
            txbTenLoaiSp.Text = Class.Functions.GetFieldValues(sql);
        }
    }
}

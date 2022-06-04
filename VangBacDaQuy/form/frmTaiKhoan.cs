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
    public partial class frmTaiKhoan : Form
    {
        DataTable dtNguoiDung;
        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT TENDANGNHAP, MATKHAU, MANHOM FROM NGUOIDUNG";
            dtNguoiDung = Class.Functions.GetDataToDataTable(sql);
            dgvNguoiDung.DataSource = dtNguoiDung;
            dgvNguoiDung.Columns[0].HeaderText = "Tên đăng nhập";
            dgvNguoiDung.Columns[1].HeaderText = "Mật khhẩu";
            dgvNguoiDung.Columns[2].HeaderText = "Mã nhóm";
            /*dgvNguoiDung.Columns[0].Width = 100;
            dgvNguoiDung.Columns[1].Width = 300;
            dgvNguoiDung.Columns[2].Width = 300;
            dgvNguoiDung.Columns[3].Width = 300;*/
            dgvNguoiDung.AllowUserToAddRows = false;
            dgvNguoiDung.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void dgvNguoiDung_Click(object sender, EventArgs e)
        {

            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbTenDangNhap.Focus();
                return;
            }
            if (dtNguoiDung.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txbTenDangNhap.Text = dgvNguoiDung.CurrentRow.Cells["TENDANGNHAP"].Value.ToString();
            txbMatKhau.Text = dgvNguoiDung.CurrentRow.Cells["MATKHAU"].Value.ToString();
            cbMaNhom.Text = dgvNguoiDung.CurrentRow.Cells["MANHOM"].Value.ToString();
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
            txbTenDangNhap.Enabled = true;
            txbTenDangNhap.Focus();
            ResetValue();
        }

        private void ResetValue()
        {
            cbMaNhom.Text = "";
            txbTenDangNhap.Text = "";
            txbMatKhau.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txbTenDangNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã dịch vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbTenDangNhap.Focus();
                return;
            }
            if (txbMatKhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên dịch vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbMatKhau.Focus();
                return;
            }
            if (cbMaNhom.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbMaNhom.Focus();
                return;
            }


            sql = "Select TENDANGNHAP From NGUOIDUNG where TENDANGNHAP='" + txbTenDangNhap.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã dịch vụ này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbTenDangNhap.Focus();
                return;
            }

            sql = "INSERT INTO NGUOIDUNG VALUES('" + txbTenDangNhap.Text + "','" + txbMatKhau.Text + "','" + cbMaNhom.Text + "')";
            Class.Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txbTenDangNhap.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            String sql;
            if (dtNguoiDung.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txbTenDangNhap.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txbMatKhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên dịch vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbMatKhau.Focus();
                return;
            }
            if (cbMaNhom.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbMaNhom.Focus();
                return;
            }


            sql = "UPDATE NGUOIDUNG SET MATKHAU = '" + txbMatKhau.Text + "', MANHOM = '" + cbMaNhom.Text + "' WHERE TENDANGNHAP = '" + txbTenDangNhap.Text + "'";
            Class.Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();
            btnHuy.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            String sql;
            if (dtNguoiDung.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txbTenDangNhap.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "DELETE NGUOIDUNG WHERE TENDANGNHAP = '" + txbTenDangNhap.Text + "'";

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
            txbTenDangNhap.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            txbTenDangNhap.Enabled = false;
            btnLuu.Enabled = false;
            Class.Functions.FillCombo("SELECT MANHOM FROM NHOMNGUOIDUNG", cbMaNhom, "MANHOM", "MANHOM");
            LoadDataGridView();
        }

        private void cbMaNhom_TextChanged(object sender, EventArgs e)
        {
            string sql;
            if (cbMaNhom.Text == "")
            {
                txbTenMaNhom.Text = "";
            }
            sql = "SELECT TENNHOM FROM NHOMNGUOIDUNG WHERE MANHOM = '" + cbMaNhom.SelectedValue + "'";
            txbTenMaNhom.Text = Class.Functions.GetFieldValues(sql);
        }
    }
}

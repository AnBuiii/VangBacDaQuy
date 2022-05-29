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
    public partial class frmNhaCungCap : Form
    {
        DataTable dtNhaCungCap;
        DataTable dtPhieuMuaHang;
        public frmNhaCungCap()
        {
            InitializeComponent();
        }

        private void frmNHACUNGCAP_Load(object sender, EventArgs e)
        {
            txbMaNCC.Enabled = false;
            btnLuu.Enabled = false;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MANCC, DIACHI, SODT FROM NHACUNGCAP";
            dtNhaCungCap = Class.Functions.GetDataToDataTable(sql);
            dgvNhaCungCap.DataSource = dtNhaCungCap;
            dgvNhaCungCap.Columns[0].HeaderText = "Mã nhà cung cấp";
            dgvNhaCungCap.Columns[1].HeaderText = "Địa chỉ";
            dgvNhaCungCap.Columns[2].HeaderText = "Số điện thoại";
            /*dgvNhaCungCap.Columns[0].Width = 100;
            dgvNhaCungCap.Columns[1].Width = 300;
            dgvNhaCungCap.Columns[2].Width = 300;
            dgvNhaCungCap.Columns[3].Width = 300;*/
            dgvNhaCungCap.AllowUserToAddRows = false;
            dgvNhaCungCap.EditMode = DataGridViewEditMode.EditProgrammatically;

        }
        private void LoadDataPhieuMuaHang(String mancc)
        {
            string sql = "SELECT SOPHIEU, convert(varchar, NGAYLAP, 103) AS NGAYLAP, TONGTIEN FROM PHIEUMUAHANG WHERE MANCC = '" + mancc + "'";
            dtPhieuMuaHang = Class.Functions.GetDataToDataTable(sql);
            dgvPhieuMuaHang.DataSource = dtPhieuMuaHang;
            dgvPhieuMuaHang.Columns[0].HeaderText = "Số phiếu";
            dgvPhieuMuaHang.Columns[1].HeaderText = "Ngày lập";
            dgvPhieuMuaHang.Columns[2].HeaderText = "Tổng tiền";
            dgvPhieuMuaHang.AllowUserToAddRows = false;
            dgvPhieuMuaHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvNhaCungCap_Click(object sender, EventArgs e)
        {

            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbMaNCC.Focus();
                return;
            }
            if (dtNhaCungCap.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txbMaNCC.Text = dgvNhaCungCap.CurrentRow.Cells["MANCC"].Value.ToString();
            txbDiaChi.Text = dgvNhaCungCap.CurrentRow.Cells["DIACHI"].Value.ToString();
            txbSoDT.Text = dgvNhaCungCap.CurrentRow.Cells["SODT"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;

            LoadDataPhieuMuaHang(txbMaNCC.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            txbMaNCC.Enabled = true;
            txbMaNCC.Focus();
            ResetValue();
        }

        private void ResetValue()
        {
            txbSoDT.Text = "";
            txbMaNCC.Text = "";
            txbDiaChi.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txbMaNCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbMaNCC.Focus();
                return;
            }
            if (txbDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbDiaChi.Focus();
                return;
            }
            if (txbSoDT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbSoDT.Focus();
                return;
            }


            sql = "Select MANCC From NHACUNGCAP where MANCC='" + txbMaNCC.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã khách hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbMaNCC.Focus();
                return;
            }

            sql = "INSERT INTO NHACUNGCAP VALUES('" + txbMaNCC.Text + "',N'" + txbDiaChi.Text + "','" + txbSoDT.Text + "')";
            Class.Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txbMaNCC.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            String sql;
            if (dtNhaCungCap.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txbMaNCC.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txbDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbDiaChi.Focus();
                return;
            }
            if (txbSoDT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbSoDT.Focus();
                return;
            }


            sql = "UPDATE NHACUNGCAP SET DIACHI = N'" + txbDiaChi.Text + "', SODT = '" + txbSoDT.Text + "' WHERE MANCC = '" + txbMaNCC.Text + "'";
            Class.Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();
            btnHuy.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            String sql;
            if (dtNhaCungCap.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txbMaNCC.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "DELETE NHACUNGCAP WHERE MANCC = '" + txbMaNCC.Text + "'";

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
            txbMaNCC.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPhieuMuaHang_DoubleClick(object sender, EventArgs e)
        {
            if (dtPhieuMuaHang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmPhieuMuaHang frmPhieuMuaHang = new frmPhieuMuaHang(dgvPhieuMuaHang.CurrentRow.Cells["SOPHIEU"].Value.ToString());
            frmPhieuMuaHang.MdiParent = this.ParentForm;
            frmPhieuMuaHang.Dock = DockStyle.Fill;
            frmPhieuMuaHang.Show();
            this.Close();
        }
    }
}

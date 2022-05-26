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
    public partial class frmDichVu : Form
    {
        DataTable dtDichVu;
        public frmDichVu()
        {
            InitializeComponent();
        }

        private void frmDichVu_Load(object sender, EventArgs e)
        {
            txbMaDV.Enabled = false;
            btnLuu.Enabled = false;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MADV, TENDV, DONGIA FROM DICHVU";
            dtDichVu = Class.Functions.GetDataToDataTable(sql);
            dgvDichVu.DataSource = dtDichVu;
            dgvDichVu.Columns[0].HeaderText = "Mã dịch vụ";
            dgvDichVu.Columns[1].HeaderText = "Tên dịch vụ";
            dgvDichVu.Columns[2].HeaderText = "Đơn giá";
            /*dgvDichVu.Columns[0].Width = 100;
            dgvDichVu.Columns[1].Width = 300;
            dgvDichVu.Columns[2].Width = 300;
            dgvDichVu.Columns[3].Width = 300;*/
            dgvDichVu.AllowUserToAddRows = false;
            dgvDichVu.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void dgvDichVu_Click(object sender, EventArgs e)
        {

            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbMaDV.Focus();
                return;
            }
            if (dtDichVu.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txbMaDV.Text = dgvDichVu.CurrentRow.Cells["MADV"].Value.ToString();
            txbTenDV.Text = dgvDichVu.CurrentRow.Cells["TENDV"].Value.ToString();
            txbDonGia.Text = dgvDichVu.CurrentRow.Cells["DONGIA"].Value.ToString();
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
            txbMaDV.Enabled = true;
            txbMaDV.Focus();
            ResetValue();
        }

        private void ResetValue()
        {
            txbDonGia.Text = "";
            txbMaDV.Text = "";
            txbTenDV.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txbMaDV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã dịch vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbMaDV.Focus();
                return;
            }
            if (txbTenDV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên dịch vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbTenDV.Focus();
                return;
            }
            if (txbDonGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbDonGia.Focus();
                return;
            }


            sql = "Select MADV From DICHVU where MADV='" + txbMaDV.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã dịch vụ này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbMaDV.Focus();
                return;
            }

            sql = "INSERT INTO DICHVU VALUES('" + txbMaDV.Text + "',N'" + txbTenDV.Text + "'," + Convert.ToDouble(txbDonGia.Text) + ")";
            Class.Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txbMaDV.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            String sql;
            if (dtDichVu.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txbMaDV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txbTenDV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên dịch vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbTenDV.Focus();
                return;
            }
            if (txbDonGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbDonGia.Focus();
                return;
            }


            sql = "UPDATE DICHVU SET TENDV = N'" + txbTenDV.Text + "', DONGIA = " + Convert.ToDouble(txbDonGia.Text) + " WHERE MADV = '" + txbMaDV.Text + "'";
            Class.Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();
            btnHuy.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            String sql;
            if (dtDichVu.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txbMaDV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "DELETE DICHVU WHERE MADV = '" + txbMaDV.Text + "'";

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
            txbMaDV.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

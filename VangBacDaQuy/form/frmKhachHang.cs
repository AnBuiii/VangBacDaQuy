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
    public partial class frmKhachHang : Form
    {
        DataTable dtKhachHang;
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            txbMaKH.Enabled = false;
            btnLuu.Enabled = false;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MAKH, TENKH, SODT FROM KHACHHANG";
            dtKhachHang = Class.Functions.GetDataToDataTable(sql);
            dgvKhachHang.DataSource = dtKhachHang;
            dgvKhachHang.Columns[0].HeaderText = "Mã khách hàng";
            dgvKhachHang.Columns[1].HeaderText = "Tên khách hàng";
            dgvKhachHang.Columns[2].HeaderText = "Mã loại khách hàng";
            /*dgvKhachHang.Columns[0].Width = 100;
            dgvKhachHang.Columns[1].Width = 300;
            dgvKhachHang.Columns[2].Width = 300;
            dgvKhachHang.Columns[3].Width = 300;*/
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void dgvKhachHang_Click(object sender, EventArgs e)
        {
            
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbMaKH.Focus();
                return;
            }
            if (dtKhachHang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txbMaKH.Text = dgvKhachHang.CurrentRow.Cells["MAKH"].Value.ToString();
            txbTenKH.Text = dgvKhachHang.CurrentRow.Cells["TENKH"].Value.ToString();
            txbSoDT.Text = dgvKhachHang.CurrentRow.Cells["SODT"].Value.ToString();
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
            txbMaKH.Enabled = true;
            txbMaKH.Focus();
            ResetValue();
        }

        private void ResetValue()
        {
            txbSoDT.Text = "";
            txbMaKH.Text = "";
            txbTenKH.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql; 
            if (txbMaKH.Text.Trim().Length == 0) 
            {
                MessageBox.Show("Bạn phải nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbMaKH.Focus();
                return;
            }
            if (txbTenKH.Text.Trim().Length == 0) 
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbTenKH.Focus();
                return;
            }
            if (txbSoDT.Text.Trim().Length == 0) 
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbSoDT.Focus();
                return;
            }
         

            sql = "Select MAKH From KhachHang where MAKH='" + txbMaKH.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã khách hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbMaKH.Focus();
                return;
            }
            
            sql = "INSERT INTO KhachHang VALUES('" + txbMaKH.Text + "',N'" + txbTenKH.Text + "','" + txbSoDT.Text + "')";
            Class.Functions.RunSQL(sql); 
            LoadDataGridView(); 
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txbMaKH.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            String sql;
            if(dtKhachHang.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txbMaKH.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txbTenKH.Text.Trim().Length == 0) 
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbTenKH.Focus();
                return;
            }
            if (txbSoDT.Text.Trim().Length == 0) 
            {
                MessageBox.Show("Bạn phải nhập mã loại khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbSoDT.Focus();
                return;
            }
            

            sql = "UPDATE KhachHang SET TENKH = N'" + txbTenKH.Text + "', SODT = '" + txbSoDT.Text + "' WHERE MAKH = '" + txbMaKH.Text + "'" ;
            Class.Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();
            btnHuy.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            String sql;
            if (dtKhachHang.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txbMaKH.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "DELETE KhachHang WHERE MAKH = '" + txbMaKH.Text + "'";
           
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
            txbMaKH.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace VangBacDaQuy.form
{
    public partial class frmTraCuuPhieuDichVu : Form
    {
        DataTable dtTraCuu;
        public frmTraCuuPhieuDichVu()
        {

            InitializeComponent();
        }

        private void frmTraCuuPhieuDichVu_Load(object sender, EventArgs e)
        {
            txbTenKH.ReadOnly = true;
            btnXoaPhieu.Enabled = false;
            Class.Functions.FillCombo("SELECT MAKH, TENKH FROM KHACHHANG", cboMaKH, "MAKH", "MAKH");
            Class.Functions.FillCombo("SELECT SOPHIEU FROM PHIEUDICHVU", cboSoPhieu, "SOPHIEU", "SOPHIEU");
            cboMaKH.Text = "";
            cboSoPhieu.Text = "";
            dgvTraCuuPhieuDichVu.DataSource = null;
        }

        private void LoadDataGridView()
        {
            dgvTraCuuPhieuDichVu.Columns[0].HeaderText = "Số phiếu";
            dgvTraCuuPhieuDichVu.Columns[1].HeaderText = "Ngày lập";
            dgvTraCuuPhieuDichVu.Columns[2].HeaderText = "Mã khách hàng";
            dgvTraCuuPhieuDichVu.Columns[3].HeaderText = "Khách hàng";
            dgvTraCuuPhieuDichVu.Columns[4].HeaderText = "Tổng tiền";
            dgvTraCuuPhieuDichVu.Columns[5].HeaderText = "Trả trước";
            dgvTraCuuPhieuDichVu.Columns[6].HeaderText = "Còn lại";
            dgvTraCuuPhieuDichVu.Columns[7].HeaderText = "Trạng thái";

            dgvTraCuuPhieuDichVu.Columns[0].Width = 100;
            dgvTraCuuPhieuDichVu.Columns[1].Width = 100;
            dgvTraCuuPhieuDichVu.Columns[2].Width = 100;
            dgvTraCuuPhieuDichVu.Columns[3].Width = 100;
            dgvTraCuuPhieuDichVu.Columns[4].Width = 100;
            dgvTraCuuPhieuDichVu.Columns[5].Width = 100;
            dgvTraCuuPhieuDichVu.Columns[6].Width = 100;
            dgvTraCuuPhieuDichVu.Columns[7].Width = 100;

            dgvTraCuuPhieuDichVu.AllowUserToAddRows = false;
            dgvTraCuuPhieuDichVu.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            if (cboMaKH.Text == "")
            {
                txbTenKH.Text = "";
            }
            sql = "SELECT TENKH FROM KHACHHANG WHERE MAKH = '" + cboMaKH.SelectedValue + "'";
            txbTenKH.Text = Class.Functions.GetFieldValues(sql);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((cboSoPhieu.Text == "") && (cboMaKH.Text == "") && dtmNgayLap.Text == "")
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            sql = "SELECT SOPHIEU, NGAYLAP, A.MAKH, TENKH, TONGTIEN, TIENTRATRUOC, TIENCONLAI, TINHTRANG FROM PHIEUDICHVU AS A, KHACHHANG AS B WHERE A.MAKH = B.MAKH AND 1=1";

            if (cboSoPhieu.Text != "")
                sql = sql + " AND SOPHIEU like N'%" + cboSoPhieu.Text + "%'";
            if (dtmNgayLap.Text != "")
            {
                sql = sql + " AND YEAR(NGAYLAP) =" + dtmNgayLap.Value.Year;
                sql = sql + " AND MONTH(NGAYLAP) =" + dtmNgayLap.Value.Month;
                sql = sql + " AND DAY(NGAYLAP) =" + dtmNgayLap.Value.Day;
            }
            if (cboMaKH.Text != "")
                sql = sql + " AND A.MAKH like N'%" + cboMaKH.Text + "%'";

            dtTraCuu = Class.Functions.GetDataToDataTable(sql);
            if (dtTraCuu.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có " + dtTraCuu.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvTraCuuPhieuDichVu.DataSource = dtTraCuu;
            LoadDataGridView();
            Reset();
        }

        private void dgvTraCuuPhieuDichVu_DoubleClick(object sender, EventArgs e)
        {

            string sophieu;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sophieu = dgvTraCuuPhieuDichVu.CurrentRow.Cells["SOPHIEU"].Value.ToString();
                //frmPhieuDichVu frm = new frmPhieuDichVu(); // chỗ này là cần đối số
                //frm.txbSoPhieu.Text = sophieu;
                //frm.StartPosition = FormStartPosition.CenterParent;
               // frm.ShowDialog();

            }

        }

        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            String sql;
            if (MessageBox.Show("Bạn có muốn xóa phiếu dịch vụ " + cboSoPhieu.Text + " không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE CHITIETPHIEUDICHVU WHERE SOPHIEU LIKE N'" + cboSoPhieu.Text + "'";
                sql = sql + "DELETE PHIEUDICHVU WHERE SOPHIEU LIKE N'" + cboSoPhieu.Text + "'";

                Class.Functions.RunSQL(sql);
                
                MessageBox.Show("Bạn đã xóa thành công phiếu dịch vụ " + cboSoPhieu.Text + "!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvTraCuuPhieuDichVu.DataSource = null;
                Reset();
            }
            
        }

        private void dgvTraCuuPhieuDichVu_Click(object sender, EventArgs e)
        {
            String sql;
            if (dtTraCuu == null) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dtTraCuu.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            cboSoPhieu.Text = dgvTraCuuPhieuDichVu.CurrentRow.Cells["SOPHIEU"].Value.ToString();
            dtmNgayLap.Text = dgvTraCuuPhieuDichVu.CurrentRow.Cells["NGAYLAP"].Value.ToString();
            txbTenKH.Text = dgvTraCuuPhieuDichVu.CurrentRow.Cells["TENKH"].Value.ToString();
            sql = "SELECT MAKH FROM PHIEUDICHVU WHERE SOPHIEU like N'" + cboSoPhieu.Text + "'";
            cboMaKH.Text = Class.Functions.GetFieldValues(sql);

            btnXoaPhieu.Enabled = true;
        }

        private void Reset()
        {
            cboMaKH.Text = "";
            cboSoPhieu.Text = "";
            txbTenKH.Text = "";
            btnXoaPhieu.Enabled = false;
        }

        private void txbTenKH_Click(object sender, EventArgs e)
        {
            btnXoaPhieu.Enabled = false;
        }

        private void cboMaKH_Click(object sender, EventArgs e)
        {
            btnXoaPhieu.Enabled = false;
        }

        private void cboSoPhieu_Click(object sender, EventArgs e)
        {
            btnXoaPhieu.Enabled = false;
        }

        private void dtmNgayLap_Enter(object sender, EventArgs e)
        {
            btnXoaPhieu.Enabled = false;
        }
    }
}

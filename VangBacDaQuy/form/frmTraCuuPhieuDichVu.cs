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
    public partial class frmTraCuuPhieuDichVu : Form
    {
        DataTable dtTraCuu;
        public frmTraCuuPhieuDichVu()
        {
            
            InitializeComponent();
        }

        private void frmTraCuuPhieuDichVu_Load(object sender, EventArgs e)
        {
            dgvTraCuuPhieuDichVu.DataSource = null;
            //LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            
            dgvTraCuuPhieuDichVu.Columns[0].HeaderText = "Số phiếu";
            dgvTraCuuPhieuDichVu.Columns[1].HeaderText = "Ngày lập";
            dgvTraCuuPhieuDichVu.Columns[2].HeaderText = "Khách hàng";
            dgvTraCuuPhieuDichVu.Columns[3].HeaderText = "Tổng tiền";
            dgvTraCuuPhieuDichVu.Columns[4].HeaderText = "Trả trước";
            dgvTraCuuPhieuDichVu.Columns[5].HeaderText = "Còn lại";
            dgvTraCuuPhieuDichVu.Columns[6].HeaderText = "Trạng thái";

            dgvTraCuuPhieuDichVu.Columns[0].Width = 100;
            dgvTraCuuPhieuDichVu.Columns[1].Width = 100;
            dgvTraCuuPhieuDichVu.Columns[2].Width = 100;
            dgvTraCuuPhieuDichVu.Columns[3].Width = 100;
            dgvTraCuuPhieuDichVu.Columns[4].Width = 100;
            dgvTraCuuPhieuDichVu.Columns[5].Width = 100;
            dgvTraCuuPhieuDichVu.Columns[6].Width = 100;

            dgvTraCuuPhieuDichVu.AllowUserToAddRows = false;
            dgvTraCuuPhieuDichVu.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txbMaSp_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvTraCuuPhieuDichVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

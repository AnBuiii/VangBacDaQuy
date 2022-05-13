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
    public partial class frmLapBaoCaoTonKho : Form
    {
        DataTable dtTonKho;
        public frmLapBaoCaoTonKho()
        {
            InitializeComponent();
        }

        private void frmLapBaoCaoTonKho_Load(object sender, EventArgs e)
        {

            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = " SELECT TENSP, TONDAU, SLMUA, SLBAN, TONCUOI, DONVITINH FROM CHITIETPHIEUBAOCAOTONKHO, SANPHAM, LOAISANPHAM WHERE CHITIETPHIEUBAOCAOTONKHO.MASP = SANPHAM.MASP AND SANPHAM.MALOAISP = LOAISANPHAM.MALOAISP ";
            dtTonKho = Class.Functions.GetDataToDataTable(sql);
            dgvBaoCaoTonKho.DataSource = dtTonKho;

            dgvBaoCaoTonKho.Columns[0].HeaderText = "Sản phẩm";
            dgvBaoCaoTonKho.Columns[1].HeaderText = "Tồn đầu";
            dgvBaoCaoTonKho.Columns[2].HeaderText = "Số lượng mua vào";
            dgvBaoCaoTonKho.Columns[3].HeaderText = "Số lượng bán ra";
            dgvBaoCaoTonKho.Columns[4].HeaderText = "Tồn cuối";
            dgvBaoCaoTonKho.Columns[5].HeaderText = "Đơn vị tính";

            dgvBaoCaoTonKho.Columns[0].Width = 100;
            dgvBaoCaoTonKho.Columns[1].Width = 100;
            dgvBaoCaoTonKho.Columns[2].Width = 100;
            dgvBaoCaoTonKho.Columns[3].Width = 100;
            dgvBaoCaoTonKho.Columns[4].Width = 100;
            dgvBaoCaoTonKho.Columns[5].Width = 100;

            dgvBaoCaoTonKho.AllowUserToAddRows = false;
            dgvBaoCaoTonKho.EditMode = DataGridViewEditMode.EditProgrammatically;

        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvBaoCaoTonKho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}



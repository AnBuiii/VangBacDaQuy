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
    public partial class frmLapBaoCaoTonKho : Form
    {
        DataTable dtTonKho;
        public frmLapBaoCaoTonKho()
        {
            InitializeComponent();
        }

        private void frmLapBaoCaoTonKho_Load(object sender, EventArgs e)
        {
            btnInBaoCao.Enabled = false;
            dgvBaoCaoTonKho.DataSource = null;
            Class.Functions.FillCombo("SELECT distinct NAM FROM PHIEUBAOCAOTONKHO", cbonam, "NAM", "NAM");
            Class.Functions.FillCombo("SELECT distinct THANG FROM PHIEUBAOCAOTONKHO", cboThang, "THANG", "THANG");
        }

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            string sql;
            if ((cboThang.Text=="") || (cbonam.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            sql = "SELECT TENSP, TONDAU, SLMUA, SLBAN, TONCUOI, DONVITINH FROM PHIEUBAOCAOTONKHO, CHITIETPHIEUBAOCAOTONKHO, SANPHAM, LOAISANPHAM WHERE CHITIETPHIEUBAOCAOTONKHO.SOPHIEU = PHIEUBAOCAOTONKHO.SOPHIEU AND CHITIETPHIEUBAOCAOTONKHO.MASP = SANPHAM.MASP AND SANPHAM.MALOAISP = LOAISANPHAM.MALOAISP ";

            if (cboThang.Text != "")
                sql = sql + " AND THANG =" + cboThang.Text;
            if (cbonam.Text != "")
                sql = sql + " AND NAM =" + cbonam.Text;

            dtTonKho = Class.Functions.GetDataToDataTable(sql);
            if (dtTonKho.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvBaoCaoTonKho.DataSource = dtTonKho;
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
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
            btnInBaoCao.Enabled = true;
        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; 
            COMExcel.Worksheet exSheet; 
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tbchung, tbchitiet;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];

            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman"; //Font chữ
            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3;
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "PHIẾU BÁO CÁO TỒN KHO";

            sql = "SELECT * FROM PHIEUBAOCAOTONKHO as a WHERE a.THANG = N'" + cboThang.Text + "' AND a.NAM = N'" + cbonam.Text + "'";
            tbchung = Class.Functions.GetDataToDataTable(sql);
            exRange.Range["B4:E6"].Font.Size = 12;
            exRange.Range["B4:E6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
            exRange.Range["B4:B4"].Font.Bold = true;
            exRange.Range["B4:B4"].Value = "Số phiêu:";
            exRange.Range["C4:E4"].MergeCells = true;
            exRange.Range["C4:E4"].Value = tbchung.Rows[0][0].ToString();
            exRange.Range["B5:B5"].Value = "Thang:";
            exRange.Range["B5:B5"].Font.Bold = true;
            exRange.Range["C5:E5"].MergeCells = true;
            exRange.Range["C5:E5"].Value = tbchung.Rows[0][1].ToString();
            exRange.Range["B6:B6"].Value = "Nam:";
            exRange.Range["B6:B6"].Font.Bold = true;
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tbchung.Rows[0][2].ToString();

            sql = "SELECT TENSP, TONDAU, SLMUA, SLBAN, TONCUOI, DONVITINH FROM PHIEUBAOCAOTONKHO as a, CHITIETPHIEUBAOCAOTONKHO, SANPHAM, LOAISANPHAM WHERE CHITIETPHIEUBAOCAOTONKHO.SOPHIEU = a.SOPHIEU AND CHITIETPHIEUBAOCAOTONKHO.MASP = SANPHAM.MASP AND a.THANG = N'" + cboThang.Text + "' AND a.NAM = N'" + cbonam.Text + "' AND SANPHAM.MALOAISP = LOAISANPHAM.MALOAISP";
            tbchitiet = Class.Functions.GetDataToDataTable(sql); 
            exRange.Range["A8:G8"].Font.Bold = true;
            exRange.Range["A8:G8"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A8:G8"].ColumnWidth = 12;
            exRange.Range["A8:A8"].Value = "STT";
            exRange.Range["B8:B8"].Value = "Tên sản phẩm";
            exRange.Range["C8:C8"].Value = "Tồn đầu";
            exRange.Range["D8:D8"].Value = "Số lượng mua";
            exRange.Range["E8:E8"].Value = "Số lượng bán";
            exRange.Range["F8:F8"].Value = "Tồn cuối";
            exRange.Range["G8:G8"].Value = "Đơn vị tính";
            for (hang = 0; hang < tbchitiet.Rows.Count; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 9
                exSheet.Cells[1][hang + 9] = hang + 1;
                for (cot = 0; cot < tbchitiet.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 9
                {
                    exSheet.Cells[cot + 2][hang + 9] = tbchitiet.Rows[hang][cot].ToString();
                    if (cot == 3) exSheet.Cells[cot + 2][hang + 9] = tbchitiet.Rows[hang][cot].ToString() + "%";
                }
            }

            exSheet.Name = "Báo cáo tồn kho";
            exApp.Visible = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}



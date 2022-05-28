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
    public partial class frmPhieuBanHang : Form
    {
        DataTable dtChiTietPhieuBanHang;
        public frmPhieuBanHang()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            int sl, slxoa;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
            {
                string sql = "SELECT MASP, SOLUONG FROM CHITIETPHIEUBANHANG WHERE SOPHIEU = '" + txbSoPhieu.Text + "'";
                DataTable tbSP = Class.Functions.GetDataToDataTable(sql);
                for (int row = 0; row <  tbSP.Rows.Count ; row++)
                {
                    // Cập nhật số lượng
                    sql = "SELECT SOLUONG FROM SANPHAM WHERE MASP = '" + tbSP.Rows[row][0].ToString() + "'";
                    sl = Convert.ToInt32(Class.Functions.GetFieldValues(sql));
                    MessageBox.Show("SELECT SL");
                    slxoa = Convert.ToInt32(tbSP.Rows[row][1].ToString());
                    sl += slxoa;
                    sql = "UPDATE SANPHAM SET SOLUONG = " + sl + " WHERE MASP = '" + tbSP.Rows[row][0].ToString() + "'";
                    Class.Functions.RunSQL(sql);
                    MessageBox.Show("UPDATE SL");
                }

                //Xóa chi tiết phiếu
                sql = "DELETE CHITIETPHIEUBANHANG WHERE SOPHIEU = '" + txbSoPhieu.Text + "'";
                Class.Functions.RunSQL(sql);

                //Xóa phiếu bán hàng
                sql = "DELETE PHIEUBANHANG WHERE SOPHIEU = '" + txbSoPhieu.Text + "'";
                Class.Functions.RunSQL(sql);
                ResetValues();
                LoadDataGridView();
                btnXoa.Enabled = false;
                btnIn.Enabled = false;
            }
        }

      

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnIn.Enabled = false;
            btnThem.Enabled = false;
            ResetValues();
            txbSoPhieu.Enabled = true;
            txbSoPhieu.Text = "";
            LoadDataGridView();

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            int sl, slcon;
            double tong;
   
            //nếu mã phiếu chưa tồn tại -> tạo mới 
            sql = "SELECT SOPHIEU FROM PHIEUBANHANG WHERE SOPHIEU = '" + txbSoPhieu.Text + "'";
            if (!Class.Functions.CheckKey(sql))
            {
                if (cbMaKH.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbMaKH.Focus();
                    return;
                }
                sql = "INSERT INTO PHIEUBANHANG VALUES('" + txbSoPhieu.Text + "', '" + cbMaKH.Text + "' , CONVERT(DATETIME, '" + dtpNgaylap.Value.ToString("dd/MM/yyy") + "',103), '" + txbThanhtien.Text +"')" ;
                
                Class.Functions.RunSQL(sql);
            }
            //insert sản phẩm
            if(cbMaSP.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbMaSP.Focus();
                return;
            }
            if(txbSL.Text.Trim().Length == 0 || txbSL.Text == "0")
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbSL.Text = "";
                txbSL.Focus();
                return;
            }
            sql = "SELECT MASP FROM CHITIETPHIEUBANHANG WHERE SOPHIEU = '" + txbSoPhieu.Text + "' AND MASP = '" + cbMaSP.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Sản phẩm này đã có, bạn phải nhập sản phẩm khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValuesHang();
                cbMaSP.Focus();
                return;
            }
            sql = "SELECT SOLUONG FROM SANPHAM WHERE MASP = '" + cbMaSP.SelectedValue + "'";
            sl = Convert.ToInt32(Class.Functions.GetFieldValues(sql));
            if (sl < Convert.ToInt32(txbSL.Text))
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbSL.Text = "";
                txbSL.Focus();
                return;
            }
            sql = "INSERT INTO CHITIETPHIEUBANHANG VALUES ('" + cbMaSP.SelectedValue + "','" + txbSoPhieu.Text + "'," + txbSL.Text + ")";
            Class.Functions.RunSQL(sql);
            LoadDataGridView();
            //update số lượng còn lại của sản phẩm
            slcon = sl - Convert.ToInt32(txbSL.Text);
            sql = "UPDATE SANPHAM SET SOLUONG  = " + slcon + "WHERE MASP = '" + cbMaSP.SelectedValue + "'";
            Class.Functions.RunSQL(sql);
            //update tổng tiền
            sql = "SELECT TONGTIEN FROM PHIEUBANHANG WHERE SOPHIEU = '" + txbSoPhieu.Text + "'";
            tong = Convert.ToDouble(Class.Functions.GetFieldValues(sql));
            tong += Convert.ToDouble(txbThanhtien.Text);
            sql = "UPDATE PHIEUBANHANG SET TONGTIEN = " + tong + " WHERE SOPHIEU = '" + txbSoPhieu.Text + "'";
            Class.Functions.RunSQL(sql);
            txbTongtien.Text = tong.ToString();
            ResetValuesHang();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnIn.Enabled = true;

        }

        private void ResetValuesHang()
        {
            cbMaSP.Text = "";
            txbSL.Text = "";
            txbThanhtien.Text = "0";
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT SANPHAM.MASP, TENSP, TENLOAISP, DONGIA, CHITIETPHIEUBANHANG.SOLUONG, CHITIETPHIEUBANHANG.SOLUONG*DONGIA AS THANHTIEN" +
                   " FROM SANPHAM, CHITIETPHIEUBANHANG, LOAISANPHAM" +
                    " WHERE SANPHAM.MASP = CHITIETPHIEUBANHANG.MASP AND SANPHAM.MALOAISP = LOAISANPHAM.MALOAISP AND SOPHIEU = '" + txbSoPhieu.Text + "'";
            //sql = "SELECT MASP, TENSP, MALOAISP, DONGIA FROM SANPHAM";
            dtChiTietPhieuBanHang = Class.Functions.GetDataToDataTable(sql);
            dgvPhieuBanHang.DataSource = dtChiTietPhieuBanHang;
            dgvPhieuBanHang.Columns[0].HeaderText = "Mã sản phẩm";
            dgvPhieuBanHang.Columns[1].HeaderText = "Tên sản phẩm";
            dgvPhieuBanHang.Columns[2].HeaderText = "Loại sản phẩm";
            dgvPhieuBanHang.Columns[3].HeaderText = "Đơn giá";
            dgvPhieuBanHang.Columns[4].HeaderText = "Số lượng";
            dgvPhieuBanHang.Columns[5].HeaderText = "Thành tiền";
            dgvPhieuBanHang.AllowUserToAddRows = false;
            dgvPhieuBanHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void frmPhieuBanHang_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnIn.Enabled = false;
            txbSoPhieu.Enabled = false;
            txbTenKH.ReadOnly = true;
            txbTenSP.ReadOnly = true;
            txbDongia.ReadOnly = true;
            txbThanhtien.ReadOnly = true;
            txbTongtien.Text = "0";
            Class.Functions.FillCombo("SELECT MAKH, TENKH FROM KHACHHANG", cbMaKH, "MAKH", "MAKH");
            Class.Functions.FillCombo("SELECT MASP, TENSP FROM SANPHAM", cbMaSP, "MASP", "MASP");
            cbMaKH.SelectedIndex = -1;
            cbMaSP.SelectedIndex = -1; 
            if (txbSoPhieu.Text != "")
            {
                LoadInfoPhieu();
                btnXoa.Enabled=true;
                btnIn.Enabled=true;
            }
            LoadDataGridView();
        }

        private void LoadInfoPhieu()
        {
            string sql;
            sql = "SELECT NGAYLAP FROM PHIEUBANHANG WHERE SOPHIEU = '" + txbSoPhieu.Text + "'";
            dtpNgaylap.Value = DateTime.Parse(Class.Functions.GetFieldValues(sql));
            sql = "SELECT MAKH FROM PHIEUBANHANG WHERE SOPHIEU = '" + txbSoPhieu.Text + "'";
            cbMaKH.Text = Class.Functions.GetFieldValues(sql);
            sql = "SELECT TONGTIEN FROM PHIEUBANHANG WHERE SOPHIEU = '" + txbSoPhieu.Text + "'";
            txbTongtien.Text = Class.Functions.GetFieldValues(sql);
        }
        private void ResetValues()
        {
            txbSoPhieu.Text = "";
            dtpNgaylap.Value = DateTime.Now;
            cbMaKH.Text = "";
            txbTongtien.Text = "0";
            cbMaSP.Text = "";
            txbSL.Text = "";
            txbThanhtien.Text = "0";
        }

        private void dgvPhieuBanHang_DoubleClick(object sender, EventArgs e)
        {
            string masp, sql;
            Double ThanhTienxoa, tong;
            int slXoa, sl;
            if (dtChiTietPhieuBanHang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng 
                masp = dgvPhieuBanHang.CurrentRow.Cells["MASP"].Value.ToString();
                slXoa = Convert.ToInt32(dgvPhieuBanHang.CurrentRow.Cells["SOLUONG"].Value.ToString());
                ThanhTienxoa = Convert.ToDouble(dgvPhieuBanHang.CurrentRow.Cells["THANHTIEN"].Value.ToString());
                sql = "DELETE CHITIETPHIEUBANHANG WHERE SOPHIEU = '" + txbSoPhieu.Text + "' AND MASP = '" + masp + "'";
                Class.Functions.RunSQL(sql);
                // Cập nhật số lượng
                sql = "SELECT SOLUONG FROM SANPHAM WHERE MASP = '" + masp + "'";
                sl = Convert.ToInt32(Class.Functions.GetFieldValues(sql));
                sl+= slXoa;
                sql = "UPDATE SANPHAM SET SOLUONG =" + sl + " WHERE MASP = '" + masp + "'";
                Class.Functions.RunSQL(sql);
                sql = "SELECT TONGTIEN FROM PHIEUBANHANG WHERE SOPHIEU = '" + txbSoPhieu.Text + "'";
                // Cập nhật lại tổng tiền cho hóa đơn bán
                tong = Convert.ToDouble(Class.Functions.GetFieldValues(sql));
                tong -= ThanhTienxoa;
                sql = "UPDATE PHIEUBANHANG SET TONGTIEN =" + tong + " WHERE SOPHIEU = '" + txbSoPhieu.Text + "'";
                Class.Functions.RunSQL(sql);
                txbTongtien.Text = tong.ToString();
                LoadDataGridView();
            }
        }
        private void cbMaKH_TextChanged(object sender, EventArgs e)
        {
            string sql;
            if (cbMaKH.Text == "")
            {
                txbTenKH.Text = "";
            }
            sql = "SELECT TENKH FROM KHACHHANG WHERE MAKH = '" + cbMaKH.SelectedValue + "'";
            txbTenKH.Text = Class.Functions.GetFieldValues(sql);
        }

        private void cbMaSP_TextChanged(object sender, EventArgs e)
        {
            string sql;
            if (cbMaSP.Text == "")
            {
                txbTenSP.Text = "";
                txbDongia.Text = "";
                txbLoaiSP.Text = "";
            }
            sql = "SELECT TENSP FROM SANPHAM WHERE MASP = '" + cbMaSP.SelectedValue + "'";
            txbTenSP.Text = Class.Functions.GetFieldValues(sql);
            sql = "SELECT DONGIA FROM SANPHAM WHERE MASP = '" + cbMaSP.SelectedValue + "'";
            txbDongia.Text = Class.Functions.GetFieldValues(sql);
            sql = "SELECT MALOAISP FROM SANPHAM WHERE MASP = '" + cbMaSP.SelectedValue + "'";
            txbLoaiSP.Text = Class.Functions.GetFieldValues(sql);
            // cập nhật lại thành tiền

        }

        private void txbSL_TextChanged(object sender, EventArgs e)
        {
            double sl, dg;
            if (txbSL.Text == "") sl = 0;
            else sl = Convert.ToDouble(txbSL.Text);
            if (txbDongia.Text == "") dg = 0;
            else dg = Convert.ToDouble(txbDongia.Text);
            txbThanhtien.Text = (sl * dg).ToString();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
         
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int row = 0, column = 0;
            DataTable tbPBH, tbSP;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman"; //Font chữ
            /*
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Shop B.A.";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Chùa Bộc - Hà Nội";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (04)38526419";
            */
            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3;
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "PHIẾU BÁN HÀNG";

            sql = "SELECT SOPHIEU, NGAYLAP, TONGTIEN, TENKH FROM PHIEUBANHANG, KHACHHANG WHERE PHIEUBANHANG.MAKH = KHACHHANG.MAKH AND PHIEUBANHANG.SOPHIEU = '" + txbSoPhieu.Text +"'";
            tbPBH = Class.Functions.GetDataToDataTable(sql);
            exRange.Range["B4:C6"].Font.Size = 12;
            exRange.Range["B4:B4"].Value = "Mã hóa đơn:";
            exRange.Range["C4:E4"].MergeCells = true;
            exRange.Range["C4:E4"].Value = tbPBH.Rows[0][0].ToString();
            exRange.Range["B5:B5"].Value = "Khách hàng:";
            exRange.Range["C5:E5"].MergeCells = true;
            exRange.Range["C5:E5"].Value = tbPBH.Rows[0][3].ToString();
            
            sql = "SELECT TENSP, TENLOAISP,  CHITIETPHIEUBANHANG.SOLUONG, DONGIA, CHITIETPHIEUBANHANG.SOLUONG * DONGIA FROM SANPHAM, LOAISANPHAM, CHITIETPHIEUBANHANG WHERE SANPHAM.MALOAISP = LOAISANPHAM.MALOAISP AND SANPHAM.MASP = CHITIETPHIEUBANHANG.MASP AND CHITIETPHIEUBANHANG.SOPHIEU =  '" + txbSoPhieu.Text + "'";
            tbSP = Class.Functions.GetDataToDataTable(sql); //Tạo dòng tiêu đề bảng
            exRange.Range["A8:F8"].Font.Bold = true;
            exRange.Range["A8:F8"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C8:F8"].ColumnWidth = 12;
            exRange.Range["A8:A8"].Value = "STT";
            exRange.Range["B8:B8"].Value = "Tên sản phẩm";
            exRange.Range["C8:C8"].Value = "Tên loại sản phẩm";
            exRange.Range["D8:D8"].Value = "Số lượng";
            exRange.Range["E8:E8"].Value = "Đơn giá";
            exRange.Range["F8:F8"].Value = "Thành tiền";
            for (row = 0; row < tbSP.Rows.Count; row++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][row + 9] = row + 1;
                for (column = 0; column < tbSP.Columns.Count; column++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12
                {
                    exSheet.Cells[column + 2][row + 9] = tbSP.Rows[row][column].ToString();
                }
            }
            exRange = exSheet.Cells[column][row + 11];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[column + 1][row + 11];
            exRange.Font.Bold = true;
            exRange.Value2 = tbPBH.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][row + 12]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            //exRange.Range["A1:F1"].Value = "Bằng chữ: " + Class.Functions.ChuyenSoSangChu(tbPBH.Rows[0][2].ToString());
            exRange = exSheet.Cells[4][row + 14]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tbPBH.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true; 
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if (cbSophieu.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbSophieu.Focus();
                return;
            }
            txbSoPhieu.Text = cbSophieu.Text;
            LoadInfoPhieu();
            LoadDataGridView();
            btnXoa.Enabled = true;
            btnLuu.Enabled = true;
            btnIn.Enabled = true;
            cbSophieu.SelectedIndex = -1;
        }

        private void txbSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                    e.Handled = false;
                else e.Handled = true;
            }
        }

        private void cbSophieu_DropDown(object sender, EventArgs e)
        {
            String sql;
            sql = "SELECT SOPHIEU FROM PHIEUBANHANG";
            Class.Functions.FillCombo(sql, cbSophieu, "SOPHIEU", "SOPHIEU");
            cbMaSP.SelectedIndex = -1;
        }
    }
}

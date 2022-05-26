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
    public partial class frmPhieuDichVu : Form
    {

        DataTable dtChiTietPhieuDichVu;
        String idKH;
        String idPH;
        Boolean isSaved = false;
        public frmPhieuDichVu()
        {
            InitializeComponent();
            //tạo key phiếu dịch vụ
            String sql = "SELECT [dbo].autoKey_PHIEUDICHVU()";
            txbSoPhieu.Text = Class.Functions.GetFieldValues(sql);
        }

        public frmPhieuDichVu(string idKH, string idPH)
        {
            this.idKH = idKH;
            this.idPH = idPH;
            isSaved = true;
            InitializeComponent();
        }
        private void LoadDataGridView()
        {
            dgvPhieuDichVu.Columns[0].HeaderText = "STT";
            dgvPhieuDichVu.Columns[1].HeaderText = "Mã dịch vụ";
            dgvPhieuDichVu.Columns[2].HeaderText = "Loại dịch vụ";
            dgvPhieuDichVu.Columns[3].HeaderText = "Đơn giá dịch vụ";
            dgvPhieuDichVu.Columns[4].HeaderText = "Đơn giá được tính";
            dgvPhieuDichVu.Columns[5].HeaderText = "Số lượng";
            dgvPhieuDichVu.Columns[6].HeaderText = "Thành tiền";
            dgvPhieuDichVu.Columns[7].HeaderText = "Trả trước";
            dgvPhieuDichVu.Columns[8].HeaderText = "Còn lại";
            dgvPhieuDichVu.Columns[9].HeaderText = "Ngày giao";
            dgvPhieuDichVu.Columns[10].HeaderText = "Tình trạng";
            dgvPhieuDichVu.Columns[11].HeaderText = "Ghi chú";
            dgvPhieuDichVu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPhieuDichVu.AllowUserToAddRows = false;
            dgvPhieuDichVu.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void frmPhieuDichVu_Load(object sender, EventArgs e)
        {
            
            txbSoPhieu.ReadOnly = true;
            txbDonGia.ReadOnly = true;
            txbConLai.ReadOnly = true;
            txbConLai.ReadOnly = true;
            txbThanhTien.ReadOnly = true;
            dtpNgayGiao.Text = "";
            combxTinhTrang.Text = "";
            txbTongTien.ReadOnly = true;
            txbTongTraTruoc.ReadOnly = true;
            txbTongConLai.ReadOnly = true;
            txbTongTien.Text = "0";
            txbTongTraTruoc.Text = "0";
            txbTongConLai.Text = "0";
          
          
            Class.Functions.FillCombo("SELECT MADV, TENDV FROM DICHVU", cmbxLoaiDichVu, "MADV", "TENDV");
            cmbxLoaiDichVu.Text = "";
            txbDonGia.Text = "";
            LoadDataGridView();
            DataTable dt = new DataTable();
          
            
        }

        private void cmbxLoaiDichVu_TextChanged(object sender, EventArgs e)
        {
          
                String sql = "SELECT DONGIA FROM DICHVU WHERE MADV = '" + cmbxLoaiDichVu.SelectedValue.ToString() + "'";

                // MessageBox.Show(Class.Functions.GetFieldValues(sql));
                txbDonGia.Text = Class.Functions.GetFieldValues(sql);
            
          
        }

        private void txbSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
        

             if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                 e.Handled = false;
             else e.Handled = true;
        }

        private void txbSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                    e.Handled = false;
                else e.Handled = true;
            }
        }

        private void txbGiaDuocTinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            
                if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                    e.Handled = false;
                else e.Handled = true;
            
        }

        private void txbTraTruoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;

        }


        private void txbGiaDuocTinh_TextChanged(object sender, EventArgs e)
        {
            if (txbGiaDuocTinh.Text != "" && txbSoLuong.Text != "")
            {   
               
                
                long totalMoney = Convert.ToInt64(txbGiaDuocTinh.Text) * Convert.ToInt64(txbSoLuong.Text);
                txbThanhTien.Text = totalMoney.ToString();
                //catch

                if(txbTraTruoc.Text != "")
                {
                    long leftMoney = Convert.ToInt64(txbThanhTien.Text) - Convert.ToInt64(txbTraTruoc.Text);
                    txbConLai.Text = leftMoney.ToString();
                }
                else
                {
                    txbConLai.Text = txbThanhTien.Text;
                }
            }
            else
            {
                txbThanhTien.Text = "0";
                txbConLai.Text = "0";
            }
        }

        private void txbSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (txbGiaDuocTinh.Text != "" && txbSoLuong.Text != "")
            {
                long totalMoney = Convert.ToInt64(txbGiaDuocTinh.Text) * Convert.ToInt64(txbSoLuong.Text);
                txbThanhTien.Text = totalMoney.ToString();

                if (txbTraTruoc.Text != "")
                {
                    long leftMoney = Convert.ToInt64(txbThanhTien.Text) - Convert.ToInt64(txbTraTruoc.Text);
                    txbConLai.Text = leftMoney.ToString();
                }
                else
                {
                    txbConLai.Text = txbThanhTien.Text;
                }
            }
            else
            {
                txbThanhTien.Text = "0";
                txbConLai.Text = "0";
            }

        }

        private void txbTraTruoc_TextChanged(object sender, EventArgs e)
        {
            if(txbTraTruoc.Text != "")
            {
                long totalMoney = Convert.ToInt64(txbThanhTien.Text) - Convert.ToInt64(txbTraTruoc.Text);
                txbConLai.Text = totalMoney.ToString();
            }
            else
            {
                txbConLai.Text = txbThanhTien.Text;
            }
          
        }

        Boolean checkFieldChitTietPhieu()
        {
            if (cmbxLoaiDichVu.Text == "")
            {
                MessageBox.Show("Vui lòng chọn loại dịch vụ");
                return false;
            }
            if (txbGiaDuocTinh.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đơn giá được tính");
                return false;
            }
            if (txbSoLuong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số lượng");
                return false;
            }
            if (dtpNgayGiao.Value < dtpNgaylap.Value)
            {
                MessageBox.Show("Ngày giao hàng phải bằng hoặc sau ngày lập phiếu!");
                return false;
            }
            if (txbTraTruoc.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tiền trả trước");
                return false;
            }

            if (combxTinhTrang.Text == "")
            {
                MessageBox.Show("Vui lòng chọn tình trạng giao hàng");
                return false;
            }

            //lấy tham số là phần trăm tiền trả trước từ bảng tham số
            String sql = "SELECT PhanTramTienTraTruoc FROM THAMSO";
            double ptTraTruoc = Convert.ToDouble(Class.Functions.GetFieldValues(sql));
            long traTruoc = Convert.ToInt64(txbTraTruoc.Text);
            long thanhTien = Convert.ToInt64(txbThanhTien.Text);
            if (traTruoc < thanhTien * ptTraTruoc) // Số tiền trả trước của từng loại dịch vụ phải >= (%TienTraTruoc x Thành tiền) của loại dịch vụ đó. 
            {
                MessageBox.Show("Số tiền trả của từng loại dịch vụ phải >= (" +  (ptTraTruoc * 100).ToString() + "% x Thành tiền) của loại dịch vụ đó");
                return false;
            }
            return true;
        
    }
        void resetChonDichVu()
        {
            cmbxLoaiDichVu.Text = "";
            txbDonGia.Text = "";
            txbGiaDuocTinh.Text = "";
            txbSoLuong.Text = "";
            txbThanhTien.Text = "";
            dtpNgayGiao.Text = "";
            txbTraTruoc.Text = "";
            txbConLai.Text = "";
            combxTinhTrang.Text = "";
            richtxbGhiChu.Clear();
        }

        void calSumMoney()
        {
            long sumMoney = Convert.ToInt64(txbTongTien.Text);
            long preMoney = Convert.ToInt64(txbTongTraTruoc.Text); ;
            long leftMoney = 0;

            DataGridViewRow lastRow = dgvPhieuDichVu.Rows[dgvPhieuDichVu.RowCount - 1];
            
                sumMoney += Convert.ToInt64(lastRow.Cells[6].Value.ToString());
                preMoney += Convert.ToInt64(lastRow.Cells[7].Value.ToString());
            
            leftMoney = sumMoney - preMoney; // tổng tiền còn lại = tổng tiền - tổng tiền trả trước

            txbTongTien.Text = sumMoney.ToString();
            txbTongTraTruoc.Text = preMoney.ToString();
            txbTongConLai.Text  = leftMoney.ToString();
           
        }
        private void buttonThem_Click(object sender, EventArgs e)
        {
            if (checkFieldChitTietPhieu())// kiểm tra các text box nhập vào đã hợp lệ chưa
            {
                object[] newRowData = new object[] {(dgvPhieuDichVu.RowCount + 1).ToString(), cmbxLoaiDichVu.SelectedValue, cmbxLoaiDichVu.Text, txbDonGia.Text,  txbGiaDuocTinh.Text, txbSoLuong.Text
                                                     , txbThanhTien.Text, txbTraTruoc.Text, txbConLai.Text  , dtpNgayGiao.Text, combxTinhTrang.Text, richtxbGhiChu.Text
                                                    };

                dgvPhieuDichVu.Rows.Add(newRowData);
                calSumMoney();
                resetChonDichVu();

            } 
        }

        Boolean checkFieldThongTinChung()
        {
            if(txbKhachHang.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng");
                return false;
            } 
            if(txbSDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại");
                return false;
            }
            if(dgvPhieuDichVu.RowCount == 0)
            {
                MessageBox.Show("Vui lòng điền thông tin dịch vụ được sử dụng");
                return false;
            }
            return true;
        }

        Boolean checkKH()
        {
            String sql;
            // kiểm tra xem khách hàng đã từng sử mua hay sử dụng dịch vụ của cửa hàng chưa, nếu chưa thì tạo mới
            sql = "SELECT TENKH, SODT FROM KHACHHANG WHERE TENKH = N'" + txbKhachHang.Text.Trim() + "'"
                + "AND SODT = '" + txbSDT.Text + "'";
            String check = Class.Functions.GetFieldValues(sql);
           
            if (check == "")
            {
                return false;
            }
            return true;
            
        }

        void addKH()
        {
            String sql;
            sql = "INSERT INTO KHACHHANG VALUES([dbo].autoKey_KHACHHANG(), N'" + txbKhachHang.Text.Trim() + "', '" + txbSDT.Text.Trim() + "')";
            Class.Functions.RunSQL(sql);

        }

        String takeIDKH()
        {
            String sql;
            sql = "SELECT MAKH FROM KHACHHANG WHERE TENKH = N'" + txbKhachHang.Text.Trim() + "'" 
                + "AND SODT = '" + txbSDT.Text + "'";
           return Class.Functions.GetFieldValues(sql);

        }

        Boolean checkTrangThai()
        {
            foreach (DataGridViewRow row in dgvPhieuDichVu.Rows)
            {
                if(row.Cells[10].Value.ToString() == "Chưa giao") return false;
            }
            return true;
        }

        void addPHIEUDICHVU()
        {
            String tinhTrang;
            if (checkTrangThai())
            {
                tinhTrang = "Hoàn thành";
            }
            else
            {
                tinhTrang = "Chưa hoàn thành";
            }

            String sql = "INSERT INTO PHIEUDICHVU VALUES('" + txbSoPhieu.Text + "', CONVERT(DATETIME, '" + dtpNgaylap.Value.ToString("dd/MM/yyyy") + "', 103), '"
                            + takeIDKH() + "', '" + txbTongTien.Text + "', '" + txbTongTraTruoc.Text + "', '" + txbTongConLai.Text + "', N'" + tinhTrang +"')";
            Class.Functions.RunSQL (sql);
          
        }

        void addCHITIETPHIEUDICHVU()
        {
            String sql;
            foreach (DataGridViewRow row in dgvPhieuDichVu.Rows)
            {
                sql = "INSERT INTO CHITIETPHIEUDICHVU VALUES('"
                     + row.Cells[1].Value.ToString()
                     + "', '" + txbSoPhieu.Text
                     + "', '" + row.Cells[4].Value.ToString()
                     + "',  " + row.Cells[5].Value.ToString() // int nên k có dấu "'"
                     + ", '" + row.Cells[6].Value.ToString()
                     + "', '" + row.Cells[7].Value.ToString()
                     + "', '" + row.Cells[8].Value.ToString()
                     + "', CONVERT(DATETIME, '" + row.Cells[9].Value.ToString() + "', 103)"
                     + ", N'" + row.Cells[10].Value.ToString()
                      + "', N'" + row.Cells[11].Value.ToString().Trim() + "')";
                //MessageBox.Show(sql);
                Class.Functions.RunSQL(sql);
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            String sql;

            if (checkFieldThongTinChung()) // nếu các thông tin đã hợp lệ
            {
               if (!checkKH()) // nếu khách hàng mới đến lần đầu
                {
                    addKH(); // thêm khách hàng
                }
                 //thêm phiếu dịch vụ vào PHIEUDICHVU
                addPHIEUDICHVU();

                //thêm các  chi tiết phiếu dịch vụ trong dgvPHIEUDICHVU của PHIEUDICHVU vừa tạo vào database
                addCHITIETPHIEUDICHVU();
                MessageBox.Show("Lưu thành công");

            }
          
        }
        private void dgvPhieuDichVu_DoubleClick(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dgvPhieuDichVu.SelectedRows)
            {
                dgvPhieuDichVu.Rows.Remove(item);
            }
           
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
           // int row = 0, column = 0;
          //  DataTable tbPBH, tbSP;
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
            exRange.Range["C2:E2"].Value = "PHIẾU DỊCH VỤ";
           

            // sql = "SELECT SOPHIEU, NGAYLAP, TONGTIEN, TENKH FROM PHIEUBANHANG, KHACHHANG WHERE PHIEUBANHANG.MAKH = KHACHHANG.MAKH AND PHIEUBANHANG.SOPHIEU = '" + txbSoPhieu.Text + "'";
            // tbPBH = Class.Functions.GetDataToDataTable(sql);
            exRange.Range["B4:C6"].Font.Size = 12;
            exRange.Range["B4:B4"].Value = "Số phiếu:";
            exRange.Range["C4:E4"].MergeCells = true;
            exRange.Range["C4:E4"].Value = txbSoPhieu.Text;
            exRange.Range["B5:B5"].Value = "Khách hàng:";
            exRange.Range["C5:E5"].MergeCells = true;
            exRange.Range["C5:E5"].Value = txbKhachHang.Text;
           

            // sql = "SELECT TENSP, TENLOAISP,  CHITIETPHIEUBANHANG.SOLUONG, DONGIA, CHITIETPHIEUBANHANG.SOLUONG * DONGIA FROM SANPHAM, LOAISANPHAM, CHITIETPHIEUBANHANG WHERE SANPHAM.MALOAISP = LOAISANPHAM.MALOAISP AND SANPHAM.MASP = CHITIETPHIEUBANHANG.MASP AND CHITIETPHIEUBANHANG.SOPHIEU =  '" + txbSoPhieu.Text + "'";
            // tbSP = Class.Functions.GetDataToDataTable(sql); //Tạo dòng tiêu đề bảng
            exRange.Range["A8:L8"].Font.Bold = true;
            exRange.Range["A8:L8"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C8:L8"].ColumnWidth = DataGridViewAutoSizeColumnMode.Fill;
            exRange.Range["A8:A8"].Value = "STT";
            exRange.Range["B8:B8"].Value = "Mã dịch vụ";
            exRange.Range["C8:C8"].Value = "Loại dịch vụ";
            exRange.Range["D8:D8"].Value = "Đơn giá dịch vụ";
            exRange.Range["E8:E8"].Value = "Đơn giá được tính";
            exRange.Range["F8:F8"].Value = "Số lượng";
            exRange.Range["G8:G8"].Value = "Thành tiền";
            exRange.Range["H8:H8"].Value = "Trả trước";
            exRange.Range["I8:I8"].Value = "Còn lại";
            exRange.Range["J8:J8"].Value = "Ngày giao";
            exRange.Range["K8:K8"].Value = "Tình trạng";
            exRange.Range["L8:L8"].Value = "Ghi chú";

           /*for (row = 0; row < tbSP.Rows.Count; row++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][row + 9] = row + 1;
                for (column = 0; column < tbSP.Columns.Count; column++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12
                {
                    exSheet.Cells[column + 2][row + 9] = tbSP.Rows[row][column].ToString();
                }
            }*/
          
          /* exRange = exSheet.Cells[column][row + 11];
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
            exSheet.Name = "Hóa đơn nhập";*/
            exApp.Visible = true;
        }
    }
}

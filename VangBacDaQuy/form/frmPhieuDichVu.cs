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
using System.Globalization;

namespace VangBacDaQuy.form
{
    public partial class frmPhieuDichVu : Form
    {

        DataTable dtChiTietPhieuDichVu = new DataTable();
        String idKH = "";
        String idPH = "";
        Boolean isSaved = false; // check xem phiếu này đã được lưu trước đó hay chưa
        Boolean isSaveChanges = true; // nếu mà mở phiếu cũ, đang chỉnh sửa dở mà lỡ tắt thì dùng này để check
        CultureInfo culture = new CultureInfo("en-US"); // chọn vùng để format tiền tệ
        List<DataRow> rowsDeleted = new List<DataRow>();
        List<DataRow> rowsInserted = new List<DataRow>();
        List<DataRow> rowsUpdated = new List<DataRow>();
        int rowIndex = 0; // lấy vị trí để xóa dòng
        public frmPhieuDichVu()
        {
            InitializeComponent();
           
        }

        public frmPhieuDichVu(string idKH, string idPH)
        {
            this.idKH = idKH;
            this.idPH = idPH;
            isSaved = true;
            InitializeComponent();
            blockField();
        
        }

        private void dgvPhieuDichVu_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvPhieuDichVu.Rows[e.RowIndex].Cells["STT"].Value = (e.RowIndex) + 1;
        }
        private void LoadDataGridView()
        {

            if (isSaved) // nếu mà phiếu đã được lưu
            {
                String sql = "SELECT CTPDV.MADV, TENDV, DONGIA, DONGIADUOCTINH, SOLUONG, THANHTIEN, CTPDV.TIENTRATRUOC, CTPDV.TIENCONLAI, NGAYGIAO, CTPDV.TINHTRANG, GHICHU "
                              + "FROM CHITIETPHIEUDICHVU CTPDV, DICHVU DV, PHIEUDICHVU PDV "
                               + " WHERE CTPDV.SOPHIEU = PDV.SOPHIEU AND CTPDV.MADV = DV.MADV AND PDV.SOPHIEU = '" + idPH + "'";
                // đọc dữ liệu từ database
                dtChiTietPhieuDichVu.Columns.Add("STT", typeof(int)); // thêm cột STT vào                  
                dtChiTietPhieuDichVu.Merge(Class.Functions.GetDataToDataTable(sql)); //thêm table sau cột STT;
                /*dtChiTietPhieuDichVu.Columns["THANHTIEN"].DataType = typeof(CurrencyManager);
                dtChiTietPhieuDichVu.Columns["TIENTRATRUOC"].DataType = typeof(CurrencyManager);
                dtChiTietPhieuDichVu.Columns["TIENCONLAI"].DataType = typeof(CurrencyManager);
                dtChiTietPhieuDichVu.Columns["NGAYGIAO"].DataType = typeof (DateTime);*/
                autoIDRows();
               


            }
            else // nếu chưa lưu, tạo table mới
            {
                dtChiTietPhieuDichVu.Columns.Add("STT", typeof(int));
                dtChiTietPhieuDichVu.Columns.Add ("MADV", typeof(string));
                dtChiTietPhieuDichVu.Columns.Add("TENDV", typeof(string));
                dtChiTietPhieuDichVu.Columns.Add("DONGIA", typeof(string));
                dtChiTietPhieuDichVu.Columns.Add("DONGIADUOCTINH", typeof(string));
                dtChiTietPhieuDichVu.Columns.Add("SOLUONG", typeof(string));
                dtChiTietPhieuDichVu.Columns.Add("THANHTIEN", typeof(decimal));
                dtChiTietPhieuDichVu.Columns.Add("TIENTRATRUOC", typeof(decimal));
                dtChiTietPhieuDichVu.Columns.Add("TIENCONLAI", typeof(decimal));
                dtChiTietPhieuDichVu.Columns.Add("NGAYGIAO", typeof(String));
                dtChiTietPhieuDichVu.Columns.Add("TINHTRANG", typeof(string));
                dtChiTietPhieuDichVu.Columns.Add("GHICHU", typeof(string));
                

            }
            dgvPhieuDichVu.DataSource = dtChiTietPhieuDichVu;
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
            dgvPhieuDichVu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPhieuDichVu.AllowUserToAddRows = false;
            dgvPhieuDichVu.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvPhieuDichVu.Columns[3].DefaultCellStyle.Format = "N0";
            dgvPhieuDichVu.Columns[3].DefaultCellStyle.FormatProvider = culture;
            dgvPhieuDichVu.Columns[4].DefaultCellStyle.Format = "N0";
            dgvPhieuDichVu.Columns[4].DefaultCellStyle.FormatProvider = culture;
            dgvPhieuDichVu.Columns[6].DefaultCellStyle.Format = "N0";
            dgvPhieuDichVu.Columns[6].DefaultCellStyle.FormatProvider = culture;
            dgvPhieuDichVu.Columns[7].DefaultCellStyle.Format = "N0";
            dgvPhieuDichVu.Columns[7].DefaultCellStyle.FormatProvider = culture;
            dgvPhieuDichVu.Columns[8].DefaultCellStyle.Format = "N0";
            dgvPhieuDichVu.Columns[8].DefaultCellStyle.FormatProvider = culture;

        }

        private void frmPhieuDichVu_Load(object sender, EventArgs e)
        {
            
            txbSoPhieu.ReadOnly = true;
            txbDonGia.ReadOnly = true;
           
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
            dtpNgaylap.CustomFormat = "dd/MM/yyyy";

            if (!isSaved)// nếu đây là phiếu chưa được lưu
            {
                String sql = "SELECT [dbo].autoKey_PHIEUDICHVU()";
                txbSoPhieu.Text = Class.Functions.GetFieldValues(sql);
                butChinhSua.Enabled = false;
                btnLuu.Enabled = true;
                dtpNgaylap.Enabled = true;
            } 
            else // nếu là phiếu cũ
            {
                txbSoPhieu.Text = this.idPH;
                string sql;
                decimal money;
                
                sql = "SELECT TENKH FROM KHACHHANG WHERE MAKH = '" + this.idKH + "'"; // lấy tên khách hàng cũ
                txbKhachHang.Text = Class.Functions.GetFieldValues(sql);
                txbKhachHang.ReadOnly = true;
                sql = "SELECT SODT FROM KHACHHANG WHERE MAKH = '" + this.idKH + "'"; // lấy số điện thoại cũ
                txbSDT.Text = Class.Functions.GetFieldValues(sql);

                //get and format textbox tongtien
                sql = "SELECT TONGTIEN FROM PHIEUDICHVU WHERE SOPHIEU = '" + this.idPH + "'";              
                money = decimal.Parse(Class.Functions.GetFieldValues(sql));
                txbTongTien.Text = currencyFomat(money);

                //get and format textbox tongtientratruoc
                sql = "SELECT TIENTRATRUOC FROM PHIEUDICHVU WHERE SOPHIEU = '" + this.idPH + "'";
                money = decimal.Parse(Class.Functions.GetFieldValues(sql));
                txbTongTraTruoc.Text = currencyFomat(money);

                //get and format textbox tongtienconlai
                sql = "SELECT TIENCONLAI FROM PHIEUDICHVU WHERE SOPHIEU = '" + this.idPH + "'";
                money = decimal.Parse(Class.Functions.GetFieldValues(sql));
                txbTongConLai.Text = currencyFomat(money);

                sql = "SELECT NGAYLAP FROM PHIEUDICHVU WHERE SOPHIEU = '" + this.idPH + "'";
                dtpNgaylap.Text = Class.Functions.GetFieldValues(sql);

                txbSDT.ReadOnly = true;
                btnLuu.Enabled = false;
                butChinhSua.Enabled = true;
                dtpNgaylap.Enabled = false;
            }    
          

            Class.Functions.FillCombo("SELECT MADV, TENDV FROM DICHVU", cmbxLoaiDichVu, "MADV", "TENDV");
            cmbxLoaiDichVu.Text = "";
            txbDonGia.Text = "";
            LoadDataGridView();         
        }

        private void cmbxLoaiDichVu_TextChanged(object sender, EventArgs e)
        {
          
                String sql = "SELECT DONGIA FROM DICHVU WHERE MADV = '" + cmbxLoaiDichVu.SelectedValue.ToString() + "'";
                  String value = Class.Functions.GetFieldValues(sql);
                if(value != "")
                {
                     decimal money = decimal.Parse(value);
                      txbDonGia.Text = currencyFomat(money);
                }
                     
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

        private void cmbxLoaiDichVu_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

        }

        private void combxTinhTrang_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }


        String currencyFomat(decimal money)
        {
            return String.Format(this.culture, "{0:N0}", money);
        }

        private void txbGiaDuocTinh_TextChanged(object sender, EventArgs e)
        {
            if (txbGiaDuocTinh.Text != "")
            {
                decimal caledMoney = decimal.Parse(txbGiaDuocTinh.Text, this.culture);
                txbGiaDuocTinh.Text = currencyFomat(caledMoney);
                txbGiaDuocTinh.Select(txbGiaDuocTinh.Text.Length, 0);
                if ( txbSoLuong.Text != "")
                {

                    decimal totalMoney = caledMoney * decimal.Parse(txbSoLuong.Text, NumberStyles.Integer);
                    txbThanhTien.Text = currencyFomat(totalMoney);

                    if (txbTraTruoc.Text != "")
                    {
                        decimal leftMoney = totalMoney - decimal.Parse(txbTraTruoc.Text, this.culture);
                        txbConLai.Text = currencyFomat(leftMoney);
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
            else
            {
                txbThanhTien.Text = "0";
                if(txbTraTruoc.Text != "")
                {
                    txbConLai.Text = currencyFomat(decimal.Parse("0", this.culture) - decimal.Parse(txbTraTruoc.Text, this.culture));
                }
              
            }

        }

        private void txbSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (txbGiaDuocTinh.Text != "" && txbSoLuong.Text != "")
            {
                decimal totalMoney = decimal.Parse(txbGiaDuocTinh.Text, this.culture) * decimal.Parse(txbSoLuong.Text, NumberStyles.Integer);
                txbThanhTien.Text = currencyFomat(totalMoney);
 
                if (txbTraTruoc.Text != "")
                {
                    decimal leftMoney = totalMoney - decimal.Parse(txbTraTruoc.Text, this.culture);
                    txbConLai.Text = currencyFomat(leftMoney);
                }
                else
                {
                    txbConLai.Text = currencyFomat(decimal.Parse(txbThanhTien.Text, this.culture));
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
                decimal payedMoney = decimal.Parse(txbTraTruoc.Text, this.culture);
                txbTraTruoc.Text = currencyFomat(payedMoney);
                txbTraTruoc.Select(txbTraTruoc.Text.Length, 0);

                if(txbThanhTien.Text != "")
                {
                    decimal totalMoney = decimal.Parse(txbThanhTien.Text, this.culture) - payedMoney;
                    txbConLai.Text = currencyFomat(totalMoney);
                }
            
              
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
           /* if (dtpNgayGiao.Value < dtpNgaylap.Value)
            {
                MessageBox.Show("Ngày giao hàng phải bằng hoặc sau ngày lập phiếu!");
                return false;
            }*/
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
            decimal ptTraTruoc = decimal.Parse(Class.Functions.GetFieldValues(sql), NumberStyles.Float);
            decimal traTruoc = decimal.Parse(txbTraTruoc.Text, this.culture);
            decimal thanhTien = decimal.Parse(txbThanhTien.Text, this.culture);
            if (traTruoc < thanhTien * ptTraTruoc) // Số tiền trả trước của từng loại dịch vụ phải >= (%TienTraTruoc x Thành tiền) của loại dịch vụ đó. 
            {
                MessageBox.Show("Số tiền trả của từng loại dịch vụ phải >= (" +  (ptTraTruoc * 100).ToString() + "% x Thành tiền) của loại dịch vụ đó");
                return false;
            }
            
            foreach(DataRow row in dtChiTietPhieuDichVu.Rows)
            {
                
                if (cmbxLoaiDichVu.SelectedValue.ToString() == row["MADV"].ToString())
                {
                    MessageBox.Show("Loại dịch vụ này đã có trong phiếu!");
                    return false;
                }
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
            if(dtChiTietPhieuDichVu.Rows.Count > 0)
            {
                decimal calValue;

                calValue = decimal.Parse(dtChiTietPhieuDichVu.Compute("Sum(THANHTIEN)", "").ToString());
                txbTongTien.Text = currencyFomat(calValue);
                calValue = decimal.Parse(dtChiTietPhieuDichVu.Compute("Sum(TIENTRATRUOC)", "").ToString());
                txbTongTraTruoc.Text = currencyFomat(calValue);
                calValue = decimal.Parse(dtChiTietPhieuDichVu.Compute("Sum(TIENCONLAI)", "").ToString());
                txbTongConLai.Text = currencyFomat(calValue);
            }
            else
            {
                txbTongTien.Text = "0";
                txbTongTraTruoc.Text = "0";
                txbTongConLai.Text = "0";
            }
            
        }
        private void buttonThem_Click(object sender, EventArgs e)
        {
            if (checkFieldChitTietPhieu())// kiểm tra các text box nhập vào đã hợp lệ chưa
            {
                object[] newRowData = new object[] {dtChiTietPhieuDichVu.Rows.Count + 1, cmbxLoaiDichVu.SelectedValue, cmbxLoaiDichVu.Text, txbDonGia.Text,  decimal.Parse(txbGiaDuocTinh.Text, this.culture), txbSoLuong.Text
                                                     , decimal.Parse(txbThanhTien.Text, this.culture), decimal.Parse(txbTraTruoc.Text, this.culture), decimal.Parse(txbConLai.Text, this.culture)  , dtpNgayGiao.Text, combxTinhTrang.Text, richtxbGhiChu.Text
                                                    };

                DataRow newRow = dtChiTietPhieuDichVu.NewRow();
                newRow.ItemArray = newRowData;
              
              dtChiTietPhieuDichVu.Rows.Add(newRowData);

                if (isSaved)
                {
                   rowsInserted.Add(newRow); //nếu phiếu đã được lưu, add vào listrowInserted để thêm khỏi csdl khi ấn nút lưu
                }
              
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
            if(dtChiTietPhieuDichVu.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng điền thông tin dịch vụ được sử dụng");
                return false;
            }
            return true;
        }

        Boolean checkKH()
        {
            String sql;
            // kiểm tra xem khách hàng đã từng mua hay sử dụng dịch vụ của cửa hàng chưa, nếu chưa thì tạo mới
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

            //lưu lại số phiếu muốn save, tí có muốn chỉnh sửa lại thì xài
            this.idKH = takeIDKH();
            this.idPH = txbSoPhieu.Text;

            String sql = "INSERT INTO PHIEUDICHVU VALUES('" + idPH + "', CONVERT(DATETIME, '" + dtpNgaylap.Value.ToString("dd/MM/yyyy") + "', 103), '"
                            + idKH + "', '" + txbTongTien.Text + "', '" + txbTongTraTruoc.Text + "', '" + txbTongConLai.Text + "', N'" + tinhTrang +"')";
            Class.Functions.RunSQL (sql);
          
        }

        void addCHITIETPHIEUDICHVU()
        {   

            String sql;
            foreach (DataRow row in dtChiTietPhieuDichVu.Rows)
            {
                sql = "INSERT INTO CHITIETPHIEUDICHVU VALUES('"
                     + row["MADV"].ToString()
                     + "', '" + txbSoPhieu.Text
                     + "', '" + row["DONGIADUOCTINH"].ToString()
                     + "',  " + row["SOLUONG"].ToString() // int nên k có dấu "'"
                     + ", '" + row["THANHTIEN"].ToString()
                     + "', '" + row["TIENTRATRUOC"].ToString()
                     + "', '" + row["TIENCONLAI"].ToString()
                     + "', CONVERT(DATETIME, '" + string.Format(row["NGAYGIAO"].ToString(), "dd/MM/yyyy") + "', 103)"
                     + ", N'" + row["TINHTRANG"].ToString()
                      + "', N'" + row["GHICHU"].ToString().Trim() + "')";
                //MessageBox.Show(sql);
                Class.Functions.RunSQL(sql);
            }
           
        }

        void updatePHIEUDICHVU()
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

            String sql = "UPDATE PHIEUDICHVU SET TONGTIEN = '" + txbTongTien.Text + "', TIENTRATRUOC = '" + txbTongTraTruoc.Text
                    + "', TIENCONLAI = '" + txbTongConLai.Text + "', NGAYLAP = '" + dtpNgaylap.Value.ToString("dd/MM/yyyy")   +  "', TINHTRANG = N'" + tinhTrang 
                    + "' WHERE SOPHIEU = '" + this.idPH + "'";
                    Class.Functions.RunSQL(sql);
        }

        void updateKHACHHANG()
        {
            String sql = "UPDATE KHACHHANG SET TENKH = N'" + txbKhachHang.Text + "', SODT = '" + txbSDT.Text
                  + "' WHERE MAKH = '" + this.idKH + "'";
            Class.Functions.RunSQL(sql);
        }
                  
        void insertCHITIETPHIEUDICHVU()
        {

            String sql;
            foreach (DataRow row in rowsInserted)
            {
                sql = "INSERT INTO CHITIETPHIEUDICHVU VALUES('"
                     + row["MADV"].ToString()
                     + "', '" + idPH
                     + "', '" + row["DONGIADUOCTINH"].ToString()
                     + "',  " + row["SOLUONG"].ToString() // int nên k có dấu "'"
                     + ", '" + row["THANHTIEN"].ToString()
                     + "', '" + row["TIENTRATRUOC"].ToString()
                     + "', '" + row["TIENCONLAI"].ToString()
                     + "', CONVERT(DATETIME, '" + row["NGAYGIAO"].ToString() + "', 103)"
                     + ", N'" + row["TINHTRANG"].ToString()
                      + "', N'" + row["GHICHU"].ToString().Trim() + "')";
                
                Class.Functions.RunSQL(sql);
            }
        }
        void deleteCHITIETPHIEUDICHVU()
        {
            String sql;
            foreach (DataRow row in rowsDeleted)
            {
                sql = "DELETE FROM CHITIETPHIEUDICHVU WHERE MADV = '" + row["MADV"].ToString() + "' AND SOPHIEU = '" + this.idPH + "'";              
                Class.Functions.RunSQL(sql);
            }
        }

        void blockField()
        {           
            txbKhachHang.ReadOnly = true;
            dtpNgaylap.Enabled = false;
            txbSDT.ReadOnly = true;
            cmbxLoaiDichVu.Enabled = false;
            txbGiaDuocTinh.Enabled = false;
            txbSoLuong.Enabled = false;
            dtpNgayGiao.Enabled = false;
            txbTraTruoc.Enabled = false;
            combxTinhTrang.Enabled = false;
            richtxbGhiChu.Enabled = false;
            btnThem.Enabled = false;
            btnLuu.Enabled = false;           
        }

       

        void unlockField()
        {
            txbKhachHang.ReadOnly = false;
            txbSDT.ReadOnly = false;
            dtpNgaylap.Enabled = true;
            cmbxLoaiDichVu.Enabled = true;
            txbGiaDuocTinh.Enabled = true;
            txbSoLuong.Enabled = true;
            dtpNgayGiao.Enabled = true;
            txbTraTruoc.Enabled = true;
            combxTinhTrang.Enabled = true;
            richtxbGhiChu.Enabled = true;
            btnThem.Enabled = true;
            btnLuu.Enabled = true;
        }
   
        void clearDataChanged()
        {
            rowsDeleted.Clear();
            rowsInserted.Clear();
            rowsUpdated.Clear();    
        }

        Boolean savePhieu()
        {

            if (checkFieldThongTinChung())// nếu các thông tin đã hợp lệ
            {
                if (!isSaved)
                {

                    try
                    {
                        if (!checkKH()) // nếu khách hàng mới đến lần đầu
                        {
                            addKH(); // thêm khách hàng
                        }
                        //thêm phiếu dịch vụ vào PHIEUDICHVU
                        addPHIEUDICHVU();

                        //thêm các  chi tiết phiếu dịch vụ trong dgvPHIEUDICHVU của PHIEUDICHVU vừa tạo vào database
                        addCHITIETPHIEUDICHVU();
                        isSaved = true;
                        MessageBox.Show("Lưu thành công");
                        blockField();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);    
                        return false;
                    }
                   


                }
                else // nếu phiếu đã được lưu, hay được mở từ form thống kê số phiếu(tức là phiếu có sẵn) thì viết code update ở đây
                {
                    try
                    {
                        updateKHACHHANG();
                        deleteCHITIETPHIEUDICHVU(); //phải delete trước mới insert được, lỡ xóa MADV rồi add lại cùng MADV thì sao :> 
                        insertCHITIETPHIEUDICHVU();              
                        updatePHIEUDICHVU();
                        clearDataChanged();   // xóa data khỏi list đợi
                        isSaveChanges = true;
                        blockField();
                        MessageBox.Show("Lưu thành công");
                        return true;
                    }catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return false;
                    } 
                  
                }
            }
            return false;
           
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            savePhieu();
            butChinhSua.Enabled = true;
            isSaved = true;
           
          
        }

        private void butChinhSua_Click(object sender, EventArgs e)
        {
            butChinhSua.Enabled = false;
            btnLuu.Enabled = true;
            isSaveChanges = false;
            unlockField();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (!isSaved)
            {
                if (MessageBox.Show("Bạn có muốn lưu phiếu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (savePhieu())
                    {   
                        
                        this.Close();
                    }
                  
                }
                else
                {
                    this.Close();
                }
            }
            else if (!isSaveChanges)
            {
                if (MessageBox.Show("Bạn có muốn lưu những thay đổi trong phiếu này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (savePhieu())
                    {
                        this.Close();
                    }
                  

                }
                else
                {
                    this.Close();
                }
            }
            else this.Close();
          
        }

        void autoIDRows()
        {
            foreach(DataRow row in dtChiTietPhieuDichVu.Rows)
            {
                row["STT"] = dtChiTietPhieuDichVu.Rows.IndexOf(row) + 1;
            }
        }
        private void dgvPhieuDichVu_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!isSaved || !isSaveChanges)
            {
                if (e.Button == MouseButtons.Right)
                {
                    dgvPhieuDichVu.Rows[e.RowIndex].Selected = true;
                    this.rowIndex = e.RowIndex;
                    dgvPhieuDichVu.CurrentCell = this.dgvPhieuDichVu.Rows[e.RowIndex].Cells[1];
                    contextMenuStripRightClick.Show(dgvPhieuDichVu, e.Location);
                    contextMenuStripRightClick.Show(Cursor.Position);
                }
            }
        }

        private void deleteRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isSaved || !isSaveChanges)
            {
                if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {

                    DataRowView dataRowSelectedView = (DataRowView)dgvPhieuDichVu.Rows[rowIndex].DataBoundItem;
                    DataRow dataRowSelected = dataRowSelectedView.Row;


                    if (isSaved) // nếu phiếu đã được lưu, add vào listrowsInserted để thêm khi ấn nút lưu
                    {
                        DataRow deledRow = dataRowSelectedView.Row.Table.NewRow(); // copy nó, cho nó khỏi tham chiếu
                        deledRow.ItemArray = dataRowSelectedView.Row.ItemArray;
                        rowsDeleted.Add(deledRow);

                        if (rowsInserted.Contains(dataRowSelectedView.Row)) // nếu mà cái vừa xóa có trong list đợi insert, thi remove nó đi khỏi list insert
                        {
                            rowsInserted.Remove(dataRowSelectedView.Row);
                        }
                    }
                    dtChiTietPhieuDichVu.Rows.Remove(dataRowSelectedView.Row);
                    autoIDRows();  // đánh lại số thứ tự row
                    calSumMoney(); // tính toán lại tổng tiền

                }
            }

        }

        private void dgvPhieuDichVu_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView.HitTestInfo hit = dgvPhieuDichVu.HitTest(e.X, e.Y);
                if (hit.Type == DataGridViewHitTestType.None)
                {
                    dgvPhieuDichVu.ClearSelection();
                    dgvPhieuDichVu.CurrentCell = null;
                }
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            //string sql;
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
            exRange.Range["B5:B5"].Value = "Ngày lập:";
            exRange.Range["C5:E5"].MergeCells = true;
            exRange.Range["C5:E5"].Value = dtpNgaylap.Text;
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["B6:B6"].Value = "Khách hàng:";
            exRange.Range["C6:E6"].Value = txbKhachHang.Text;
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["B7:B7"].Value = "Số điện thoại:";
            exRange.Range["C7:E7"].Value = txbSDT.Text.Trim();



            // sql = "SELECT TENSP, TENLOAISP,  CHITIETPHIEUBANHANG.SOLUONG, DONGIA, CHITIETPHIEUBANHANG.SOLUONG * DONGIA FROM SANPHAM, LOAISANPHAM, CHITIETPHIEUBANHANG WHERE SANPHAM.MALOAISP = LOAISANPHAM.MALOAISP AND SANPHAM.MASP = CHITIETPHIEUBANHANG.MASP AND CHITIETPHIEUBANHANG.SOPHIEU =  '" + txbSoPhieu.Text + "'";
            // tbSP = Class.Functions.GetDataToDataTable(sql); //Tạo dòng tiêu đề bảng
            exRange.Range["A10:L10"].Font.Bold = true;
            exRange.Range["A10:L10"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C10:L10"].ColumnWidth = DataGridViewAutoSizeColumnMode.Fill;
            exRange.Range["A10:A10"].Value = "STT";
            exRange.Range["B10:B10"].Value = "Mã dịch vụ";
            exRange.Range["C10:C10"].Value = "Loại dịch vụ";
            exRange.Range["D10:D10"].Value = "Đơn giá dịch vụ";
            exRange.Range["E10:E10"].Value = "Đơn giá được tính";
            exRange.Range["F10:F10"].Value = "Số lượng";
            exRange.Range["G10:G10"].Value = "Thành tiền";
            exRange.Range["H10:H10"].Value = "Trả trước";
            exRange.Range["I10:I10"].Value = "Còn lại";
            exRange.Range["J10:J10"].Value = "Ngày giao";
            exRange.Range["K10:K10"].Value = "Tình trạng";
            exRange.Range["L10:L10"].Value = "Ghi chú";

           for (int row = 0; row < dtChiTietPhieuDichVu.Rows.Count; row++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
               // exSheet.Cells[1][row + 11] = row + 1;
                for (int column = 0; column < dtChiTietPhieuDichVu.Columns.Count; column++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12

                {   
                    if(column == 9)
                    {
                        DateTime dateTime = (DateTime)dtChiTietPhieuDichVu.Rows[row][column];
                        exSheet.Cells[column + 1][row + 11] = dateTime.ToString("dd/MM/yyyy");
                    }
                    exSheet.Cells[column + 1][row + 11] = dtChiTietPhieuDichVu.Rows[row][column].ToString();
                }
            }
          
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

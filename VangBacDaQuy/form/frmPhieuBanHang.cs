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
            txbSoPhieu.Text = "PH";
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
                if(cbMaKH.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbMaKH.Focus();
                    return;
                }

                sql = "INSERT INTO PHIEUBANHANG VALUES('" + txbSoPhieu.Text + "', '" + cbMaKH.Text + "', '" + dtpNgaylap.Value.ToString("dd/MM/yyyy") +"'," + txbTongtien.Text + ")" ;
                
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
            if(txbSoPhieu.Text != "")
            {
                LoadInfoHoaDon();
                btnXoa.Enabled=true;
                btnIn.Enabled=true;
            }
            LoadDataGridView();
        }

        private void LoadInfoHoaDon()
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
    }
}

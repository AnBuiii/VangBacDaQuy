using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VangBacDaQuy.controller;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace VangBacDaQuy.form
{
    public partial class frmPhieuBanHang : Form
    {
        DataTable dtChiTietPhieuBanHang;
        ctlFrmPhieuBanHang controller = new ctlFrmPhieuBanHang();
        public frmPhieuBanHang()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {

        }

      

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT SANPHAM.MASP, TENSP, TENLOAISP, DONGIA, SOLUONG, SOLUONG*DONGIA AS THANHTIEN" +
                   " FROM SANPHAM, CHITIETPHIEUBANHANG, LOAISANPHAM" +
                    " WHERE SANPHAM.MASP = CHITIETPHIEUBANHANG.MASP AND SANPHAM.MALOAISP = LOAISANPHAM.MALOAISP ";
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
            txbMaPhieu.ReadOnly = true;
            txbTenKH.ReadOnly = true;
            txbTenSP.ReadOnly = true;
            txbDongia.ReadOnly = true;
            txbThanhtien.ReadOnly = true;
            txbTongtien.Text = "0";
            Class.Functions.FillCombo("SELECT MAKH, TENKH FROM KHACHHANG", cbMaKH, "MAKH", "MAKH");
            Class.Functions.FillCombo("SELECT MASP, TENSP FROM SANPHAM", cbMaSP, "MASP", "MASP");
            if(txbMaPhieu.Text != "")
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
            sql = "SELECT NGAYLAP FROM PHIEUBANHANG WHERE SOPHIEU = '" + txbMaPhieu.Text + "'";
            dtpNgaylap.Value = DateTime.Parse(Class.Functions.GetFieldValues(sql));
            sql = "SELECT MAKH FROM PHIEUBANHANG WHERE SOPHIEU = '" + txbMaPhieu.Text + "'";
            cbMaKH.Text = Class.Functions.GetFieldValues(sql);
            sql = "SELECT TONGTIEN FROM PHIEUBANHANG WHERE SOPHIEU = '" + txbMaPhieu.Text + "'";
            txbTongtien.Text = Class.Functions.GetFieldValues(sql);
        }
    }
}

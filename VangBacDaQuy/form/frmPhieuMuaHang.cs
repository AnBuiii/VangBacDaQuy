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
    public partial class frmPhieuMuaHang : Form
    {
        DataTable dtChiTietPhieuMuaHang;
        string sophieu;
        public frmPhieuMuaHang()
        {
            this.MaximizeBox = false;
            InitializeComponent();
            textBox_ProductName.ReadOnly=true;
            LoadDataGridView();
        }
        public frmPhieuMuaHang(string sophieu)
        {
            this.MaximizeBox = false;
            InitializeComponent();
            textBox_ProductName.ReadOnly = true;
            LoadDataGridView();
            this.sophieu = sophieu;
        }
        private void updateProductID()
        {
            string sql, ProductTypeID;
            sql = "select MALOAISP from LOAISANPHAM where TENLOAISP = N'"+comboBox_productType.Text+"'";
            ProductTypeID = Class.Functions.GetFieldValues(sql);
            sql = "select MASP from SANPHAM where MALOAISP ='" + ProductTypeID + "'";
            Class.Functions.FillCombo(sql, comboBox_ProductID, "MASP", "MASP");
            
        }

        private void updateProductType()
        {
            string sql;
            sql = "select TENLOAISP from LOAISANPHAM";
            Class.Functions.FillCombo(sql, comboBox_productType, "TENLOAISP", "TENLOAISP");
        }
        private void updateProductDetail()
        {
            string sql;
            sql = "select DONGIA from SANPHAM where MASP='" + comboBox_ProductID.Text + "'";
            textBox_Price.Text = Class.Functions.GetFieldValues(sql).Remove(Class.Functions.GetFieldValues(sql).Length - 6, 5);
            sql = "select TENSP from SANPHAM where MASP='" + comboBox_ProductID.Text + "'";
            textBox_ProductName.Text = Class.Functions.GetFieldValues(sql);
        }
 
        private void formReload(string text)
        {
            string sql;
            sql = "select SOPHIEU from PHIEUMUAHANG where SOPHIEU='" + text + "'";
            if (Class.Functions.CheckKey(sql))
            {
                textBox_ID.Text = text;
                sql = "select NGAYLAP from PHIEUMUAHANG where SOPHIEU='" + textBox_ID.Text + "'";
                dateTimePicker_date.Value = Convert.ToDateTime(Class.Functions.GetFieldValues(sql));
                sql = "select MANCC from PHIEUMUAHANG where SOPHIEU='" + textBox_ID.Text + "'";
                textBox_NCC.Text = Class.Functions.GetFieldValues(sql);
                sql = "select DIACHI from NHACUNGCAP where MANCC='" + textBox_NCC.Text + "'";
                textBox_Address.Text = Class.Functions.GetFieldValues(sql);
                sql = "select SODT from NHACUNGCAP where MANCC='" + textBox_NCC.Text + "'";
                textBox_SDT.Text = Class.Functions.GetFieldValues(sql);
                sql = "select TONGTIEN from PHIEUMUAHANG where SOPHIEU='" + textBox_ID.Text + "'";
                textBox_Total.Text = Class.Functions.GetFieldValues(sql).Remove(Class.Functions.GetFieldValues(sql).Length - 6, 5);
                LoadDataGridView();
                button_Save.Text = "Cập nhật";
                button_Delete.Enabled = true;
            }
            else
            {
                ResetFormState();
                LoadDataGridView();
            }
        }

        private void LoadDataGridView()
        {
            dataGridView_List.Refresh();
            string sql;
            sql = "SELECT SANPHAM.MASP, TENSP, TENLOAISP, REPLACE(CAST(DONGIA as varchar(31)),'.00',''), CHITIETPHIEUMUAHANG.SOLUONG, CHITIETPHIEUMUAHANG.SOLUONG*DONGIA AS THANHTIEN" +
                   " FROM SANPHAM, CHITIETPHIEUMUAHANG, LOAISANPHAM" +
                    " WHERE SANPHAM.MASP = CHITIETPHIEUMUAHANG.MASP AND SANPHAM.MALOAISP = LOAISANPHAM.MALOAISP AND SOPHIEU = '" + textBox_ID.Text + "'";
            //sql = "SELECT MASP, TENSP, MALOAISP, DONGIA FROM SANPHAM";
            dtChiTietPhieuMuaHang = Class.Functions.GetDataToDataTable(sql);
            dataGridView_List.DataSource = dtChiTietPhieuMuaHang;
            dataGridView_List.Columns[0].HeaderText = "Mã sản phẩm";
            dataGridView_List.Columns[1].HeaderText = "Tên sản phẩm";
            dataGridView_List.Columns[2].HeaderText = "Loại sản phẩm";
            dataGridView_List.Columns[3].HeaderText = "Đơn giá";
            dataGridView_List.Columns[4].HeaderText = "Số lượng";
            dataGridView_List.Columns[5].HeaderText = "Thành tiền";
            dataGridView_List.AllowUserToAddRows = false;
        }      

        private void dataGridView_List_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView_List.Rows[e.RowIndex];             
                comboBox_ProductID.Text = row.Cells[0].Value.ToString();
                textBox_ProductName.Text = row.Cells[1].Value.ToString();
                comboBox_productType.Text = row.Cells[2].Value.ToString();
                textBox_Price.Text = row.Cells[3].Value.ToString();
                textBox_quantity.Text = row.Cells[4].Value.ToString();
                textBox_totalPrice.Text = row.Cells[5].Value.ToString().Remove(row.Cells[5].Value.ToString().Length -6, 5);
                cMS_rightclick.Enabled = true;
            }
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            string sql;
            int TotalNew=Convert.ToInt32(textBox_Total.Text);
            sql = "select MASP from CHITIETPHIEUMUAHANG where (MASP='" + comboBox_ProductID.Text + "' and SOPHIEU='"+textBox_ID.Text+"')" ;
            if (!Class.Functions.CheckKey(sql))
            {
                sql = "update SANPHAM set SOLUONG = SOLUONG + " + textBox_quantity.Text + " where MASP = '" + comboBox_ProductID.Text + "'";
                Class.Functions.RunSQL(sql);
                sql = "INSERT INTO CHITIETPHIEUMUAHANG VALUES('" + comboBox_ProductID.Text + "','" + textBox_ID.Text + "'," + textBox_quantity.Text + ")";
                Class.Functions.RunSQL(sql);
                LoadDataGridView();
                if (dataGridView_List.RowCount > 0)
                    button_Save.Enabled = true;
                TotalNew += Convert.ToInt32(textBox_totalPrice.Text);
                textBox_Total.Text=Convert.ToString(TotalNew);
                textBox_ID.Enabled = false;
            }
            else
                MessageBox.Show("Sản phẩm đã tồn tại.");
        }

        private void textBox_quantity_TextChanged(object sender, EventArgs e)
        {
            int TotalPrice, quantity;
            if (textBox_quantity.Text != "")
            {
                quantity = Convert.ToInt32(textBox_quantity.Text);
                string pricetext = textBox_Price.Text;
                int price = Convert.ToInt32(pricetext);
                TotalPrice = quantity * price;
                textBox_totalPrice.Text = Convert.ToString(TotalPrice);               
            }
            if (button_Save.Text == "Cập nhật" && !string.IsNullOrEmpty(textBox_quantity.Text))
                button_Add.Enabled = true;
        }

        private void comboBox_ProductID_TextChanged(object sender, EventArgs e)
        {
            updateProductDetail();
        }

        private void frmPhieuMuaHang_Load(object sender, EventArgs e)
        {
            ResetFormState();
            String sql = "SELECT [dbo].autoKey_PHIEUMUAHANG()";
            textBox_ID.Text = Class.Functions.GetFieldValues(sql);
            //textBox_ID.Text = sophieu;

        }

        private void ResetFormState()
        {
            textBox_ID.Select();
            dateTimePicker_date.Value = DateTime.Now;
            textBox_SDT.Text = "";
            textBox_Address.Text = "";
            textBox_NCC.Text = "";
            textBox_quantity.Text = "";
            textBox_totalPrice.Text = "0";
            textBox_Total.Text = "0";
            textBox_SearchID.Text = "";
            button_Add.Enabled = false;
            button_Delete.Enabled = false;
            button_Print.Enabled = false;
            button_Save.Enabled = false;
            updateProductType();
            updateProductID();
            updateProductDetail();
            button_Save.Text = "Tạo phiếu";
            dataGridView_List.Refresh();
            string sql;
            sql = "select SOPHIEU from PHIEUMUAHANG";
            Class.Functions.FillCombo(sql, textBox_SearchID, "SOPHIEU", "SOPHIEU");
            cMS_rightclick.Enabled = false;
        }

        private void textBox_ID_TextChanged(object sender, EventArgs e)
        {
            formReload(textBox_ID.Text);
            button_Save.Enabled = true;
            if (!string.IsNullOrEmpty(textBox_ID.Text) && !string.IsNullOrEmpty(textBox_quantity.Text))
                button_Add.Enabled = true;
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            if (textBox_ID.Enabled == false)
                MessageBox.Show("Vui lòng cập nhật phiếu trước.");
            else
                formReload(textBox_SearchID.Text);

        }

        private void comboBox_productType_TextChanged(object sender, EventArgs e)
        {
            updateProductID();
        }

        private void textBox_NCC_TextChanged(object sender, EventArgs e)
        {
            string sql;
            sql = "select MANCC from NHACUNGCAP where MANCC='" + textBox_NCC.Text + "'";
            if (Class.Functions.CheckKey(sql))
            {
                sql = "select SODT from NHACUNGCAP where MANCC='" + textBox_NCC.Text + "'";
                textBox_SDT.Text = Class.Functions.GetFieldValues(sql);
                sql = "select DIACHI from NHACUNGCAP where MANCC='" + textBox_NCC.Text + "'";
                textBox_Address.Text = Class.Functions.GetFieldValues(sql);
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            string sql;
            if (button_Save.Text == "Tạo phiếu")
            {
                if (!string.IsNullOrEmpty(textBox_ID.Text) && !string.IsNullOrEmpty(textBox_Address.Text) && !string.IsNullOrEmpty(textBox_NCC.Text)
                       && !string.IsNullOrEmpty(textBox_SDT.Text))
                {
                    sql = "insert into PHIEUMUAHANG values('" + textBox_ID.Text + "','" + dateTimePicker_date.Value.ToString("MM/dd/yyyy") + "','"
                        + textBox_NCC.Text + "'," + textBox_Total.Text + ")";
                    Class.Functions.RunSQL(sql);
                    button_Save.Text = "Cập nhật";
                    button_Delete.Enabled = true;
                    button_Add.Enabled = true;
                }
                else
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
            }
            else
            {
                sql = "update PHIEUMUAHANG set TONGTIEN = " + textBox_Total.Text + " where SOPHIEU ='" + textBox_ID.Text + "'";
                Class.Functions.RunSQL(sql);
                button_Save.Enabled = false;
                textBox_ID.Enabled = true;
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xóa dữ liệu", MessageBoxButtons.YesNo);
            if (Result == DialogResult.Yes)
            {
                int sl, slxoa;
                string sql = "SELECT MASP, SOLUONG FROM CHITIETPHIEUMUAHANG WHERE SOPHIEU = '" + textBox_ID.Text + "'";
                DataTable tbSP = Class.Functions.GetDataToDataTable(sql);
                for (int row = 0; row < tbSP.Rows.Count; row++)
                {
                    sql = "SELECT SOLUONG FROM SANPHAM WHERE MASP = '" + tbSP.Rows[row][0].ToString() + "'";
                    sl = Convert.ToInt32(Class.Functions.GetFieldValues(sql));
                    slxoa = Convert.ToInt32(tbSP.Rows[row][1].ToString());
                    sl += slxoa;
                    sql = "UPDATE SANPHAM SET SOLUONG = " + sl + " WHERE MASP = '" + tbSP.Rows[row][0].ToString() + "'";
                    Class.Functions.RunSQL(sql);
                }
                sql = "delete from CHITIETPHIEUMUAHANG where SOPHIEU='" + textBox_ID.Text + "'";
                Class.Functions.RunSQL(sql);
                sql = "delete from PHIEUMUAHANG where SOPHIEU='" + textBox_ID.Text + "'";
                Class.Functions.RunSQL(sql);
                ResetFormState();
                textBox_ID.Text = "";
            }
        }

        private void textBox_totalPrice_TextChanged(object sender, EventArgs e)
        {
            button_Save.Enabled = true;
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cMS_rightclick_Opening(object sender, CancelEventArgs e)
        {

        }

        private void item1_Click(object sender, EventArgs e)
        {

            string masp, sql;
            Double ThanhTienxoa, tong;
            int slXoa, sl;
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng 
                masp = dataGridView_List.CurrentRow.Cells["MASP"].Value.ToString();
                slXoa = Convert.ToInt32(dataGridView_List.CurrentRow.Cells["SOLUONG"].Value.ToString());
                ThanhTienxoa = Convert.ToDouble(textBox_totalPrice.Text);
                sql = "DELETE CHITIETPHIEUMUAHANG WHERE SOPHIEU = '" + textBox_ID.Text + "' AND MASP = '" + masp + "'";
                Class.Functions.RunSQL(sql);
                // Cập nhật số lượng
                sql = "SELECT SOLUONG FROM SANPHAM WHERE MASP = '" + masp + "'";
                sl = Convert.ToInt32(Class.Functions.GetFieldValues(sql));
                sl += slXoa;
                sql = "UPDATE SANPHAM SET SOLUONG =" + sl + " WHERE MASP = '" + masp + "'";
                Class.Functions.RunSQL(sql);
                tong = Convert.ToDouble(textBox_Total.Text);
                tong -= ThanhTienxoa;              
                textBox_Total.Text = tong.ToString();
                textBox_ID.Enabled = false;
                button_Save.Enabled = true;
                LoadDataGridView();
                
            }
        }

        private void textBox_quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
           if(!Char.IsDigit(e.KeyChar)&&!Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
